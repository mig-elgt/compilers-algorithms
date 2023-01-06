using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Convertidor_de_Expresiones.Clases;
using Convertidor_de_Expresiones;
using AFN_Thompson.Clases.AFN;
using System.IO;
using GramaticasRegulares.Clases.Gramatica;

namespace AFN_Thompson
{
    public partial class Form1 : Form
    {
        private CAutomata thompson;
        private CExpresion expReg;
        private CGramatica gramaticaReg;
        private AFN mS;
        private List<string> alfabeto;
        private List<PictureBox> LP;
        private List<CAutomata> LA;
        private List<List<string>> listaPruebas;
        private FileStream fs;
        private StreamReader sr;
        private string nameFile;
        private int autoSelect; 
        
        //Atributos para el dibujado
        private Graphics g;
        private Pen pluma;
        private Pen plumaArista;
        private Font fuente;
        private int radio;

        public Form1()
        {
            InitializeComponent();

            expReg = new CExpresion();
            mS = new AFN();
            gramaticaReg = new CGramatica();
            LA = new List<CAutomata>();
            LP = new List<PictureBox>();

            LP.Add(pictureThompson);

            autoSelect = 0;
            pluma = new Pen(Color.Blue, 5);
            plumaArista = new Pen(Color.Red, 5);
            plumaArista.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            fuente = new Font("Arial", 15, FontStyle.Bold);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            expReg.setExp(tbExpReg.Text);
            LA.Clear();
           
            if (tbExpReg.Text.Length > 0)
                if (expReg.validaExpresion())
                {
                    expReg.normalizate();
                    expReg.Conviertete();
                    alfabeto = expReg.getAlfabeto();
                    mS.setExpPosfija(expReg.getExpPolacaInv());
                    thompson = mS.CreaAFN();
                    cargaAFN();
                    LA.Add(thompson);
                    LP[autoSelect].Size = new Size(thompson.getAncho() + 10, thompson.getAlto());
                    DibujaAutomata();
                }else
                   MessageBox.Show("La expresion es incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Método para crear el árbol de relación a partir del AFN
        private void cargaAFN()
        {
            List<CEstado> lE;
            List<CTransicion> lT;
            TreeNode[] arrayTran;
            TreeNode[] arrayEstados;
            TreeNode[] T;
            TreeNode[] CT;
            TreeNode[] EP;
            string cad;

            treViewAFN.Nodes.Clear();
            lE = thompson.getListEstados();
            T = new TreeNode[3];
            EP = new TreeNode[1];
            CT = new TreeNode[1];
            arrayEstados = new TreeNode[lE.Count];

            for (int i = 0; i < lE.Count; i++)
            {
                cad = null;
                arrayTran = new TreeNode[lE[i].getListTransicion().Count];
                lT = lE[i].getListTransicion();
                for (int j = 0; j < lT.Count; j++)
                {
                    arrayTran[j] = new TreeNode(lT[j].getEstadoSig().getNombre() + " , " + lT[j].getEtiqueta());
                    arrayTran[j].Name = j.ToString();
                }

                if (i == 0)
                    cad = " (Inicio) ";
                else
                    if (i == lE.Count - 1)
                        cad = " (Aceptación) ";

                arrayEstados[i] = new TreeNode(lE[i].getNombre().ToString() + cad, arrayTran);
            }

            EP[0] = new TreeNode(expReg.getExpRegPosf());
            T[0] = new TreeNode(expReg.getExpReg());
            T[1] = new TreeNode("RPN", EP);
            T[2] = new TreeNode("AFN", arrayEstados);
            CT[0] = new TreeNode("Construción de Thompson", T);

            treViewAFN.Nodes.AddRange(CT);
        }

        //Se obtiene un objeto grafics para hacer el dibujado
        private Graphics ObtenerObjectGraphics()
        {
            Bitmap mapaBits = new Bitmap(LP[autoSelect].Width, LP[autoSelect].Height);
            Graphics g;

            LP[autoSelect].Image = mapaBits;
            g = Graphics.FromImage(mapaBits);
            g.Clear(Color.White);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            return (g);
        }

        public void DibujaAutomata()
        {
            Rectangle r;
            Point pAux;
            PointF p;
            int x2, y2;

            g = ObtenerObjectGraphics();
            pAux = new Point();

            x2 = 0;
            y2 = thompson.getEstadoInicial().getCentroY();

            g.DrawLine(plumaArista, x2,y2,50,y2);
            g.DrawString("Inicio", new Font("Arial", 12, FontStyle.Bold), Brushes.Black,0,y2-20);
           
            foreach (CEstado e in LA[autoSelect].getListEstados())
            {
                r = new Rectangle(e.getCentroX() - e.getRadio(), e.getCentroY() - e.getRadio(), e.getRadio() * 2, e.getRadio() * 2);
                g.DrawEllipse(pluma, r);

                foreach (CTransicion t in e.getListTransicion())
                {
                    x2 = y2 = 0;
                    if (t.getTipo() == 1)
                    {
                        p = DibujaTransicion(t.getEstadoAct(), t.getEstadoSig(), t.getEtiqueta(), ref pAux);
                        g.DrawLine(plumaArista, t.getEstadoAct().getCentroX(), t.getEstadoAct().getCentroY(), pAux.X, pAux.Y);
                        g.DrawString(t.getEtiqueta(), fuente, Brushes.Black, p.X, p.Y);
                    }
                    else
                    {
                        DibujaTransicion(t.getPuntosControl(), t.getEtiqueta());
                    }
                }

                g.FillEllipse(new SolidBrush(Color.White), r);
                g.DrawString(e.getNombre().ToString(), fuente, Brushes.Black, e.getCentroX() - 10, e.getCentroY() - 10);

                if (e.getEstado().CompareTo("Final") == 0)
                {
                    r = new Rectangle(e.getCentroX() - 20, e.getCentroY()-20, 40,40);
                    g.DrawEllipse(new Pen(Color.Green, 3), r);
                }
            }
            g.Dispose();
        }

        //Se dibuja una curva spline cardinal
        private void DibujaTransicion(List<Point> pC, string et)
        {
            CEstado A, B;
            Point[] p = new Point[pC.Count];
            Point pAux = new Point();
            int x, y;

            for (int i = 0; i < pC.Count; i++)
                p[i] = pC[i];

            A = new CEstado();
            B = new CEstado();

            A.setCentro(p[4].X, p[4].Y);
            B.setCentro(p[5].X, p[5].Y);
            A.setRadio(25);
            DibujaTransicion(A, B, null, ref pAux);
            
            p[5] = pAux;
            g.DrawCurve(plumaArista, p,0);

            x = p[2].X+Convert.ToInt32((p[3].X-p[2].X)/2);
            y = p[2].Y;
            g.DrawString(et, fuente, Brushes.Black, x, y-18);
        }

        //Se dibuja una transicón de tipo recta
        private PointF DibujaTransicion(CEstado A, CEstado B, string et, ref Point pAux)
        {
            PointF pAuxB;
            double theta, xP, yP, h, xM, yM;
            int dX, dY, cXA, cYA, cYB, cXB;

            radio = A.getRadio();
            cXA = A.getCentroX();
            cYA = A.getCentroY();
            cXB = B.getCentroX();
            cYB = B.getCentroY();

            dX = cXB - cXA;
            dY = cYB - cYA;

            h = Math.Sqrt(Math.Pow(dX, 2) + Math.Pow(dY, 2));
            theta = (Math.Atan((double)dY / dX)) * 180 / Math.PI;

            xP = Math.Cos((theta * Math.PI) / 180) * radio;
            yP = Math.Sin((theta * Math.PI) / 180) * radio;
            xM = Math.Cos((theta * Math.PI) / 180) * h / 2;
            yM = Math.Sin((theta * Math.PI) / 180) * h / 2; ;

            if (cXB >= cXA)
            {
                pAux = new Point(cXB - (int)Math.Round(xP), cYB - (int)Math.Round(yP));
                pAuxB = new PointF(cXA + (float)xM - 5, cYA + (float)yM);
            }
            else
            {
                pAux = new Point(cXB + (int)Math.Round(xP), cYB + (int)Math.Round(yP));
                pAuxB = new PointF(cXA - (float)xM + 5, cYA - (float)yM);
            }

            return (pAuxB);
        }

        private void AlejaAutomata(object sender, EventArgs e)
        {
            double k;
            int nuevoAlto;
            int nuevoAncho;

            if (LP[autoSelect].Image != null)
            {
                k = (double)LP[autoSelect].Image.Width / LP[autoSelect].Image.Height;
                nuevoAncho = Convert.ToInt32(LP[autoSelect].Width / 1.25);
                nuevoAlto = Convert.ToInt32(nuevoAncho / k);

                LP[autoSelect].Width = nuevoAncho;
                LP[autoSelect].Height = nuevoAlto;

                LP[autoSelect].SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void AcercaAutomata(object sender, EventArgs e)
        {
            double k;
            int nuevoAlto;
            int nuevoAncho;

            if (LP[autoSelect].Image != null)
            {
                k = (double)LP[autoSelect].Image.Width / LP[autoSelect].Image.Height;
                nuevoAncho = Convert.ToInt32(LP[autoSelect].Width * 1.25);
                nuevoAlto = Convert.ToInt32(nuevoAncho / k);

                LP[autoSelect].Width = nuevoAncho;
                LP[autoSelect].Height = nuevoAlto;

                LP[autoSelect].SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < 1)
                autoSelect = tabControl1.SelectedIndex;
        }

        private void MenuAbrirGramatica_Click(object sender, EventArgs e)
        {
            FileStream fs;
            StreamReader sr;
            string nameFile;
            string text;

            text = null;
            sr = null;

            openFileDialog1.Filter = "Archivos de prueba|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                nameFile = openFileDialog1.FileName;

                try
                {
                    fs = new FileStream(nameFile, FileMode.Open, FileAccess.Read);
                    sr = new StreamReader(fs);

                    while (!sr.EndOfStream)//Se recorre el archivo
                        text += (char)sr.Read();
                }
                catch (IOException)
                {
                }
                finally
                {
                    if (sr != null)
                        sr.Close();
                }

                tbGramatica.Text = text;
            }
        }

        private void btCrearExpReg_Click(object sender, EventArgs e)
        {
            CExpresion expAux;

            if (tbGramatica.Text.Length > 0)
            {
                gramaticaReg.setProducciones(tbGramatica.Lines);

                if (gramaticaReg.validate())
                {
                    expAux = new CExpresion();
                    gramaticaReg.creaExpReg();

                    expAux.setExp(gramaticaReg.dameExpRegFinal());
                    tbExpReg.Text = expAux.dameCad(expAux.Simplificate());
                }
                else
                    MessageBox.Show("Gramática incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbLeerPruebas_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                nameFile = openFileDialog1.FileName;
                listaPruebas = new List<List<string>>();
                listaPruebas.Add(new List<string>());
                listaPruebas.Add(new List<string>());
                tbPathPruebasReg.Text = nameFile;
                cargaPruebas();
            }
        }
      
		private void cargaPruebas()
        {
            
            string str1;
            char car;
            int numList = 0;

            str1 = null;

            try
            {
                fs = new FileStream(nameFile, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
                str1 = null;

                while (!sr.EndOfStream)//Se recorre el archivo
                {
                    car = (char)sr.Read();

                    if (car != 10 && car != 13)
                    {
                        if (car != 9)
                            str1 += car;
                        else
                        {
                            listaPruebas[numList].Add(str1);
                            numList++;
                            str1 = null;
                        }
                    }
                    else
                    {
                        if (numList > 0 && str1 != null)
                        {
                            listaPruebas[numList].Add(str1);
                            str1 = null;
                        }

                        numList = 0;
                    }
                }

                if (str1 != null)
                    listaPruebas[numList].Add(str1);

            }
            catch (IOException)
            {
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

            ejecutaPruebas();
        }

        private void ejecutaPruebas()
        {
            CExpresion expAux;
            AFN mS;
            string thompsonRes, thompsonObt;
            int fila;

            expAux = new CExpresion();
            mS = new AFN();

            tablaPruebas.Rows.Clear();
            fila = 0;
            
            for (int i = 0; i < listaPruebas[0].Count; i++)
            {
                tablaPruebas.Rows.Add();
                tablaPruebas.Rows[fila].HeaderCell.Value = fila.ToString();

                tablaPruebas.Rows[fila].Cells[0].Value = (listaPruebas[0])[i];
                for (int j = 1; j < listaPruebas.Count; j++)
                    tablaPruebas.Rows[fila].Cells[j].Value = (listaPruebas[j])[fila];
                
                expAux.setExp(listaPruebas[0][fila]);
                thompsonRes = listaPruebas[1][fila];

                if (expAux.validaExpresion())
                {
                    expAux.normalizate();
                    expAux.Conviertete();
                    mS.setExpPosfija(expAux.getExpPolacaInv());
                    thompsonObt = mS.CreaAFN().creaFormatoThompson();
                    tablaPruebas.Rows[fila].Cells[2].Value = thompsonObt;

                    if(thompsonRes.CompareTo(thompsonObt) == 0)
                        tablaPruebas.Rows[fila].Cells[3].Value = "OK";
                    else
                        tablaPruebas.Rows[fila].Cells[3].Value = "ERROR";
                }
                else
                {
                    tablaPruebas.Rows[fila].Cells[2].Value = "ERROR";
                    tablaPruebas.Rows[fila].Cells[3].Value = "OK";
                }
                
                fila++;
                
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AFN_Thompson.Clases.AFN;

namespace AFN_Thompson.Formularios
{
    public partial class FAutomata : Form
    {
        private Graphics g;
        private Pen pluma;
        private Pen plumaArista;
        private CAutomata thompson;
        private CEstado estadoSelec;
        private Font fuente;
        private Point p1;
        private Point p2;
        private int opc;
        private int dX,dY;
        private int radio;
        private int DX, DY;
        private int tamPluma;
        private int radioFinal;
        private int SX;

        public FAutomata(CAutomata A)
        {
            int xP, yP;

            InitializeComponent();
            thompson = A;
            pluma = new Pen(Color.Blue, A.getEstadoInicial().getAncho());
            plumaArista = new Pen(Color.Red, A.getEstadoInicial().getAncho());
            plumaArista.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            fuente = new Font("Arial", A.getTamEtiqueta(), FontStyle.Bold);
            tamPluma = A.getEstadoInicial().getAncho();
            dX = A.getAncho();
            dY = A.getAlto();
            
            radio = A.getEstadoInicial().getRadio();
            DX = A.getDx();
            DY = A.getDy();
            
            radioFinal = A.getRadioFinal();
            SX = 1;
            
            pictureBox1.Size = new Size(dX+10, dY);
        }

        private void FAutomata_Load(object sender, EventArgs e)
        {
            DibujaAutomata();
        }
        
        private Graphics ObtenerObjectGraphics()
        {
            Bitmap mapaBits = new Bitmap(pictureBox1.Width,pictureBox1.Height);
            Graphics g;

            pictureBox1.Image = mapaBits;
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
 
            foreach (CEstado e in thompson.getListEstados())
            { 
                r = new Rectangle(e.getCentroX() - e.getRadio(), e.getCentroY() - e.getRadio(), e.getRadio() * 2, e.getRadio() * 2);
                g.DrawEllipse(pluma, r);
                
                foreach (CTransicion t in e.getListTransicion())
                {
                    x2 = y2 = 0;
                    if (t.getTipo() == 1)
                    {
                        p = DibujaTransicion(t.getEstadoAct(), t.getEstadoSig(), t.getEtiqueta(),ref pAux);
                        g.DrawLine(plumaArista, t.getEstadoAct().getCentroX(), t.getEstadoAct().getCentroY(),pAux.X, pAux.Y);
                        g.DrawString(t.getEtiqueta(), fuente, Brushes.Black, p.X,p.Y);
                    }
                    else
                    {
                        DibujaTransicion(t.getPuntosControl(), t.getEtiqueta());//Se dibuja una curva
                    }
                }

                g.FillEllipse(new SolidBrush(Color.White), r);//Rellenar el estado
                g.DrawString(e.getNombre().ToString(), fuente, Brushes.Black, e.getCentroX()-DX, e.getCentroY()-DY);
               
                if (e.getEstado().CompareTo("Final") == 0)
                {
                    r = new Rectangle(e.getCentroX() - radioFinal, e.getCentroY() - radioFinal, radioFinal*2, radioFinal*2);
                    g.DrawEllipse(new Pen(Color.Green, tamPluma), r);
                }
            }
            g.Dispose();
        }
       
        private void DibujaTransicion(List<Point> pC, string et)
        {
            CEstado A, B;
            Point[] p = new Point[pC.Count];
            Point pAux = new Point();

            for (int i = 0; i < pC.Count; i++)
                p[i] = pC[i];

            A = new CEstado();
            B = new CEstado();

           // A.setCentro(p[4].X, p[4].Y);
          //  B.setCentro(p[3].X, p[3].Y);
          //  DibujaTransicion(A, B, null, ref pAux);
          //  p[3] = pAux;

            //DrawCurve(plumaArista, p);
            g.DrawBeziers(plumaArista, p);
        }

        private PointF DibujaTransicion(CEstado A, CEstado B,string et,ref Point pAux)
        {
            PointF pAuxB;
            double theta,xP,yP,h,xM,yM;
            int dX, dY,cXA,cYA,cYB,cXB;

            cXA = A.getCentroX();
            cYA = A.getCentroY();
            cXB = B.getCentroX();
            cYB = B.getCentroY();

            dX = cXB-cXA;
            dY = cYB-cYA;

            h = Math.Sqrt(Math.Pow(dX, 2) + Math.Pow(dY, 2));
            theta =  (Math.Atan((double)dY / dX))*180/Math.PI;

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

        private void btAcercar_Click(object sender, EventArgs e)
        {
            double k = (double)pictureBox1.Image.Width / pictureBox1.Image.Height;
            int nuevoAncho = Convert.ToInt32(pictureBox1.Width * 1.25);
            int nuevoAlto = Convert.ToInt32(nuevoAncho / k);
            
            pictureBox1.Width = nuevoAncho;
            pictureBox1.Height = nuevoAlto;
            
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }

        private void btAlejar_Click(object sender, EventArgs e)
        {
            double k;
            int nuevoAlto;
            int nuevoAncho;

            k = (double)pictureBox1.Image.Width / pictureBox1.Image.Height;
            nuevoAncho = Convert.ToInt32(pictureBox1.Width / 1.25);
            nuevoAlto = Convert.ToInt32(nuevoAncho / k);

            pictureBox1.Width = nuevoAncho;
            pictureBox1.Height = nuevoAlto;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Convertidor_de_Expresiones.Clases;
using Convertidor_de_Expresiones;
using AFD_Subconjuntos.Clases.AFN;
using System.IO;
using GramaticasRegulares.Clases.Gramatica;
using AFD_Subconjuntos.Clases;

namespace AFD_Subconjuntos
{
	public partial class Form1 : Form
	{
		private CAutomata thompson;
		private CExpresion expReg;
		private CGramatica gramaticaReg;
		private CAutomata AFD;
		private CSubconjuntos subCon;
		private AFN mS;
		private List<string> alfabeto;
		private List<PictureBox> LP;
		private List<CAutomata> LA;
		private List<List<string>> listaPruebas;
		private CEstado estadoSel;
		private int opc;
		private string nameFile;
		private int autoSelect;
		private FileStream fs;
		private StreamReader sr;
		private CEstado estadoAct;
		private CTransicion tranAct;
		private int nEnt; //Indice de la entrada a analizar como caracter
		private string cadEnt;
		
		//Atributos para el dibujado
		private Graphics pagPrim;
		private Bitmap mapaBits;
		private Graphics g;
		private Pen pluma;
		private Pen plumaArista;
		private Font fuente;
		private Point p1;
		private int radio;
		private int zoom;
		private int dezX;
		private int dezY;
		private int DX;
		private int DY;
		private Panel p;

		public Form1()
		{
			InitializeComponent();

			expReg = new CExpresion();
			mS = new AFN();
			subCon = new CSubconjuntos();
			gramaticaReg = new CGramatica();

			LA = new List<CAutomata>();
			LP = new List<PictureBox>();
			
			pluma = new Pen(Color.Blue, 4);
			plumaArista = new Pen(Color.Red, 3);
			
			plumaArista.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
			fuente = new Font("Arial", 11, FontStyle.Bold);
			zoom = 1;
			radio = 25;
			autoSelect = 0;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			expReg.setExp(tbExpReg.Text);

		    LA.Clear();
			tbCadena.Text = null;
			trackBar1.Value = 75;

			if (p != null)
				tabPage1.Controls.Remove(p);

			if (tbExpReg.Text.Length > 0)
				if (expReg.validaExpresion())
				{
					expReg.normalizate();
					expReg.Conviertete();
					
					alfabeto = expReg.getAlfabeto();
					mS.setExpPosfija(expReg.getExpPolacaInv());

					//Se crea el AFN por las reglas de thompson
					thompson = mS.CreaAFN();
					
					//Se crea el AFD por el algoritmo de Subconjuntos
					subCon = new CSubconjuntos(thompson, alfabeto);
					AFD = subCon.creaAFD();

					LA.Add(thompson);
					LA.Add(AFD);
					cargaAFN();
    				cargaAFD();

					autoSelect = 0;
					pictureThompson.Size = new Size(thompson.getAncho() + 30, thompson.getAlto() + 30);
					DibujaAutomata();
					tabControl1.SelectedIndex = 0;
					autoSelect = 1;
					showAFD();

				}
				else
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

		//Método para crear el arbol del AFD en el Árbol de relación
		private void cargaAFD()
		{
			List<CEstado> lE;
			List<CTransicion> lT;
			TreeNode[] arrayTran;
			TreeNode[] arrayEstados;
			TreeNode[] T;
			TreeNode[] CT;
			string cad;

			lE = AFD.getListEstados();

			T = new TreeNode[1];
			CT = new TreeNode[1];

			arrayEstados = new TreeNode[lE.Count];

			for (int i = 0; i < lE.Count; i++)
			{
				cad = null;
				arrayTran = new TreeNode[lE[i].getListTransicion().Count];
				lT = lE[i].getListTransicion();

				for (int j = 0; j < lT.Count; j++)
				{
					arrayTran[j] = new TreeNode(Convert.ToChar(lT[j].getEstadoSig().getNombre()) + " , " + lT[j].getEtiqueta());
					arrayTran[j].Name = Convert.ToChar(lE[i].getNombre()).ToString();
				}

				if (i == 0)
				{
					cad = " (Inicio ";
					if (lE[i].getEstado().CompareTo("Final") == 0)
						cad += ", Aceptacion ) ";
					else
						cad += ") ";
				}
				else
					if (lE[i].getEstado().CompareTo("Final") == 0)
						cad += "( Aceptacion ) ";
				
				arrayEstados[i] = new TreeNode("q"+(lE[i].getNombre()-65).ToString()+cad, arrayTran);
			}
			
			T[0] = new TreeNode("AFD", arrayEstados);
			CT[0] = new TreeNode("Subconjuntos", T);
			treViewAFN.Nodes.AddRange(CT);
		   
		}

		//Se obtiene un objeto grafics para hacer el dibujado
		private Graphics ObtenerObjectGraphics()
		{
			Graphics g;
			
			if (autoSelect == 0)
			{
				mapaBits = new Bitmap(pictureThompson.Width, pictureThompson.Height);
				pictureThompson.Image = mapaBits;
			}
			else
				mapaBits = new Bitmap(tabPage1.Width + (dezX * -1), tabPage1.Height + (dezY * -1));

			g = Graphics.FromImage(mapaBits);
			g.Clear(Color.White);
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			return (g);
		}

		//Este método se encarga de dibujar el AFN y AFD
		public void DibujaAutomata()
		{
			Rectangle r;
			Point pAux, p0, p3;
			PointF p,pM;
			int x2, y2;

			if (LA.Count > 0)//Se checa que haya autómatas para dibujar
			{
				g = ObtenerObjectGraphics();

				pAux = new Point();
				x2 = LA[autoSelect].getEstadoInicial().getCentroX() - 75;
				y2 = LA[autoSelect].getEstadoInicial().getCentroY();
				g.DrawLine(plumaArista, x2, y2, x2 + 50, y2);
				g.DrawString("Inicio", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, x2, y2 - 20);

				foreach (CEstado e in LA[autoSelect].getListEstados())
				{
					r = new Rectangle(e.getCentroX() - e.getRadio(), e.getCentroY() - e.getRadio(), e.getRadio() * 2, e.getRadio() * 2);
					g.DrawEllipse(pluma, r);

					foreach (CTransicion t in e.getListTransicion())
					{
						if (autoSelect == 0)//Se dibuja el AFN
						{
							if (t.getTipo() == 1)
							{
								p = DibujaTransicion(t.getEstadoAct(), t.getEstadoSig(), t.getEtiqueta(), ref pAux);
								g.DrawLine(t.getPluma(), t.getEstadoAct().getCentroX(), t.getEstadoAct().getCentroY(), pAux.X, pAux.Y);
								g.DrawString(t.getEtiqueta(), fuente, Brushes.Black, p.X, p.Y);
							}
							else
								DibujaTransicion(t.getPuntosControl(), t.getEtiqueta(), t);
						}
						else//Se dibuja el AFD
						{
							p0 = new Point(e.getCentroX(), e.getCentroY());
							p3 = new Point(t.getEstadoSig().getCentroX(), t.getEstadoSig().getCentroY());

							if (t.getTipo() == 1)
							{
								p = obtenerPunto(p0, p3);
								g.DrawLine(t.getPluma(), t.getEstadoAct().getCentroX(), t.getEstadoAct().getCentroY(), p.X, p.Y);
								pM = puntoMedio(p0, p3);
								g.DrawString(t.getEtiqueta(), fuente, Brushes.Black, pM.X, pM.Y);

							}
							else
								if (t.getTipo() == 2)
								{
									DibujaCurvaBezier(g, p0, t.getPoint3Ctrl(), t.getPoint4Ctrl(), p3, t);
									p0 = new Point(Convert.ToInt32(t.getPoint3Ctrl().X), Convert.ToInt32(t.getPoint3Ctrl().Y));
									p3 = new Point(Convert.ToInt32(t.getPoint4Ctrl().X), Convert.ToInt32(t.getPoint4Ctrl().Y));
									pM = puntoMedio(p0, p3);
									g.DrawString(t.getEtiqueta(), fuente, Brushes.Black, pM.X, pM.Y);
								}
								else//Dibujar una Oreja 
									DibujaOreja(g, e, t);
						}
					}

					g.FillEllipse(new SolidBrush(Color.White), r);

					if (autoSelect == 0 || autoSelect == 2)
						g.DrawString(e.getNombre().ToString(), fuente, Brushes.Black, e.getCentroX() - 10, e.getCentroY() - 10);
					else
						g.DrawString("q" + (e.getNombre() - 65), fuente, Brushes.Black, e.getCentroX() - 10, e.getCentroY() - 10);
					
					if (e.getEstado().CompareTo("Final") == 0)
					{
						r = new Rectangle(e.getCentroX() - 20, e.getCentroY() - 20, 40, 40);
						g.DrawEllipse(new Pen(Color.Lime, 3), r);
					}
				}
			
 
    			if (autoSelect > 0 && pagPrim != null)
	   		    {
				   pagPrim.DrawImage(mapaBits, dezX, dezY);
				   g.Dispose();
			    }
		   }
		}

		//Obtiene el punto medio de una linea acotada por los puntos pA y pB
		private PointF puntoMedio(Point pA, Point pB)
		{
			PointF pAux;
			double theta, h, xM, yM;
			int dX, dY;

			dX = pB.X - pA.X;
			dY = pB.Y - pA.Y;

			h = Math.Sqrt(Math.Pow(dX, 2) + Math.Pow(dY, 2));
			theta = (Math.Atan((double)dY / dX)) * 180 / Math.PI;
			xM = Math.Cos((theta * Math.PI) / 180) * h / 2;
			yM = Math.Sin((theta * Math.PI) / 180) * h / 2;

			if (pB.X >= pA.X)
				pAux = new PointF(pA.X + (float)xM - 5, pA.Y + (float)yM);
			else
				pAux = new PointF(pA.X - (float)xM + 5, pA.Y - (float)yM);

			return (pAux);
		}

		//Se dibuja una curva spline cardinal
		private void DibujaTransicion(List<Point> pC, string et, CTransicion t)
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

			g.DrawCurve(t.getPluma(), p, 0);

			x = p[2].X + Convert.ToInt32((p[3].X - p[2].X) / 2);
			y = p[2].Y;
			g.DrawString(et, fuente, Brushes.Black, x, y - 18);
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

		//Método para escalar el autómata AFN, este lo decrementa
		private void AlejaAutomata(object sender, EventArgs e)
		{
			double k;
			int nuevoAlto;
			int nuevoAncho;

			if (thompson != null)
			{

				k = (double)pictureThompson.Image.Width / pictureThompson.Image.Height;
				nuevoAncho = Convert.ToInt32(pictureThompson.Width / 1.25);
				nuevoAlto = Convert.ToInt32(nuevoAncho / k);

				pictureThompson.Width = nuevoAncho;
				pictureThompson.Height = nuevoAlto;

				pictureThompson.SizeMode = PictureBoxSizeMode.StretchImage;
			}
		}

		//Efectua una parte de la escalación para el AFN
		private void AcercaAutomata(object sender, EventArgs e)
		{
			double k;
			int nuevoAlto;
			int nuevoAncho;


			if (thompson != null)
			{
				k = (double)pictureThompson.Image.Width / pictureThompson.Image.Height;
				nuevoAncho = Convert.ToInt32(pictureThompson.Width * 1.25);
				nuevoAlto = Convert.ToInt32(nuevoAncho / k);

				pictureThompson.Width = nuevoAncho;
				pictureThompson.Height = nuevoAlto;

				pictureThompson.SizeMode = PictureBoxSizeMode.StretchImage;
			}
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabControl1.SelectedIndex < 2)
				autoSelect = tabControl1.SelectedIndex;

			if (tabControl1.SelectedIndex == 1)
				groupBox3.Enabled = true;
			else
				groupBox3.Enabled = false;
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
		
	    private PointF PuntosBezier(PointF p0, PointF p1, PointF p2, PointF p3, float t)
		{
			float Ax, Ay, Bx, By, Cx, Cy, Dx, Dy, Px, Py;
			float nt = 1 - t;

			Ax = (float)(p0.X * Math.Pow(nt, 3));
			Bx = (float)(3 * p1.X * t * Math.Pow(nt, 2));
			Cx = (float)(3 * p2.X * t * t * nt);
			Dx = (float)(p3.X * Math.Pow(t, 3));

			Ay = (float)(p0.Y * Math.Pow(nt, 3));
			By = (float)(3 * p1.Y * t * Math.Pow(nt, 2));
			Cy = (float)(3 * p2.Y * t * t * nt);
			Dy = (float)(p3.Y * Math.Pow(t, 3));

			Px = Ax + Bx + Cx + Dx;
			Py = Ay + By + Cy + Dy;

			return (new PointF(Px, Py));
		}

		private void DibujaOreja(Graphics g, CEstado e, CTransicion t)
		{
			PointF p0, p1;
			int xM, yM;

			p0 = new PointF();
			p1 = new PointF();

			p0.X = e.getCentroX() + Convert.ToSingle(e.getRadio() * Math.Cos((double)(Math.PI * 30) / 180));
			p0.Y = e.getCentroY() - Convert.ToSingle(e.getRadio() * Math.Sin((double)(Math.PI * 30) / 180));

			p1.X = e.getCentroX() + Convert.ToSingle(e.getRadio() * Math.Cos((double)(Math.PI * 60) / 180));
			p1.Y = e.getCentroY() - Convert.ToSingle(e.getRadio() * Math.Sin((double)(Math.PI * 60) / 180));

			xM = e.getCentroX() + Math.Abs(Convert.ToInt32(t.getPoint3Ctrl().X - t.getPoint4Ctrl().X));
			yM = e.getCentroY() - Math.Abs(Convert.ToInt32(t.getPoint3Ctrl().Y - t.getPoint4Ctrl().Y));

			g.DrawBezier(t.getPluma(), p0, t.getPoint3Ctrl(), t.getPoint4Ctrl(), p1);
			g.DrawString(t.getEtiqueta(), fuente, Brushes.Black, xM - 20, yM - 6);
		}

		private void DibujaCurvaBezier(Graphics g, Point p0, PointF p1, PointF p2, Point p3,CTransicion t)
		{
			Point[] p = new Point[4];

			p[0] = p0;
			p[1] = new Point((int)p1.X, (int)p1.Y);
			p[2] = new Point((int)p2.X, (int)p2.Y);
			p[3] = obtenerPunto(p[2], p3);

			g.DrawCurve(t.getPluma(), p);
		}

		private Point obtenerPunto(Point pA, Point pB)
		{
			Point pAuxB;
			double theta, xP, yP, h;
			int dX, dY;

			dX = pB.X - pA.X;
			dY = pB.Y - pA.Y;

			h = Math.Sqrt(Math.Pow(dX, 2) + Math.Pow(dY, 2));
			theta = (Math.Atan((double)dY / dX)) * 180 / Math.PI;

			xP = Math.Cos((theta * Math.PI) / 180) * radio;
			yP = Math.Sin((theta * Math.PI) / 180) * radio;

			if (pB.X >= pA.X)
				pAuxB = new Point(pB.X - (int)Math.Round(xP), pB.Y - (int)Math.Round(yP));
			else
				pAuxB = new Point(pB.X + (int)Math.Round(xP), pB.Y + (int)Math.Round(yP));

			return (pAuxB);
		}

		private float calculaDistancia(Point pA, Point pB)
		{
			Point p2 = pB;
			return (float)(Math.Sqrt(Math.Pow(Math.Abs(pA.X - p2.X), 2) + Math.Pow(Math.Abs(pA.Y - p2.Y), 2)));
		}

		private void pictureAFD_MouseDown(object sender, MouseEventArgs e)
		{
			p1 = e.Location;

			if (e.Button == MouseButtons.Left)
			{
				if (opc == 1 || opc == 2)//Mover un estado
					seleccionarVert();
			}
		}

		private void seleccionarVert()
		{
			foreach (CEstado v in LA[autoSelect].getListEstados())
			{
				if (calculaDistancia(p1, new Point(v.getCentroX(), v.getCentroY())) <= radio)
				{
					estadoSel = v;
					break;
				}
			}
		}

		private void moverEsatdoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			opc = 1;
		}

		private void pictureAFD_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (estadoSel != null && zoom == 1)
				{
					if (opc == 1)
						mueveEstado(e.Location);
					else
						mueveGrafo(e.Location);

					DibujaAutomata();
				}
			}
		}

		private void mueveEstado(Point pNew)
		{
			int x, y;

		    x = estadoSel.getCentroX() + (pNew.X - p1.X);
			y = estadoSel.getCentroY() + (pNew.Y - p1.Y);

			p1 = pNew;
			estadoSel.setCentro(x, y);
			LA[autoSelect].ActulizaPtsCtrl(estadoSel);
		}

		private void mueveGrafo(Point pNew)
		{
			int x, y;

			foreach (CEstado v in LA[autoSelect].getListEstados())
			{
				x = v.getCentroX() + (pNew.X - p1.X);
				y = v.getCentroY() + (pNew.Y - p1.Y);
				
				v.setCentro(x, y);
				LA[autoSelect].ActulizaPtsCtrl(v);
			}
			p1 = pNew;
		}

		private void moverAutómataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			opc = 2;
		}

		private void pictureAFD_MouseUp(object sender, MouseEventArgs e)
		{
			estadoSel = null;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			DX = pictureThompson.Width;
			DY = pictureThompson.Height;
		}

		private void tbLeerPruebas_Click_1(object sender, EventArgs e)
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

		//Ejecuta todas las pruebas leidas del archivo pruebas de Regresion y las compara con el algoritmo.
		private void ejecutaPruebas()
		{
			CExpresion expAux;
			CAutomata afd,afn;
			CSubconjuntos sub;
			AFN mS;
			
			string afdRes, afdObt;

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
				afdRes = listaPruebas[1][fila];

				if (expAux.validaExpresion())
				{
					expAux.normalizate();
					expAux.Conviertete();
					mS.setExpPosfija(expAux.getExpPolacaInv());
					afn = mS.CreaAFN();
					sub = new CSubconjuntos(afn,expAux.getAlfabeto());
					afd = sub.creaAFD();
					afdObt = afd.creaFormatoAutomata();

					tablaPruebas.Rows[fila].Cells[2].Value = afdObt;
					
					if(afdRes.CompareTo(afdObt) == 0)
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
		
		//Iniciliza el dibuja del AFD.
		private void showAFD()
		{
			p = new Panel();

			tabPage1.VerticalScroll.Value = 0;
			dezX = dezY = 0;
			p.Size = new Size(1, 1);
			p.Location = new Point(AFD.getAncho() + 30, AFD.getAlto() + 30);

			tabPage1.Controls.Add(p);

			pagPrim = tabPage1.CreateGraphics();
			mapaBits = new Bitmap(tabPage1.Width, tabPage1.Height);

			DibujaAutomata();
		}

		private void tabPage1_Paint(object sender, PaintEventArgs e)
		{
			DibujaAutomata();
		}

		private void tabPage1_MouseDown(object sender, MouseEventArgs e)
		{
			p1 = new Point(e.X - dezX, e.Y - dezY);

			if (e.Button == MouseButtons.Left)
			{
				if (opc == 1 || opc == 2)//Mover un estado
					seleccionarVert();
			}
		}

		//Método para mover el autómata
		private void tabPage1_MouseMove(object sender, MouseEventArgs e)
		{
			Point pN;

			if (e.Button == MouseButtons.Left)
				if (estadoSel != null)
				{
					pN = new Point(e.X - dezX, e.Y - dezY);
					if (opc == 1)
						mueveEstado(pN);
					else
						mueveGrafo(pN);

					tabPage1_Paint(tabPage1, null);
				}
		}

		private void tabPage1_Scroll(object sender, ScrollEventArgs e)
		{
			if (e.NewValue != 0)
				if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
					dezX = -e.NewValue;
				else
					dezY = -e.NewValue;
		}

		private void trackBar1_ValueChanged(object sender, EventArgs e)
		{
			timer1.Interval = 10 * trackBar1.Value;
		}

		//Activa el temporizador para hacer la simulación
		private void btEjecutarSim_Click(object sender, EventArgs e)
		{
			if (LA.Count > 0)
			{
                btEjecutarSim.Enabled = false;
                cadEnt = tbCadena.Text;
				nEnt = 0;
				estadoAct = LA[autoSelect].getEstadoInicial();
				tranAct = null;
				timer1.Start();
			}
		}

		//En este método se lleva a cabo la simuación de análisis para un cadena de entrada
		private void timer1_Tick(object sender, EventArgs e)
		{
			Console.Beep();
			string c;
			bool band;

			if (nEnt == cadEnt.Length)//Se lle cada caractere de la cadena
			{
				timer1.Stop();

				if (estadoAct.getEstado().CompareTo("Final") == 0)
					MessageBox.Show("Cadena válida", "Cadena", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				else
					MessageBox.Show("Cadena inválida", "Cadena", MessageBoxButtons.OK, MessageBoxIcon.Error);

				if (tranAct != null)
				{
					tranAct.setColorPluma(Color.Red);
					tranAct.setTamPluma(4);
                } 
                
                btEjecutarSim.Enabled = true;
            }
			else
			{
				if (tranAct != null)
				{
					tranAct.setColorPluma(Color.Red);
					tranAct.setTamPluma(4);
				}
				
				band = false;

				//Para el estado actual se verifica que exista un transición con la entrada de la cadena
				foreach (CTransicion t in estadoAct.getListTransicion())
				{
					c = cadEnt[nEnt].ToString();

					if (cadEnt[nEnt] == 32)
						c = "\\e";

					if (t.getEtiqueta().CompareTo(c) == 0)
					{
						t.setColorPluma(Color.Blue);
						t.setTamPluma(7);
						tranAct = t;
						estadoAct = t.getEstadoSig();
						band = true;
						break;
					}
				}

				if (!band)
				{
					timer1.Stop();
					MessageBox.Show("Cadena inválida", "Cadena", MessageBoxButtons.OK, MessageBoxIcon.Error);

					if (tranAct != null)
					{
						tranAct.setColorPluma(Color.Red);
						tranAct.setTamPluma(4);
					}
                    btEjecutarSim.Enabled = true;
				}
				else
					nEnt++;

			}

			tabPage1_Paint(tabPage1, null);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AFD_Subconjuntos.Clases.AFN
{
   //Esta clase se utiliza para el manejo de las transiciones en un Automata
    public class CTransicion
    {
        //Atributos
        private List<Point> puntosControl;//Puntos de control para las curvas
        private List<CEtiqueta> listaEtiquetas;
        private CEstado estadoAct;
        private CEstado estadoSig;
        private PointF p3;
        private PointF p4;
        private CEstado vO;
        private CEstado vD;
        private Pen pluma;
        private float altura;
		private bool visitada;
        private int tipoTranscion;//1-> Recta. 2->Curva  3.->Oreja
        private string etiqueta;  

        //Constructor
        public CTransicion() 
        {
            listaEtiquetas = new List<CEtiqueta>();
        }

        public CTransicion(CEstado eA, CEstado eS, string e, List<Point> pC)
        {
            setEstadoAct(eA);
            setEstadoSig(eS);
            setEtiqueta(e);
            tipoTranscion = 2;
            puntosControl = pC;
			pluma = new Pen(Color.Red, 4);
			pluma.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            listaEtiquetas = new List<CEtiqueta>();
            listaEtiquetas.Add(new CEtiqueta(e, 0, 0));
		}
        
        public CTransicion(CEstado eA, CEstado eS, string e)
        {
            tipoTranscion = 1;
            setEstadoAct(eA);
            setEstadoSig(eS);
            setEtiqueta(e);
			pluma = new Pen(Color.Red, 4);
			pluma.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            listaEtiquetas = new List<CEtiqueta>();
            listaEtiquetas.Add(new CEtiqueta(e,0,0));
		}
        
        //Interfaz publica

		public Pen getPluma()
		{
			return (pluma);
		}

		public void setColorPluma(Color c)
		{
			pluma.Color = c;
		}

		public void setTamPluma(int t)
		{
			pluma.Width = t;
		}

		public void setAltura(float nueva)
        {
            altura = nueva;
        }

        public float getAltura()
        {
            return (altura);
        }
        public void setVO(CEstado nO)
        {
            this.vO = nO;
        }

        public CEstado getVO()
        {
            return (vO);
        }

        public void setVD(CEstado nD)
        {
            this.vD = nD;
        }

        public CEstado getVD()
        {
            return (vD);
        }

        public void setPoint3Ctrl(PointF p)
        {
            p3 = p;
        }

        public PointF getPoint3Ctrl()
        {
            return (p3);
        }

        public void setPoint4Ctrl(PointF p)
        {
            p4 = p;
        }

        public PointF getPoint4Ctrl()
        {
            return (p4);
        }

        public void setEstadoAct(CEstado eA)
        {
            this.estadoAct = eA;
        }

        public int getTipo()
        {
            return (this.tipoTranscion);
        }

        public List<Point> getPuntosControl()
        {
            return (this.puntosControl);
        }

        public CEstado getEstadoAct()
        {
            return (this.estadoAct);
        }

        public void setEstadoSig(CEstado eS)
        {
            this.estadoSig = eS;
        }

        public CEstado getEstadoSig()
        {
            return (this.estadoSig);
        }

        public void setEtiqueta(string e)
        {
            this.etiqueta = e;
        }

        public string getEtiqueta()
        {
            return (this.etiqueta);
        }

        public void setTipo(int t)
        {
            tipoTranscion = t;
        }

        public void setPtsControl(List<Point> pts)
        {
            puntosControl = pts;
        }

		public void ActEtiqueta(string cad)
		{
			etiqueta += cad;
		}

		public void setVisitado(bool v)
		{
			this.visitada = v;
		}

		public bool getVisitada()
		{
			return (this.visitada);
		}

        public void ActCooorEtiqueta(int xN, int yN)
        {
            foreach(CEtiqueta e in listaEtiquetas)
            {
                e.setPosX(xN);
                e.setPosY(yN);
                xN += 15;
            }
        }
        
        public List<CEtiqueta> getListEtiquetas()
        {
            return (listaEtiquetas);
        }

        public void AddEtiqueta(CEtiqueta e)
        {
            listaEtiquetas.Add(e);
        }
    }

    public class CEtiqueta
    {
        private string nombre;
        private int posX;
        private int posY;
        private Brush brocha;
        private Font fuente;

        public CEtiqueta()
        {
            brocha = Brushes.Black;
            fuente = new Font("Arial", 11, FontStyle.Bold);
        }

        public CEtiqueta(string nombre, int posX, int posY)
        {
            this.nombre = nombre;
            this.posX = posX;
            this.posY = posY;
            brocha = Brushes.Black;
            fuente = new Font("Arial", 11, FontStyle.Bold);
        }

        public void setFontEt(Font nueva)
        {
            this.fuente = nueva;
        }

        public Font getFuente()
        {
            return (fuente);
        }
        
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public string getNombre()
        {
            return (nombre);
        }

        public void setPosX(int x)
        {
            this.posX = x;
        }

        public int getPosX()
        {
            return (posX);
        }

        public void setPosY(int y)
        {
            this.posY = y;
        }

        public int getPosY()
        {
            return (posY);
        }

        public void setBrocha(Brush brocha)
        {
            this.brocha = brocha;
        }

        public Brush getBrocha()
        {
            return (brocha);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AFD_Subconjuntos.Clases.AFN
{
    //Esta clase se utliza para representar un estado en un Autómata
    public class CEstado
    {
        //Propiedades de la estructura
        private List<CTransicion> listTransiciones;
        private List<CEstado> listaDeEstados;//Esta lista se utiliza para la construccion del AFD apartir del Thompson
        private int nombre;
        private string estado;//{ Inicial, Normal, Aceptacion|Final }
        private bool visitado;

        //Propiedades para el trazado
        private Color color;
        private int cX;
        private int cY;
        private int ancho;
        private int radio;

        //Constructores
        public CEstado() { }
        
        public CEstado(int name, string estado)
        {
            listTransiciones = new List<CTransicion>();
            this.nombre = name;
            this.estado = estado;
            this.visitado = false;
            radio = 25;
            ancho = 4;
        }

        public void setCentro(int x, int y)
        {
            cX = x;
            cY = y;
        }

        public int getCentroX()
        {
            return (cX);
        }

        public int getCentroY()
        {
            return (cY);
        }

        //Interfaz pública
        public void setListaEstados(List<CEstado> CE)
        {
            this.listaDeEstados = CE;
        }

        public int getAncho()
        {
            return (this.ancho);
        }

        public void setAncho(int n)
        {
            this.ancho = n;
        }

        public List<CEstado> getListaEstados()
        {
            return (this.listaDeEstados);
        }

        public void setNombre(int name)
        {
            this.nombre = name;
        }

        public int getNombre()
        {
            return(this.nombre);
        }

        public void setEstado(string nuevo)
        {
            this.estado = nuevo;
        }

        public string getEstado()
        {
            return (this.estado);
        }

        public void setColor(Color color)
        {
            this.color = color;
        }

        public Color getColor()
        {
            return (this.color);
        }

        public void setRadio(int radio)
        {
            this.radio = radio;
        }

        public int getRadio()
        {
            return (this.radio);
        }

        public void setVisitado(bool v)
        {
            this.visitado = v;
        }

        public bool getVisitado()
        {
            return (this.visitado);
        }
        
        public void AddTransicion(CTransicion nueva)
        {
            listTransiciones.Add(nueva);
        }

        public List<CTransicion> getListTransicion()
        {
            return (this.listTransiciones);
        }

    }
}





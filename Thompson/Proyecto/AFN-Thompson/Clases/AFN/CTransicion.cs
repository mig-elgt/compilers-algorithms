using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AFN_Thompson.Clases.AFN
{
   //Esta clase se utiliza para el manejo de las transiciones en un Automata
    public class CTransicion
    {
        //Atributos
        private CEstado estadoAct;
        private CEstado estadoSig;
        private string etiqueta;
        private List<Point> puntosControl;//Puntos de control para las curvas
        private int tipoTranscion;//1-> Recta. 2->Curva

        //Constructor
        public CTransicion() { }

        public CTransicion(CEstado eA, CEstado eS, string e,List<Point> pC)
        {
            setEstadoAct(eA);
            setEstadoSig(eS);
            setEtiqueta(e);
            tipoTranscion = 2;
            puntosControl = pC;
        }
        
        public CTransicion(CEstado eA, CEstado eS, string e)
        {
            tipoTranscion = 1;
            setEstadoAct(eA);
            setEstadoSig(eS);
            setEtiqueta(e);
        }
        
        //Interfaz publica
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
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AFN_Thompson.Clases.AFN
{
    //Esta clase es utlizada para representar un automata. En este caso el AFN 
    public class CAutomata
    {
        private List<CEstado> listEstados;
        private CEstado estadoInicial;
        private CEstado estadoFinal;
        private int inc;
        private int cont;

        //Atributos para el trazado
        private Rectangle rectBase;//Define las dimenciones del Automata.
        private int ancho;
        private int alto;
       
        public CAutomata() 
        {
            listEstados = new List<CEstado>();
        }

        public Rectangle getContorno()
        {
            return (rectBase);
        }

        public void setRect(Rectangle r)
        {
            this.rectBase = r;
            ancho = r.Width;
            alto = r.Height;
        }

        public void AddEstado(CEstado nuevo)
        {
            listEstados.Add(nuevo);
        }

        //Insertar un nueva transición en un estado
        public void InsTransicion(CEstado eI, CEstado eF, string t, List<Point> pC)
        {
            eI.AddTransicion(new CTransicion(eI, eF, t, pC));
        }

        public void InsTransicion(CEstado eI, CEstado eF, string t)
        {
            eI.AddTransicion(new CTransicion(eI, eF, t));
        }

        public void setEstadoInicial(CEstado eI)
        {
            this.estadoInicial = eI;
        }

        public CEstado getEstadoInicial()
        {
            return(this.estadoInicial);
        }

        public void setEstadoFinal(CEstado eF)
        {
            this.estadoFinal = eF;
        }

        public CEstado getEstadoFinal()
        {
            return (this.estadoFinal);
        }

        public void cambiaEstados()
        {
            estadoInicial.setEstado("Normal");
            estadoFinal.setEstado("Normal");
        }

        public void setInc(int i)
        {
            this.inc = i;
        }

        public int getInc()
        {
            return (this.inc);
        }

        public void setCont(int c)
        {
            this.cont = c;
        }

        public int getCont()
        {
            return (this.cont);
        }

        //Esta método se encarga de establecer los nombres de los estados
        public void RP(CEstado e)
        {
            e.setVisitado(true);
            e.setNombre(e.getNombre() + getInc());
            cont++;

            foreach (CTransicion t in e.getListTransicion())
                if (!t.getEstadoSig().getVisitado() &&
                          t.getEstadoSig().getEstado().CompareTo("Final") != 0)
                    RP(t.getEstadoSig());
            
        }

        //Se actualiza el nombre del estado al aplicar una regla de thompson
        public void IncEstado(int inc)
        {
            this.inc = inc;
            this.cont = inc;

            RP(getEstadoInicial());

            foreach (CEstado E in listEstados)
                E.setVisitado(false);
        }

        public List<CEstado> getListEstados()
        {
            return (this.listEstados);
        }

        public void AddAutomata(CAutomata A)
        {
            foreach (CEstado e in A.getListEstados())
                this.listEstados.Add(e);
        }

        public void Ordenate()
        {
            OrdenaEstados_Quisksort(listEstados);
        }

        private void OrdenaEstados_Quisksort(List<CEstado> Q)
        {
            Quicksort_Recursivo(Q, 0, Q.Count - 1);
        }

        private void Quicksort_Recursivo(List<CEstado> Q, int ini, int fin)
        {
            CEstado estadoAux;
            int izq, der, pos;
            bool band;

            estadoAux = null;
            pos = izq = ini;
            der = fin;
            band = true;

            while (band)
            {
                band = false;

                while ((Q[pos].getNombre() <= Q[der].getNombre()) && (pos != der))
                    der--;

                if (pos != der)
                {
                    estadoAux = Q[pos];
                    Q[pos] = Q[der];
                    Q[der] = estadoAux;
                    pos = der;

                    while ((Q[pos].getNombre() >= Q[izq].getNombre()) && (pos != izq))
                        izq++;

                    if (pos != izq)
                    {
                        band = true;
                        estadoAux = Q[pos];
                        Q[pos] = Q[izq];
                        Q[izq] = estadoAux;
                        pos = izq;
                    }
                }
            }

            if ((pos - 1) > ini)
                Quicksort_Recursivo(Q, ini, pos - 1);

            if (fin > (pos + 1))
                Quicksort_Recursivo(Q, pos + 1, fin);
        }

        /*Método para trasladar los estados de un automata, este método es incovado al cuando
         * se hace la construcción del AFN, al momento de establecer las coordenadas al los estados
         */
        public void trasladate(int dx, int dy)
        {
            foreach (CEstado e in listEstados)
            {
                e.setCentro(e.getCentroX() + dx, e.getCentroY() + dy);
                foreach (CTransicion t in e.getListTransicion())
                    if (t.getTipo() == 2 && t.getPuntosControl() != null)
                        for (int i = 0; i < t.getPuntosControl().Count; i++)
                            t.getPuntosControl()[i] = new Point(t.getPuntosControl()[i].X + dx, t.getPuntosControl()[i].Y + dy);
            }
        }
        
        public int getAncho()
        {
            return (ancho);
        }

        public int getAlto()
        {

            return (alto);
        }
        
        public void getEstados(List<CEstado> eN, List<CEstado> eA)
        {
            foreach (CEstado e in listEstados)
                if (e.getEstado().CompareTo("Normal") == 0)
                    eN.Add(e);
                else
                    eA.Add(e);
        }

        public CEstado buscaEstado(string name)
        {
            CEstado est = null;

            foreach(CEstado e in listEstados)
                if (e.getNombre().ToString().CompareTo(name) == 0)
                {
                    est = e;
                    break;
                }

            return (est);
        }

        //Este método no entrega un cadena que representa el AFN, es utilizado en las pruebas de regresión.
        public string creaFormatoThompson()
        {
            string T = null;

            foreach (CEstado e in listEstados)
            {
                T += "<"+ e.getNombre().ToString();
                
                if (e.getEstado().CompareTo("Inicial") == 0)
                    T += "i";
                else
                    if (e.getEstado().CompareTo("Final") == 0)
                        T += "a";

                T += ">";

                if (e.getListTransicion().Count > 0)
                {
                    foreach (CTransicion t in e.getListTransicion())
                        T += t.getEstadoSig().getNombre().ToString() + t.getEtiqueta() + ",";

                    T = T.Remove(T.Length - 1, 1);
                }

            }

            return (T);
        }
    }
}

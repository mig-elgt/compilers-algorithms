using System;
using System.Collections.Generic;
using System.Text;

namespace GramaticasRegulares.Clases.Gramatica
{
    /*
     * Esta clase es utizada para representar una producción de la gramatica. Cuenta con los métodos
     * de reducción y sustitución, que son llamados cuando ejecuta el algoritmo, para crear la expresión 
     * regular*/
    class CEcuacion
    {
        private string namePro; //Identifica el nombre de una produccion,esto es un No terminal
        private List<CTermino> listTerminos; //Lista de terminos de la ecuación o produccion

        public CEcuacion()
        {
            creaListTerm();
        }

        public CEcuacion(string nP) 
        {
            this.namePro = nP;
            creaListTerm();
        }

        public void addTermino(string c, string v)
        {
            listTerminos.Add(new CTermino(c, v));
        }

        public void setNamePro(string cad)
        {
            this.namePro = cad;
        }

        public string getNamePro()
        {
            return (this.namePro);
        }

        public List<CTermino> getListTerm()
        {
            return (this.listTerminos);
        }
        
        private void creaListTerm()
        {
            listTerminos = new List<CTermino>();
        }

        /*
         *Este método factoriza solamente los no terminales de alguna producción, el resto de la
         * expresión regular osea la parte terminal se queda intacta*/
        public void factorizate()
        {
            CTermino t, t2;
            List<object> L;
            string cad;
            int i,j;
            
            i = 0;

            do
            {
                t = listTerminos[i];
                cad = t.getCoef();

                L = new List<object>();
                for (j = i + 1; j < listTerminos.Count; j++)
                {
                    t2 = listTerminos[j];
                    if (t2.getVar() != null && t2.getVar().CompareTo(t.getVar()) == 0)
                    {
                        cad += "|" + t2.getCoef();
                        L.Add(t2);
                    }
                }

                if (L.Count != 0)
                {
                    for (int z = 0; z < L.Count; z++)
                        listTerminos.Remove((CTermino)L[z]);
                   
                    t.setCoef("(" + cad + ")");
                }

                i++;
            
            } while (i < listTerminos.Count);
        }

        /*
         * Este método se encarga de reducir una producción. Primero se factorizan los no terminales si los hay
         * y porteriormente se busca la forma Xi = alphaXi|phi para porder hacer la reducción*/
        public bool reducete()
        {
            bool res;
            int i;
            string c;

            res = false;

            /* Busca si existe por lo menos un no terminal en la ecuación 
             * identico al Xi de la produccion*/
            for( i = 0; i < listTerminos.Count; i++)
                if(namePro.CompareTo(listTerminos[i].getVar()) == 0)
                    break;

            if( i < listTerminos.Count )
            {
                factorizate();
                c = "{" + listTerminos[i].getCoef() + "}";//Termino alpha

                if (listTerminos.Count > 1)
                {
                    listTerminos.RemoveAt(i);

                    //Agrega la cadena de recursión para todos los terminos
                    for (int w = 0; w < listTerminos.Count; w++)
                        listTerminos[w].addRecursion(c);
                }
                else
                {
                    listTerminos[0].setCoef(c);
                    listTerminos[0].setVar(null);
                }
                res = true;
            }
            
            return (res);
        }

        public bool sustituye(CEcuacion xi)
        {
            bool res;
            int i;
            CTermino t,nuevo;

            res = false;
            t = null;

            //Busca si existe alguno no terminal para ser sustituido por xi
            for ( i = 0; i < listTerminos.Count; i++)
                if (listTerminos[i].getVar() != null && listTerminos[i].getVar().CompareTo(xi.getNamePro()) == 0)
                {
                    t = listTerminos[i];
                    break;
                }

            if (i < listTerminos.Count)//si existe un no terminal
            {
                factorizate();
                i = listTerminos.IndexOf(t);

                for (int w = xi.getListTerm().Count - 1; w >= 0; w--)
                {
                    nuevo = new CTermino();
                    nuevo.setCoef(t.getCoef() + xi.getListTerm()[w].getCoef());
                    nuevo.setVar(xi.getListTerm()[w].getVar());
                    listTerminos.Insert(i + 1, nuevo);
                }
                listTerminos.RemoveAt(i);
                factorizate();
                res = true;
            }
            
            return(res);
        }

        public string dameExpresion()
        {
            string exp;

            exp = listTerminos[0].getCoef() + listTerminos[0].getVar();

            for (int i = 1; i < listTerminos.Count; i++)
                exp += "|" + listTerminos[i].getTermino();
            
            return (exp);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GramaticasRegulares.Clases.Gramatica
{
    /*
     * Esta clase se utiliza para representar un t�rmino de una ecuaci�n.
     * Es decir de una producci�n. Los terminos de la ecuaci�n son muy similares 
     * a los terminos de una ecuacion algebraica. Donde el coeficiente de la variable es una 
     * expresi�n regular y la variable es un No terminal de la gramatica especificada.
     * 
     * Dada la siguiente producci�n.
     * 
     * S -> aB|bC
     * 
     * Esta producci�n se puede interpretar como una ecuaci�n de la siguiente forma.
     * 
     * S = aB + bC
     * 
     * Para aB
     *    Siendo "a" el Coeficiente de la variable B donde "a" es una expresion regular y B
     *    un elemento No terminal del conjunto de los No Terminales de la gramatica.
     */
    class CTermino
    {
        private string coef;// Representa una expresi�n regular
        private string var; // Representa un No Temrinal

        public CTermino() { }

        public CTermino(string c, string v)
        {
            this.coef = c;
            this.var = v;
        }

        public void setCoef(string c)
        {
            this.coef = c;
        }

        public string getCoef()
        {
            return (this.coef);
        }

        public void setVar(string v)
        {
            this.var = v;
        }

        public string getVar()
        {
            return (this.var);
        }

        public void addRecursion(string r)
        {
            coef = r + coef;
        }

        public string getTermino()
        {
            return (coef + var);
        }
    }
}

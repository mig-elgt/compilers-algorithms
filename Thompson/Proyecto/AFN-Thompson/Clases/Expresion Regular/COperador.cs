using System;
using System.Collections.Generic;
using System.Text;

namespace Convertidor_de_Expresiones.Clases
{
    class COperador : CToken
    {
        /* Jerarqu�a del operadores
         * 
         * 1: Cuantificadores ( * , +, ? )
         * 2: Concatenaci�n ( . )
         * 3: Selecci�n de alternativas ( | )
         * 
         */

        private int jerarquia;

        public COperador() { }

        //Se crea un objeto operador, inicializando sus atributos, heredados por la clase Token
        public COperador(int t, string s, int j) : base(t, s) 
        {
            setJerarquia(j);
        }

        public void setJerarquia(int j)
        {
            jerarquia = j;
        }

        public int getJerarquia()
        {
            return (jerarquia);
        }
    
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Convertidor_de_Expresiones
{
    class CToken
    {
        private int tipo; //Tipo 1.- Operador. 2.- Par izq  3.- Par der 4.- Operando(Num/Letra)
        private string cad; //Representa un elemnto de la expresion infija

        public CToken() { }

        public CToken(int tipo, string cad)
        {
            setTipo(tipo);
            setSimbolo(cad);
        }

        public void setTipo(int t)
        {
            this.tipo = t;
        }
        
        public int getTipo()
        {
            return (tipo);
        }

        public void setSimbolo(string s)
        {
            this.cad = s;
        }

        public string getSimbolo()
        {
            return (cad);
        }
    }
}

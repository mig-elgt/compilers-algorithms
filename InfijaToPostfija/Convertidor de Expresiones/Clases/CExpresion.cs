using System;
using System.Collections.Generic;
using System.Text;


namespace Convertidor_de_Expresiones.Clases
{
    class CExpresion
    {
        private List<CToken> listaTokens;//Almacena los tokens creados en la expresión
        private Stack<object> pila;//Pila de objetos utilizada en el algoritmo de conversión
        private string expInfija;//Representa la expresion infija a convertir
        private string expPosfija;//Expresion posfija generada
        private const int OPERADOR = 1;
        private const int PAR_IZQ = 2;
        private const int PAR_DER = 3;
        private const int OPERANDO = 4;
        private int numPar;//Numero de parentesis en la expresion
        private int numOperadores;
        private int numOperandos;

        public CExpresion()
        {
        }

        public void setExp(string cad)
        {
            expInfija = cad;//Se establece la expresion a convertir en el objeto expresión.
        }

        public string Conviertete()
        {
            string cad = "ERROR";

            if (generaTokens())//Si la generación de tokens fue correcta entonces es momento de hacer la conversión
            {
                ConverToPosfija();
                return (expPosfija);
            }
            
            return (cad);
        }
        
        /*
         * Esta método se encraga de separar la expresión en sus elementos que la forman
         * Operador, operandos, (,), y crea un objeto por cada uno de ellos de la clase CToken.
         * A cada objeto se le denomino token de la expresion, donde todos los token creados 
         * se almacenaran en una lista, para llevar a cabo el proceso de conversion.
         * */
        private bool generaTokens()
        {
            CToken token;
            bool res;
            int i;
            
            res = true;
            listaTokens = new List<CToken>();
            numOperadores = numOperandos = numPar = 0;

            for (i = 0; i < expInfija.Length && res; i++)//Se recorre la cadena que contiene la expresión infija
                if (expInfija[i] != 32)//Los espacios son omitidos
                {
                    token = creaToken(ref i);//Si el token generado por esta funcion no es permito se cancela el proceso y regresa un valor indicando el resultado
                    if (token.getSimbolo().Length == 1)
                    {
                        if (token.getTipo() >= 1 && token.getTipo() <= 3)
                            listaTokens.Add(token);
                        else
                            if (Char.IsLetterOrDigit(token.getSimbolo()[0]))
                            {
                                listaTokens.Add(token);
                                numOperandos++;
                            }
                            else
                                res = false;
                    }
                    else
                       res = false;
                }

            if (res)
                res = validaExpresion();

            return (res);
        }

        /*
         * En este método, validamos si el numero de parentesis es correcto asi como
         * el orden de los operadores.
         * Regresa un valor booleando indica el resultado*/
        private bool validaExpresion()
        {
            bool band = false;

            //Se verifica que por cada operador haya dos operandos entre este
            if (numOperadores + 1 == numOperandos && numPar == 0)
            {
                band = true;
                for (int i = 0; i < listaTokens.Count; i++)//Se analiza la posición de cada parentesis
                    if (listaTokens[i].getTipo() == 2)//Si es un parentesis
                    {
                        if (i > 0 && i < listaTokens.Count - 1)
                            if (listaTokens[i - 1].getTipo() == 4 || listaTokens[i + 1].getTipo() == 1 || listaTokens[i + 1].getTipo() == 3)
                                return (false);
                        
                        if (i == listaTokens.Count - 1)
                            return (false);
                    }
                    else
                        if (listaTokens[i].getTipo() == 3)
                        {
                            if (i > 0 && i < listaTokens.Count - 1)
                                if (listaTokens[i - 1].getTipo() == 1 || listaTokens[i +1].getTipo() == 4 || listaTokens[i - 1].getTipo() == 2 )
                                    return (false);
                            
                            if (i == 0)
                                return (false);
                        }
            }
            return (band);
        }

        /*
         * Esta funcíón es encargada de crear un token. Para ello
         * checa el tipo de caracter y los clasifa segun su tipo, en el caso
         * de un operador, aparte de asignarle un  tipo, establece una prioridad, como
         * parte de su atrbuto, esta prioridad sera de utilizad en el algoritmo de
         * conversion*/
        private CToken creaToken(ref int index)
        {
            CToken nuevo;
            string cad = null;
            int tipo , jerarquia;
            char s = expInfija[index];

            if (((s >= 40 && s <= 43) || s == 47 || s == 45 || s == 94)) //Operadores
            {
                tipo = 1; jerarquia = 0;
                switch (s)
                {
                    case '^': jerarquia = 3; numOperadores++; break;
                    case '/':
                    case '*': jerarquia = 2; numOperadores++; break;
                    case '+':
                    case '-': jerarquia = 1; numOperadores++; break;
                    case '(': tipo = 2; numPar++; break;
                    case ')': tipo = 3; numPar--; break;
                }
                return (new COperador(tipo, s.ToString(), jerarquia));//Creacion del operador
            }
            else
            {
                //En caso de que hay un operando como una palabra o mas de un simbolo
                while ((index != expInfija.Length) && ((s < 40 || s > 43) && s != 47 && s != 45 && s != 94))
                {
                    if (s != 32)
                        cad += s.ToString();

                    index++;

                    if (index < expInfija.Length)
                        s = expInfija[index];
                }
                index--;
                nuevo = new CToken(4, cad);

            }

            return (nuevo);
         }

        /*
         * Algoritmo para convertir una expresion infija, almacenada en una lista de tokens
         * a una expresión posfija.
         * Este metodo es llamado por el objeto expresion creado previamente, una ves que la expresion
         * este escrita correctamente.*/
        private void ConverToPosfija()
        {
            pila = new Stack<object>();
            expPosfija = null;

            foreach (CToken t in listaTokens)//Reccorremos cada uno de los tokens y analisamos su tipo
            {
                switch (t.getTipo())
                { 
                    case PAR_IZQ:
                        pila.Push(t);
                    break;
                    case PAR_DER:
                        while (((CToken)pila.Peek()).getTipo() != PAR_IZQ)
                            expPosfija += ((CToken)pila.Pop()).getSimbolo();

                        pila.Pop();
                    break;
                    case OPERANDO:
                        expPosfija += t.getSimbolo();
                    break;
                    default://Operador
                        while (pila.Count > 0 && ((CToken)(pila.Peek())).getTipo() == OPERADOR &&
                              ((COperador)t).getJerarquia() <= ((COperador)pila.Peek()).getJerarquia())
                                expPosfija += ((CToken)pila.Pop()).getSimbolo();
                        pila.Push(t);
                    break;
                }
            }

            while (pila.Count > 0)
                expPosfija += ((CToken)pila.Pop()).getSimbolo();
        }
    }
}

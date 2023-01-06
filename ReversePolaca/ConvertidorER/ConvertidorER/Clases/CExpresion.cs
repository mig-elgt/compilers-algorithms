using System;
using System.Collections.Generic;
using System.Text;


namespace Convertidor_de_Expresiones.Clases
{
    class CExpresion
    {
        private List<CToken> listaTokens;//Almacena los tokens creados en la expresión
        private Stack<object> pila;//Pila de objetos utilizada en el algoritmo de conversión
        private string expRegular;//Representa la expresion infija a convertir
        private string expNorma; // Expresion regular normalizada
        private string expPosfija;//Expresion posfija generada
        private const int OPERADOR = 1;
        private const int PAR_IZQ = 2;
        private const int PAR_DER = 3;
        private const int OPERANDO = 4;
        private const int CUANTIFICADOR = 5;
        private int numPar;      
        private int numCorh;
        private List<string> alfabeto;
        private List<object> expPolacaInv;
        private List<string> alfabeto;

        public void setExp(string cad)
        {
            expRegular = cad;//Se establece la expresion a convertir en el objeto expresión.
        }

        //Método para convertir a posfija
        public string Conviertete()
        {
            generaTokens();//Si la generación de tokens fue correcta entonces es momento de hacer la conversión a posfija
            ConverToPosfija();
            
            return (expPosfija);
        }

        public string getExpRegPosf()
        {
            return (expPosfija);
        }

        /*Método para normalizar la expresión infija, este método es invocado una ves que
         * la expresión regular este bien escrita*/
        public string normalizate()
        {
            char c;
            
            expNorma = null;

            //Se hace un recorrido de la expresión regular, y se analiza cada caracter.
            for (int i = 0; i < expRegular.Length; i++)
            {
               c = expRegular[i];
                
               switch(getTipoSim(i))//Se obtiene un tipo especial de caracter.
               {
                   case 1://PAR_IZQ
                     AgregaPunto(i);  
                    expNorma += c;
                   break;
                   case 2: //PAR_DER
                   case 4: //OPERADOR
                       expNorma += c;
                   break;
                   case 3://Caracter del Alfabeto ASCCI
                      AgregaPunto(i);
                      if (c == '.')
                          expNorma += "\\" + ".";
                      else
                          if (c == '\r')
                              addCarMetaCar(expRegular[++i]);
                          else
                              if (c != 32 && c != '\t' && c != '\n')
                              {
                                  if (c == '\\')
                                      expNorma += "\\" + expRegular[++i];
                                  else
                                      expNorma += c;
                              }
                              else
                                  addCarMetaCar(c);
                   break;
                   case 5://Normalización de un Intervalo de carcateres
                       normaInterCar(ref i);
                   break;
               }
            }

            return (expNorma);
        }

        //Este método se encarga de agregar un punto entre la expresión normalizada.
        private void AgregaPunto(int i)
        {
            int w;
            int cont = 0;

            if (i > 0)
                if (expRegular[i - 1] != '|' && expRegular[i - 1] != '(')
                    expNorma += ".";
                else
                    if (i >=2 )
                        if (expRegular[i - 2] == '\\')
                        {
                            for (w = i - 2; w >= 0 && expRegular[w] == '\\';cont++, w--) ;
 
                            if(cont%2!=0)
                                expNorma += ".";
                        }
        }
        
        /*
         * Este método se encarga de normalizar una expresión que se encuntre entre corchetes.*/
        private void normaInterCar(ref int i)
        {
            int index;
            char car;
            index = i;
            char LI, LD;
            
            if (i > 0 && expRegular[i - 1] != '(' && expRegular[i - 1] != '|')
                expNorma += ".";

            LI = LD = 'a';
            expNorma += '(';
            index = i;
            i++;
            car = expRegular[i];
            
            //Este ciclo termina cuando encuentra la primera ocurrencia de corchete derecho
            while (car != ']')
            {
                if (car != '-')
                {
                    LI = car;//Se establce el limite izquierdo de un posible intervalo de carcateres.
                    if ((i - index) > 1 && expRegular[i-1] != '\r')
                        expNorma += '|';

                    if(car == 32 | car == '\t' | car == '\n')
                        addCarMetaCar(car);
                    else
                        if (car == '\\')
                        {
                            switch (expRegular[i + 1])
                            {
                                case 'e': LI = ' '; break;
                                case 't': LI = '\t'; break;
                                case 'n': LI = '\n'; break;
                                default:  LI = expRegular[i + 1]; break;
                            }
                            expNorma += "\\" + expRegular[++i];
                        }
                        else
                        {
                            if (car == '.')
                                expNorma += '\\';

                            if (car != '\r')
                              expNorma += car;
                        }
                }else
                {
                    if (expRegular[i+1] == '\r')
                           i++;
                    
                    LD = expRegular[i + 1];//Se captura el limite derecho de intervalo de caracteres encontrado.

                    if (expRegular[i + 1] != 32 && expRegular[i + 1] != '\t' && expRegular[i + 1] != '\n')
                    {
                        if (expRegular[i + 1] != '\\')
                            LD = expRegular[++i];
                        else
                        {
                            i += 2;
                            switch (expRegular[i])
                            {
                                case 'e': LD = ' '; break;
                                case 't': LD = '\t'; break;
                                case 'n': LD = '\n'; break;
                                default: LD = expRegular[i]; break;
                            }
                        }
                    }
                    else
                        LD = expRegular[++i];
                    
                    //Se obtine toda la secuencia de caracteres del intervalo encontrado.
                    for (LI++; LI <= LD; LI++)
                    {
                                expNorma += '|';
                                //Si en la secuencia aparece un caractere con valor en la exp regular lo convertimos en metacaracter.
                                if ((LI >= ')' && LI <= '+') || LI == '-' || LI == '.' || LI == '?' || LI == '|' || LI == '\\' || LI == '(' || LI == ')'
                                     || LI == '[' || LI == ']'|| LI == '~')
                                    expNorma += '\\';

                                if (LI == 32 || LI == '\n')
                                    addCarMetaCar(LI);
                                else
                                    expNorma += LI;
                    }
                }
                
                i++;
                car = expRegular[i];
            }
            expNorma += ')';
        }
        
        private void addCarMetaCar(char car)
        {
            switch ((int)car)
            {
                case 32: expNorma += "\\e";break;
                case  9: expNorma += "\\t"; break;
                case 13: expNorma += "\\r"; break;
                case 10: expNorma += "\\n"; break;
            }
        }

        /*Obtine un  identificador que representa el tipo de caracter.
         * Este método es invocado durante el proceso de normalización.*/
       private int getTipoSim(int index)
        {
            int tipo = 3;
            char s;

            if (index == expRegular.Length)
                tipo = -1;
            else
            {
                s = expRegular[index];

                if (s == '*' || s == '+' || s == '?' || s == '|')//Operador
                    tipo = 4;
                else
                    if (s == '(')
                        tipo = 1;
                    else
                        if (s == ')')
                            tipo = 2;
                        else
                            if (s == '[')//Inicio de un Intervalo de carcateres
                                tipo = 5;
            }
             return (tipo);
        }

        /*
         * Esta método se encarga de separar la expresión en sus elementos que la forman
         * Operador, operandos, (,), y crea un objeto por cada uno de ellos de la clase CToken.
         * A cada objeto se le denomino token de la expresion, donde todos los token creados 
         * se almacenaran en una lista, para llevar a cabo el proceso de conversion.
         * */
        private void generaTokens()
        {
            CToken token;
            int i;
            
            listaTokens = new List<CToken>();
           
            for (i = 0; i < expNorma.Length; i++)//Se recorre la cadena que contiene la expresión infija
            {  
                token = creaToken(ref i);//Si el token generado por esta funcion no es permito se cancela el proceso y regresa un valor indicando el resultado
                listaTokens.Add(token);
            }
        }

        /*
         * En este método, validamos si el numero de parentesis es correcto asi como
         * el orden de los operadores.
         * Regresa un valor booleando indica el resultado*/
        public bool validaExpresion()
        {
            bool band = true;
            char c,s;
            int tamExp;

            tamExp = expRegular.Length;
            numCorh = numPar = 0;

            for (int i = 0; i < tamExp && band; i++)
            {
                c = expRegular[i];

                if (i == 0 && (c == '*' || c == '+' || c == '?' || c == '|' || c == ')' || c == ']' || c == '-'))
                    band = false;
                else
                  switch (c)
                  { 
                      case '(':
                          numPar++;
                          if (i + 1 < tamExp)
                          {
                              s = expRegular[i + 1];
                              if (s == '*' || s == '+' || s == '?' || s == '|' || s == ')' || s == ']' || s == '-')
                                band = false;
                          }
                      break;
                      case ')':
                          if (numPar == 0)
                              band = false;
                          else
                             numPar--;
                      break;
                      case '\\':
                          if (i + 1 == tamExp)
                              band = false;
                          else
                             if( (band = ValidaMetacaracter(expRegular[i+1])))
                                  i++;
                      break;
                      case '[':
                          numCorh++;
                          band = validaIntervaloCar(ref i);
                      break;
                      case '-':
                          band = false;
                      break;
                      case ']':
                          numCorh--;
                      break;
                      case '|':
                          if (i + 1 == tamExp)
                              band = false;
                          else
                          {
                              s = expRegular[i + 1];
                              if (s == '*' || s == '+' || s == '?' || s == '|' || s == ')' || s == ']' || s == '-')
                                  band = false;
                          }
                      break;
                  }

            }

            if (band == true)
                if (numPar != 0|| numCorh != 0)
                    band = false;
            
            return (band);
        }

        /*La validación la dividi en dos metodos, este se encaraga de validar una
         * secuencia de caracteres, que se encuentren entre corchetes.
         * Aqui se valida los posibles intervalos de caracteres encontrados*/
        private bool validaIntervaloCar(ref int i)
        {
            bool band = true;
            int posIni, iAux;
            int cont, count; ;
            char s,LI,LD;

            LD = LI = '[';
            posIni = i + 1;
            
            /*Se checa que exista un corchete derecho, que indique el fin la expresión a 
             * analizar*/
            for (iAux = i+1; iAux < expRegular.Length; iAux++)
                if( expRegular[iAux] == '\\')
                    iAux++;
                else
                    if(expRegular[iAux] == ']')
                        break;

            cont = 1;

            /*Aqui checamos que sí se haya encontrado una corchete derecho
             *y que haya mínimo un elemento entre los corchetes*/
            if (iAux < expRegular.Length && (iAux - posIni) > 0)
            {
                for (i++; i < iAux && band; i++)
                {
                    switch ( expRegular[i])
                    { 
                        case '-':
                            if (i - 1 > posIni - 1 && i + 1 < iAux)
                            {
                                if (cont <= 1)
                                    band = false;
                                else
                                {
                                    //Checar el si el limite izq es un metacarter de tipo \e o \t
                                    count = 0;
                                    if (expRegular[i - 2] == '\\')
                                        for (int w = i - 2; expRegular[w] == '\\'; w--)
                                            count++;
                                
                                    LI = expRegular[i - 1];

                                    if (count % 2 != 0)
                                    {
                                        if (expRegular[i - 1] == 'e')
                                            LI = ' ';
                                        else
                                            if (expRegular[i - 1] == 't')
                                                LI = '\t';
                                            else
                                                if (expRegular[i - 1] == 'n')
                                                    LI = '\n';
                                    }else
                                        if (expRegular[i - 1] == '~')
                                            band = false;
                                
                                  if(band)
                                    if (expRegular[i + 1] == '\\')
                                    {
                                        if ((band = ValidaMetacaracter(expRegular[i + 2])))
                                        {
                                            switch (expRegular[i + 2])
                                            {
                                                case 'e': LD = ' '; break;
                                                case 't': LD = '\t'; break;
                                                case 'n': LD = '\n'; break;
                                                default: LD = expRegular[i + 2]; break;
                                            }
                                            if (LI > LD)
                                                band = false;
                                        }
                                    }
                                    else
                                    {
                                        if (expRegular[i + 1] == '~')
                                            band = false;
                                        else
                                        {
                                            LD = expRegular[i + 1];

                                            if (band && LI > LD)
                                                band = false;
                                        }
                                    }
                                    cont = 0;
                                }
                            }
                            else
                                band = false;
                        break;
                        case '*'://Entre los corchetes no debe existir ninguno de estos caracteres.
                        case '+':
                        case '?':
                        case '|':
                        case '[':
                        case ']':
                        case '(':
                        case ')':
                            band = false;
                        break;
                        case '\\':
                            if (i + 1 == iAux)
                                band = false;
                            else
                            {
                                s = expRegular[i+1];
                                if((band = ValidaMetacaracter(s)))
                                {
                                    cont++;
                                    i++;
                                }
                            }
                        break;
                        default:
                            cont++;
                        break;
                        
                    }
                }

                if (band)
                    numCorh--;
            }
            else
                band = false;

            return (band);
        }

        /*
         * Se prueba que todo caracter precedido por la barra de escape sea un metacaracter válido*/
        private bool ValidaMetacaracter(char s)
        {
            bool band = true;

            if (s != '*' && s != '+' && s != '?' && s != '|' && s != ')' && s != ']' && s != '\\' &&
                s != '(' && s != '[' && s != 'e' && s != 'n' && s != 't' && s != '-' && s != '~')
                band = false;

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
            int tipo, jerarquia;
            char s = expNorma[index];

            jerarquia = 1;

            if (s == '*' || s == '+' || s == '?')
                tipo = 5;
            else
            {
                tipo = 1;
                if (s == '.')
                    jerarquia = 2;
                else
                    if (s == '|')
                        jerarquia = 1;
                    else
                        if (s == '(')
                            tipo = 2;
                        else
                            if (s == ')')
                                tipo = 3;
                            else
                            {
                                tipo = 4;
                                if (s == '\\')
                                   return (new COperador(tipo, s.ToString() + expNorma[++index], jerarquia));//Creacion del operador  
                                
                            }
            }

            return (new COperador(tipo, s.ToString(), jerarquia));//Creacion del operador
         }

        /*
         * Algoritmo para convertir una expresion infija, almacenada en una lista de tokens
         * a una expresión posfija.
         * Este metodo es llamado por el objeto expresion creado previamente, una ves que la expresion
         * este escrita correctamente.*/
        private void ConverToPosfija()
        {
            pila = new Stack<object>();
            expPolacaInv = new List<object>();
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
                        {
                            expPolacaInv.Add((CToken)pila.Peek());
                            expPosfija += ((CToken)pila.Pop()).getSimbolo();
                        }
                        pila.Pop();
                    break;
                    case OPERANDO:
                    case CUANTIFICADOR:
                        expPosfija += t.getSimbolo();
                        expPolacaInv.Add(t);
                        if (!alfabeto.Contains(t.getSimbolo()) && t.getTipo() == 4)
                            alfabeto.Add(t.getSimbolo());
                    break;
                    default://Operador
                        while (pila.Count > 0 && ((CToken)(pila.Peek())).getTipo() == OPERADOR &&
                             ((COperador)t).getJerarquia() <= ((COperador)pila.Peek()).getJerarquia())
                        {
                            expPolacaInv.Add((CToken)pila.Peek());
                            expPosfija += ((CToken)pila.Pop()).getSimbolo();
                        }
                        pila.Push(t);
                    break;
                }
            }

            while (pila.Count > 0)
            {
                expPolacaInv.Add((CToken)pila.Peek());
                expPosfija += ((CToken)pila.Pop()).getSimbolo();
            }
        }

        public void setExpNorma(string cad)
        {
            this.expNorma = cad;
        }

        public List<object> getExpPolacaInv()
        {
            return (expPolacaInv);
        }

        public string getExpNorma()
        {
            return (this.expNorma);
        }

        public List<string> getAlfabeto()
        {
            return (alfabeto);
        }
    }
}

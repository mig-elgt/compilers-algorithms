using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GramaticasRegulares.Clases.Gramatica
{
    /*
     * Esta clase es la principal para crear la expresión regular con el algoritmo visto en clase*/
    class CGramatica
    {
        private List<CEcuacion> ecuaciones;
        private string expRegular; //Expresion regular generada
        private string[] producciones; //Conjunto de producciones
        private List<CLineText> listaLT;
        private int dY;
        private int dX;

        public CGramatica() 
        {
            ecuaciones = new List<CEcuacion>();
            listaLT = new List<CLineText>();
        }

        public void setExpReg(string eR)
        {
            this.expRegular = eR;
        }

        public void setProducciones(string[] P)
        {
            producciones = P;
        }

        public CEcuacion getAtEcuacion(int index)
        {
            if (ecuaciones.Count != 0)
                return (ecuaciones[index]);

            return (null);
        }
        
        public string getExpReg()
        {
            return (this.expRegular);
        }

        public List<CLineText> getListText()
        {
            return (listaLT);
        }
       
        public void creaExpReg()//Implementa el algoritmo
        {
            float x, y;
            string pro, xi, red, sust;
            string cad;

            x = 0;
            y = 0;

            listaLT.Clear();
            
            listaLT.Add(new CLineText(" Paso 1",x,y,FontStyle.Bold));
            //---------------------------------------Paso 1-----------------------------------------------------//
            //reduceGramatica();
            y += 30;
            
            for(int i = 0; i < ecuaciones.Count; i++, y+=15)
            {
                cad = " (" + i.ToString() + ") " + ecuaciones[i].getNamePro() + " -> " + ecuaciones[i].dameExpresion();
                listaLT.Add(new CLineText(cad, x, y));
            }
            
            //---------------------------------------Paso 2-----------------------------------------------------//
            y += 20;
            listaLT.Add(new CLineText(" Paso 2", x, y, FontStyle.Bold));
            y += 30;
            
            for (int i = 0; i < ecuaciones.Count-1; i++)
            {
                x = 0;
                pro = "  "+ecuaciones[i].getNamePro() + " -> " + ecuaciones[i].dameExpresion();
                xi = "    Xi = " + ecuaciones[i].getNamePro();
                //Tratar de reducir la ecuacion Xi
                if (ecuaciones[i].reducete())
                    red = "  Reduce " + ecuaciones[i].getNamePro() + " -> " + ecuaciones[i].dameExpresion();
                else
                    red = "  No reduce";

                listaLT.Add(new CLineText(" i=" + i + xi, x, y));
                listaLT.Add(new CLineText(pro + red, x += 22, y += 15 ));
                y += 20; x += 10;
                
                for (int j = i + 1; j < ecuaciones.Count; j++,y+=15)
                {
                    pro = "  " + ecuaciones[j].getNamePro() + " -> " + ecuaciones[j].dameExpresion();
                    xi = "    Xj = " + ecuaciones[j].getNamePro();
                    if(ecuaciones[j].sustituye(ecuaciones[i]))
                        sust = "  Sustituye " + ecuaciones[j].getNamePro() + " -> " + ecuaciones[j].dameExpresion();
                    else
                        sust = "  No sustituye";

                    listaLT.Add(new CLineText(" j=" + j + xi, x, y));
                    listaLT.Add(new CLineText(pro + sust,x+22,y+=15));
                 }
                
                y += 10;
            }

            //---------------------------------------Paso 3-----------------------------------------------------//
            y += 10;x = 0;
            listaLT.Add(new CLineText(" Paso 3", x, y, FontStyle.Bold));
            y += 30;
        
            for (int i = ecuaciones.Count-1; i >= 0; i--,y+=15)
            {
                x = 0;
                pro = "  " + ecuaciones[i].getNamePro() + " -> " + ecuaciones[i].dameExpresion();
                xi = "    Xi = " + ecuaciones[i].getNamePro();
                //Tratar de reducir la ecuacion Xi
                if (ecuaciones[i].reducete())
                    red = "  Reduce " + ecuaciones[i].getNamePro() + " -> " + ecuaciones[i].dameExpresion();
                else
                    red = "  No reduce";

                listaLT.Add(new CLineText(" i=" + i + xi, x, y));
                listaLT.Add(new CLineText(pro+red,x += 22, y += 15 ));
                
                y += 20;
                x += 10;
                for (int j = i - 1; j >=0; j--, y += 15)
                {
                    pro = "  " + ecuaciones[j].getNamePro() + " -> " + ecuaciones[j].dameExpresion();
                    xi = "    Xj = " + ecuaciones[j].getNamePro();
                    if (ecuaciones[j].sustituye(ecuaciones[i]))
                        sust = "  Sustituye " + ecuaciones[j].getNamePro() + " -> " + ecuaciones[j].dameExpresion();
                    else
                        sust = "  No sustituye";
                    
                    listaLT.Add(new CLineText(" j=" + j + xi, x, y));
                    listaLT.Add(new CLineText(pro + sust, x += 22, y += 15));
                }
            }
            
            expRegular = ecuaciones[0].dameExpresion();
            dY = (int)y;
        }

        public int getDY()
        {
            return (dY);
        }

        //Este método efectua el paso 1 del algoritmo
        private void reduceGramatica()
        {
            char c;
            int j, i;
            string cadT, cadNT;
            CEcuacion E;

            ecuaciones.Clear();
            
            foreach (string p in producciones)
            {
                cadT = null;
                cadNT = null;
                E = null;

                for ( i = 0; i < p.Length; i++)
                {
                    c = p[i];
                  
                    if (c == '<')
                    {
                        for (; p[i] != '>'; i++)
                            cadNT += p[i];

                        cadNT += p[i];

                        if ((E = buscaEc(cadNT)) == null)
                        {
                            E = new CEcuacion(cadNT);
                            ecuaciones.Add(E);
                        }
                    }
                    else
                        do
                        {
                            c = p[i];
                 
                            if (Char.IsLetterOrDigit(c) | c == '~')
                            {
                                cadNT = null;
                                cadT = null;

                                cadT += c;
                                i++;

                                if (i < p.Length && p[i] != '|')
                                {
                                    for (; i < p.Length && p[i] != '>'; i++)
                                        cadNT += p[i];

                                    if (i < p.Length)
                                        cadNT += p[i];
                                }

                                E.addTermino(cadT, cadNT);
                            }
                        
                            i++;
                 
                        } while (i < p.Length);
                }
            }
        }

        public CEcuacion buscaEc(string cad)
        {
            CEcuacion ecuAxu;

            ecuAxu = null;

            foreach (CEcuacion e in ecuaciones)
                if (e.getNamePro().CompareTo(cad) == 0)
                {
                    ecuAxu = e;
                    break;
                }

            return (ecuAxu);
        }

        public bool validate()
        {
            CEcuacion E;
            bool res,enc;
            char c;
            int i;
            string cadNT;

            res = true;
            
            ecuaciones.Clear();
            
            foreach (string p in producciones)
            {
                cadNT = null;
                E = null;

                for (i = 0; i < p.Length && res; i++)
                {
                    c = p[i];

                    if (c != 32)//Espacio
                    {
                        if (c == '<')//Checar que este bien la producción
                        {
                            cadNT += c;
                            for (i++; i < p.Length && (p[i] != '>'); i++)
                            {
                                if (Char.IsLetterOrDigit(p[i]))
                                    cadNT += p[i];
                                else
                                    return (false);
                            }
                            if (i < p.Length && cadNT.Length>1)//Continuar con el análisis
                            {
                                cadNT += p[i];
                                if ((E = buscaEc(cadNT)) == null)//Se agrega la primer producción
                                {
                                    E = new CEcuacion(cadNT);
                                    ecuaciones.Add(E);
                                }
                                i++;
                                enc = false;
                                //Buscar el simbolo ->
                                for (; i < p.Length && !enc; i++)
                                    if (p[i] != 32)//Se omiten los espacios
                                        if (p[i] == '-')
                                            enc = true;
                                        else
                                            break;

                                if (enc && i<p.Length-1)
                                {
                                    if (p[i] == '>') //Si cumple esta condicón se checa la produción
                                        res = checaProduccion(p, ref i,ref E);
                                    else
                                        res = false;
                                }
                                else
                                    res = false;
                            }
                            else
                                res = false;
                        }
                        else//Producción incorrecta
                            res = false;
                    }                
                }
            }

            if (res)
                res = checaNoTerminales();

            return (res);
        }

        /*
         * Este método se utliza para checar que todos los terminales definidos en las
         * producciónes existan*/
        private bool checaNoTerminales()
        {
            bool band,res = true;
            string NT;
            
            foreach (CEcuacion e in ecuaciones)
                foreach (CTermino t in e.getListTerm())
                {
                    NT = t.getVar();
                    band = false;

                    if (t.getCoef().CompareTo("~") == 0 && t.getVar() != null)
                        return (false);

                    if (NT != null)
                    {
                        foreach (CEcuacion w in ecuaciones)
                            if (NT.CompareTo(w.getNamePro()) == 0)
                            {
                                band = true;
                                break;
                            }

                        if (!band)
                            return (false);
                    }
                }

            return (res);
        }

        private bool checaProduccion(string p, ref int i,ref CEcuacion E)
        {
            string cadT, cadNT;
            bool band,res = true;
            char c;
            
            i++;

            do
            {
                c = p[i];
                band = true;
                cadNT = cadT = null;

                if (termValido(c))
                {
                    if (c == '\\')//Si es un metacaracter
                    {
                        if ((i < p.Length - 1) && ValidaMetacaracter(p[i + 1]))
                        {
                            cadT = c + p[i + 1].ToString();
                            i += 2;
                            band = true;
                        }
                        else
                            return (false);
                    }
                    else// * + ? o jgkjcn
                    {
                        if (p[i] == 32)//Si es un espacio, cambiarlo por \e
                            cadT += "\\" + "e";
                        else
                            if (p[i] == '*' || p[i] == '+' || p[i] == '?')
                                cadT = "\\" + p[i].ToString();
                            else
                                cadT += p[i];

                        i++;
                        band = true;
                    }

                    if (band)//Buscar un no terminal
                    {
                        if (i < p.Length)
                            if (p[i] == '<')//Checar que este bien la producción
                            {
                                cadNT += p[i];
                                for (i++; i < p.Length && (p[i] != '>'); i++)
                                {
                                    if (Char.IsLetterOrDigit(p[i]))
                                        cadNT += p[i];
                                    else
                                        return (false);
                                }

                             if (i < p.Length && cadNT.Length > 1)
                                {
                                    cadNT += p[i];
                                    i++;
                                    if (i < p.Length)
                                        if (p[i] == '|')
                                        {
                                            if (i == p.Length - 1)
                                                return (false);
                                        }
                                        else
                                            return (false);
                                }
                                else
                                    return (false);
                            }
                            else
                                if (p[i] == '|')
                                {
                                    if (i == p.Length - 1)
                                        return (false);
                                }
                                else
                                    return (false);

                        E.addTermino(cadT, cadNT);
                    }
                }
                else
                    return (false);

                i++;

            } while (i < p.Length);
            
            return(res);
        }

        private bool ValidaMetacaracter(char s)
        {
            bool band = true;

            if (s != '|' && s != '<' && s != '>' && s != '{' && s != '}' && s != 'n' && s != 'e' && s != '~' && s != '(' && s != ')' && s != '[' && s != ']')
                    band = false;

            return (band);
        }

        private bool termValido(char c)
        {
            bool res = true;

            if (c == '{' | c == '}' | c == '<' | c == '>' | c == '|'|c == '('|c == ')'|c == '['|c == ']')
                res = false;

            return (res);
        }

        public string dameExpRegFinal()
        {
            string cadAux;

            cadAux = null;

            for (int i = 0; i < expRegular.Length; i++)
            {
                if (expRegular[i] == '{')
                {
                    if (i == 0)
                        cadAux += "(";
                    else
                        if (expRegular[i - 1] != '\\')
                            cadAux += "(";
                        else
                            cadAux += expRegular[i];
                }
                else
                    if (expRegular[i] == '}')
                    {
                        if (expRegular[i - 1] != '\\')
                            cadAux += ")*";
                        else
                            cadAux += expRegular[i];
                    }
                    else
                        cadAux += expRegular[i];
            }

            return (cadAux);
        }
    }
}

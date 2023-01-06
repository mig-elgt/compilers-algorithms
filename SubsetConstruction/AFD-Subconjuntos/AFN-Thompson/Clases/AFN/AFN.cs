using System;
using System.Collections.Generic;
using System.Text;
using Convertidor_de_Expresiones;
using System.Drawing;

namespace AFD_Subconjuntos.Clases.AFN
{
    /*Esta clase se utiliza para crear el AFN a partir de las reglas de thompson, cuenta con métodos para implementar
      dichas reglas y establece las coordenadas a los estados y sus transiciones.
     * */
    public class AFN
    {
        private List<object> expPosfija;//La expresion polaca inversa es almacena en una lista
        private Stack<CAutomata> pilaAutomatas;
        
        public AFN()
        {
            pilaAutomatas = new Stack<CAutomata>();
        }
        
        //Este método es utlizado para llevar a cabo el proceso de creacion del AFN
        public CAutomata CreaAFN()
        {
            CAutomata R, S;

            pilaAutomatas.Clear();

            foreach (CToken t in expPosfija)
            {
                switch (t.getTipo())
                { 
                    case 1://Operador Binario ( ., |)
                        S = pilaAutomatas.Pop();
                        R = pilaAutomatas.Pop();

                        if (t.getSimbolo() == ".")
                            pilaAutomatas.Push(Concatenacion(R, S));
                        else
                            pilaAutomatas.Push(SelectOfAlternativas(R, S));
                    break;
                    case 4://Operando
                        pilaAutomatas.Push(Basico(t.getSimbolo()));
                    break;
                    case 5://Reglas de thompson 
                        R = pilaAutomatas.Pop();

                        if (t.getSimbolo() == "*")
                            pilaAutomatas.Push(CerraduraKlenne(R));
                        else
                            if(t.getSimbolo() == "+")
                               pilaAutomatas.Push(CerraduraPositiva(R));
                            else
                               pilaAutomatas.Push(SubexpresionCondicional(R));
                    break;

                }
            }
            
            return (pilaAutomatas.Pop());
        }

        public void setExpPosfija(List<object> L)
        {
            expPosfija = L;
        }

        //Se implementa la regla basica de thompson
        private CAutomata Basico(string r)
        {
            CAutomata nuevo;
            
            nuevo = creaAutomata();
            nuevo.InsTransicion(nuevo.getEstadoInicial(), nuevo.getEstadoFinal(), r);

            return (nuevo);
        }

        //Crea un automata simple
        private CAutomata creaAutomata()
        {
            CAutomata nuevo;
            CEstado eI, eF;
            int ancho, alto, radio;

            nuevo = new CAutomata();

            eI = new CEstado(1, "Inicial");
            eF = new CEstado(2, "Final");

            nuevo.setEstadoInicial(eI);
            nuevo.setEstadoFinal(eF);
            nuevo.AddEstado(eI);
            nuevo.AddEstado(eF);

            //Se establecen coordenas en los estados
            radio = eI.getRadio();
            ancho = radio * 8;
            alto = radio * 4;
            nuevo.setRect(new Rectangle(0, 0, ancho, alto));
            eI.setCentro(radio * 3, radio * 2);
            eF.setCentro(ancho - radio, radio * 2);

            return (nuevo);
        }

        //Regla de Concatenación
        private CAutomata Concatenacion(CAutomata R, CAutomata S)
        {
            int width, height, dY;
            int radio = R.getEstadoInicial().getRadio();

            R.InsTransicion(R.getEstadoFinal(), S.getEstadoInicial(), "~");
            S.IncEstado(R.getEstadoFinal().getNombre());
            S.getEstadoFinal().setNombre(S.getCont() + 1);
            R.getEstadoFinal().setEstado("Normal");
            S.getEstadoInicial().setEstado("Normal");

            //Se establecen las coordenas para la concatenación de dos automatas
            S.trasladate(R.getAncho(), 0);
            width = R.getAncho() + S.getAncho();

            if (R.getAlto() >= S.getAlto())
            {
                dY = R.getEstadoFinal().getCentroY() - S.getEstadoInicial().getCentroY();
                S.trasladate(0, dY);
                height = R.getAlto();
            }
            else
            {
                dY = S.getEstadoInicial().getCentroY() - R.getEstadoFinal().getCentroY();
                R.trasladate(0, dY);
                height = S.getAlto();
            }

            R.setRect(new Rectangle(0, 0, width, height));
            R.setEstadoFinal(S.getEstadoFinal());
            R.AddAutomata(S);

            return (R);
        }

        private CAutomata SelectOfAlternativas(CAutomata R, CAutomata S)
        {
            CAutomata nuevo;
            int h, w, radio = R.getEstadoInicial().getRadio();

            nuevo = creaAutomata();

            nuevo.InsTransicion(nuevo.getEstadoInicial(), R.getEstadoInicial(), "~");
            nuevo.InsTransicion(nuevo.getEstadoInicial(), S.getEstadoInicial(), "~");
            R.InsTransicion(R.getEstadoFinal(), nuevo.getEstadoFinal(), "~");
            S.InsTransicion(S.getEstadoFinal(), nuevo.getEstadoFinal(), "~");
            R.cambiaEstados();
            S.cambiaEstados();
            R.IncEstado(1);
            S.IncEstado(R.getCont());
            nuevo.getEstadoFinal().setNombre(S.getCont() + 1);
            
            //Se establecen las coordenadas
            R.trasladate(radio * 4, 0);
            S.trasladate(radio * 4, R.getAlto());
            w = centraAutomatas(R, S);
            h = R.getAlto() + S.getAlto();
            nuevo.getEstadoInicial().setCentro(radio * 3, R.getAlto());
            nuevo.getEstadoFinal().setCentro((radio * 7) + w, R.getAlto());
            R.setRect(new Rectangle(0, 0, w + radio * 8, S.getAlto() + R.getAlto()));

            R.AddAutomata(nuevo);
            R.AddAutomata(S);
            R.setEstadoInicial(nuevo.getEstadoInicial());
            R.setEstadoFinal(nuevo.getEstadoFinal());
            R.Ordenate();

            return (R);
        }
        //Este método se encarga de centrar dos automatas, es invocado por la regla de concatenacion y selección de alternativas
        private int centraAutomatas(CAutomata A, CAutomata B)
        {
            int w1, w2;

            w1 = A.getAncho();
            w2 = B.getAncho();

            if (w1 < w2)
                A.trasladate((w2 / 2) - (w1 / 2), 0);
            else
                B.trasladate((w1 / 2) - (w2 / 2), 0);

            return (Math.Max(w1, w2));
        }

        //Método para implementar la regla de cerradura de Klenne
        private CAutomata CerraduraKlenne(CAutomata R)
        {
            Point p1, p2, p3, p4, p5, p6;
            List<Point> lP;
            int x3, x4;

            R = CerraduraPositiva(R);//Se aplica la cerradura positiva

            //Se establecen las coordenadas la transición entre el estado inicial y el final
            lP = new List<Point>();
            p1 = new Point(R.getEstadoInicial().getCentroX(), R.getEstadoInicial().getCentroY());
            p2 = new Point(R.getEstadoFinal().getCentroX(), R.getEstadoFinal().getCentroY());

            x3 = p1.X + (p2.X - p1.X) / 4;
            x4 = p1.X + (p2.X - p1.X) * 3 / 4;

            p3 = new Point(x3, R.getAlto() + 50);
            p4 = new Point(x4, R.getAlto() + 50);
            p5 = new Point(p1.X + 40, R.getAlto());
            p6 = new Point(p2.X - 40, R.getAlto());

            lP.Add(p1);
            lP.Add(p5);
            lP.Add(p3);
            lP.Add(p4);
            lP.Add(p6);
            lP.Add(p2);

            R.InsTransicion(R.getEstadoInicial(), R.getEstadoFinal(), "~", lP);
            R.setRect(new Rectangle(0, 0, R.getAncho(), p4.Y + 20));

            return (R);
        }

        //Método para implementar la cerradura Positiva
        private CAutomata CerraduraPositiva(CAutomata R)
        {
            CAutomata nuevo;
            CTransicion t;
            Point p1, p2, p3, p4, p5, p6;
            List<Point> lP;
            int altura,w, radio, widht, height,x3, x4, y;

            lP = new List<Point>();
            t = new CTransicion(R.getEstadoFinal(), R.getEstadoInicial(), "~");
            t.setTipo(2);
            radio = R.getEstadoInicial().getRadio();
            nuevo = creaAutomata();
            w = R.getAncho();
            
            R.getEstadoFinal().AddTransicion(t);
            nuevo.InsTransicion(nuevo.getEstadoInicial(), R.getEstadoInicial(), "~");
            R.InsTransicion(R.getEstadoFinal(), nuevo.getEstadoFinal(), "~");

            //Se establecen las coordenadas a los estados y transiciones
            R.trasladate(radio * 4, 0);
            nuevo.getEstadoInicial().setCentro(radio * 3, R.getEstadoInicial().getCentroY());
            nuevo.getEstadoFinal().setCentro((radio * 7) + w, R.getEstadoFinal().getCentroY());
            altura = R.getAlto() + 20;

            //Curva para una transición
            p1 = new Point(R.getEstadoFinal().getCentroX(), R.getEstadoFinal().getCentroY());
            p2 = new Point(R.getEstadoInicial().getCentroX(), R.getEstadoInicial().getCentroY());

            x3 = p1.X + (p2.X - p1.X) / 4;
            x4 = p1.X + (p2.X - p1.X) * 3 / 4;
            y = Convert.ToInt32(p1.Y * 0.25);

            p3 = new Point(x3, 0);
            p4 = new Point(x4, 0);

            if (R.getListEstados().Count == 2)
            {
                p5 = p3;
                p6 = p4;
            }
            else
            {
                p5 = new Point(p1.X - 40, y);
                p6 = new Point(p2.X + 40, y);
            }

            //Se agregan los puntos de control para la curva creada
            lP.Add(p1);
            lP.Add(p5);
            lP.Add(p3);
            lP.Add(p4);
            lP.Add(p6);
            lP.Add(p2);

            t.setPtsControl(lP);
            widht = R.getAncho() + radio * 8;
            height = altura;
            T(R, nuevo);
            R.trasladate(0, 20);
            R.setRect(new Rectangle(0, 0, widht, height));

            return (R);
        }

        //Método para implementar la regla de subexpresión condicional
        private CAutomata SubexpresionCondicional(CAutomata R)
        {
            CAutomata nuevo;
            Point p1, p2, p3, p4, p5, p6;
            List<Point> lP;
            int w, radio, widht, height, x3, x4;
            
            lP = new List<Point>();
            radio = R.getEstadoInicial().getRadio();
            w = R.getAncho();

            nuevo = creaAutomata();

            nuevo.InsTransicion(nuevo.getEstadoInicial(), R.getEstadoInicial(), "~");
            R.InsTransicion(R.getEstadoFinal(), nuevo.getEstadoFinal(), "~");
            R.trasladate(radio * 4, 0);

            nuevo.getEstadoInicial().setCentro(radio * 3, R.getEstadoInicial().getCentroY());
            nuevo.getEstadoFinal().setCentro((radio * 7) + w, R.getEstadoFinal().getCentroY());

            //Se crean los puntos para la transición de tipo spline
            p1 = new Point(nuevo.getEstadoInicial().getCentroX(), nuevo.getEstadoInicial().getCentroY());
            p2 = new Point(nuevo.getEstadoFinal().getCentroX(), nuevo.getEstadoFinal().getCentroY());

            x3 = p1.X + (p2.X - p1.X) / 4;
            x4 = p1.X + (p2.X - p1.X) * 3 / 4;

            p3 = new Point(x3, R.getAlto() + 50);
            p4 = new Point(x4, R.getAlto() + 50);
            p5 = new Point(p1.X + 40, R.getAlto());
            p6 = new Point(p2.X - 40, R.getAlto());

            lP.Add(p1);
            lP.Add(p5);
            lP.Add(p3);
            lP.Add(p4);
            lP.Add(p6);
            lP.Add(p2);

            nuevo.InsTransicion(nuevo.getEstadoInicial(), nuevo.getEstadoFinal(), "~", lP);

            widht = R.getAncho() + radio * 8;
            height = p4.Y + 20;
            R.setRect(new Rectangle(0, 0, widht, height));

            T(R, nuevo);

            return (R);
        }
        
        //Este método se utliza para agregar los estados que fueron creados en alguna regla.
        private void T(CAutomata R, CAutomata nuevo)
        {
            R.cambiaEstados();
            R.IncEstado(1);
            nuevo.getEstadoFinal().setNombre(R.getCont() + 1);
            R.AddAutomata(nuevo);
            R.setEstadoInicial(nuevo.getEstadoInicial());
            R.setEstadoFinal(nuevo.getEstadoFinal());
            R.Ordenate();
        }
    }
}

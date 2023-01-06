
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AFD_Minimo.Clases.AFN
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
			return (this.estadoInicial);
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

			foreach (CEstado e in listEstados)
				if (e.getNombre().ToString().CompareTo(name) == 0)
				{
					est = e;
					break;
				}

			return (est);
		}

		//Este método no entrega un cadena que representa el AFN, es utilizado en las pruebas de regresión.
		public string creaFormatoAutomata()
		{
			CEstado e;
			string T = null;

			for(int i = 0; i < listEstados.Count; i++)
			{
				e = listEstados[i];
				T += "<";

				if(e.getNombre() >= 64)
					T += Convert.ToChar(e.getNombre()).ToString();
				else
					T += e.getNombre().ToString();

				if (i == 0)
					T += "i";
			
				if (e.getEstado().CompareTo("Final") == 0)
						T += "a";

				T += ">";

				if (e.getListTransicion().Count > 0)
				{
					foreach (CTransicion t in e.getListTransicion())
					{
						if (t.getEstadoSig().getNombre() >= 64)
							T += Convert.ToChar(t.getEstadoSig().getNombre()).ToString();
						else
							T += t.getEstadoSig().getNombre().ToString();

						T += t.getEtiqueta() + ",";
					}
					T = T.Remove(T.Length - 1, 1);
				}

			}

			return (T);
		}

		public void EstablceCoordenadas()
		{
			List<CEstado> L;
            int id = 0;

			L = new List<CEstado>();
			estadoInicial.setVisitado(true);
			estadoInicial.setCentro(75, 70);
			L.Add(getEstadoInicial());
			creaCoor(L,id);
		}

		/*
		 * Método para crear las coordenas de los estados del AFD asi como establcer los
		 * puntos de control de las transiciones*/
		private void creaCoor(List<CEstado> L,int id)
		{
			List<CEstado> nueva; //Nueva lista de estados
			CEstado sig;
			bool band = false;
			int dx, dy, xi, yi, rel;
			float h = 0.0f;

			dx = dy = 140;

			if (L.Count > 0)
			{
				xi = L[0].getCentroX();
				yi = L[0].getCentroY();
				ancho = xi + 60;
				nueva = new List<CEstado>();

				foreach (CEstado e in L)//Se buscan todos los hijos de este estado
				{
                    e.setNombre(id++);
					foreach (CTransicion t in e.getListTransicion())
					{
						sig = t.getEstadoSig();
						if (!sig.getVisitado())//Nuevo hijo
						{
                            if (!band)
							{
								yi = e.getCentroY();
								band = true;
							}
							else
								yi += dy;

							sig.setVisitado(true);
							sig.setCentro(xi + dx, yi);
							t.setTipo(1);
							EstableceCoor(e, sig, t, h);
							nueva.Add(sig);
						}
						else
						{
							if (sig == e)//Crear un oreja
							{
								t.setTipo(3);
								creaOreja(e, t);
							}
							else
							{
								t.setTipo(2);
								if (sig.getCentroX() <= e.getCentroX())
								{
									if (sig.getCentroX() == e.getCentroX())
										rel = Math.Abs(e.getCentroY() - sig.getCentroY());
									else
										rel = Math.Abs(e.getCentroX() - sig.getCentroX());

									if (rel == dy)
									{
										if (existeRelacion(e, sig))
										{
											if (e.getCentroY() >= sig.getCentroY() || e.getCentroX() > sig.getCentroX())
												h = 0.10f;
										}
									}
									else
									{
										if (e.getCentroX() != sig.getCentroX())
										{
											if (e.getCentroY() == sig.getCentroY())
												h = 0.10f;

										}
										else
											h = 0.10f;
									}
								}
								//Crear coordenadas  de las transiciones
								EstableceCoor(e, sig, t, h);
							}
						}
						h = 0.0f;
					}
				}

				if (alto < yi + 50)
					alto = yi + 50;

				creaCoor(nueva,id);
			}
		}

		private void creaOreja(CEstado e, CTransicion t)
		{
			float x1, y1;

			x1 = e.getCentroX() + e.getRadio() + 50;
			y1 = e.getCentroY() - 20;
			t.setPoint3Ctrl(new PointF(x1, y1));

			x1 = e.getCentroX() + 20;
			y1 = e.getCentroY() - e.getRadio() - 50;
			t.setPoint4Ctrl(new PointF(x1, y1));
		}

		private void EstableceCoor(CEstado e, CEstado sig, CTransicion t, float h)
		{
			PointF p3, p4;

			p3 = new PointF();
			p4 = new PointF();

			EstablecePuntosCtrl(ref p3, ref p4, e.getCentroX(), e.getCentroY(),
			sig.getCentroX(), sig.getCentroY(), h);

			t.setPoint3Ctrl(p3);
			t.setPoint4Ctrl(p4);
			t.setAltura(h);
		}

		private bool existeRelacion(CEstado eO, CEstado eD)
		{
			bool res = false;

			foreach (CTransicion t in eD.getListTransicion())
				if (t.getEstadoSig() == eO)
				{
					res = true;
					break;
				}

			return (res);
		}

		public void EstablecePuntosCtrl(ref PointF p3, ref PointF p4, int p1x, int p1y, int p2x, int p2y, float h)
		{
			float x3, y3, x1, y1, x2, y2, x4, y4, radio, dx, dY;
			float cA, cO;
			double angTheta, angAlpha = 0;

			x1 = (float)p1x;
			y1 = (float)p1y;
			x2 = (float)p2x;
			y2 = (float)p2y;

			x3 = x1 + (x2 - x1) / 3;
			y3 = y1 + (y2 - y1) / 3;
			x4 = x1 + (x2 - x1) * 2 / 3;
			y4 = y1 + (y2 - y1) * 2 / 3;

			cA = x2 - x1;
			cO = y2 - y1;

			radio = (float)(Math.Sqrt(((double)cA * (double)cA) + ((double)cO * (double)cO)) * h);
			angTheta = Math.Atan(((double)cO / (double)cA)) * 180 / Math.PI;


			if (x2 > x1)
				angAlpha = angTheta - 90;
			else
				angAlpha = angTheta + 90;

			dx = (float)(radio * Math.Cos((double)angAlpha * Math.PI / 180));
			dY = (float)(radio * Math.Sin((double)angAlpha * Math.PI / 180));

			x3 += dx;
			y3 += dY;
			x4 += dx;
			y4 += dY;

			p3 = new PointF(x3, y3);
			p4 = new PointF(x4, y4);

		}

		public void ActulizaPtsCtrl(CEstado vert)
		{
			PointF p3, p4;
			int x1, y1, x2, y2;

			p3 = new PointF();
			p4 = new PointF();


			foreach (CEstado nV in listEstados)
				if (nV != vert)
				{
					foreach (CTransicion aux in nV.getListTransicion())
					{
						if (aux.getTipo() != 3)
						{
							x1 = aux.getEstadoAct().getCentroX();
							y1 = aux.getEstadoAct().getCentroY();
							x2 = aux.getEstadoSig().getCentroX();
							y2 = aux.getEstadoSig().getCentroY();

							EstablecePuntosCtrl(ref p3, ref p4, x1, y1, x2, y2, aux.getAltura());
							aux.setPoint3Ctrl(p3);
							aux.setPoint4Ctrl(p4);
						}
					}
				}

			foreach (CTransicion aux in vert.getListTransicion())
			{
				if (aux.getTipo() != 3)
				{
					x1 = aux.getEstadoAct().getCentroX();
					y1 = aux.getEstadoAct().getCentroY();
					x2 = aux.getEstadoSig().getCentroX();
					y2 = aux.getEstadoSig().getCentroY();

					EstablecePuntosCtrl(ref p3, ref p4, x1, y1, x2, y2, aux.getAltura());

					if (aux.getEstadoAct() == vert)
					{
						foreach (CTransicion aux2 in aux.getEstadoSig().getListTransicion())
						{
							if (aux2.getEstadoAct() == vert && aux2.getPoint3Ctrl() == aux.getPoint4Ctrl() && aux2.getPoint4Ctrl() == aux.getPoint3Ctrl())
							{
								aux2.setPoint3Ctrl(p4);
								aux2.setPoint4Ctrl(p3);
								break;
							}
						}
						aux.setPoint3Ctrl(p3);
						aux.setPoint4Ctrl(p4);
					}
					else
					{
						foreach (CTransicion aux2 in aux.getEstadoAct().getListTransicion())
						{
							if (aux2.getEstadoSig() == vert && aux2.getPoint3Ctrl() == aux.getPoint4Ctrl() && aux2.getPoint4Ctrl() == aux.getPoint3Ctrl())
							{
								aux2.setPoint3Ctrl(p3);
								aux2.setPoint4Ctrl(p4);
								break;
							}
						}
						aux.setPoint3Ctrl(p4);
						aux.setPoint4Ctrl(p3);
					}
				}
				else
					creaOreja(vert, aux);
			}
		}

		public void ReduceTransiciones()
		{
			List<CTransicion> LT;
			CTransicion w;

			LT = new List<CTransicion>();

			foreach (CEstado e in listEstados)
			{
				LT.Clear();
				foreach (CTransicion t in e.getListTransicion())
					if(!t.getVisitada())
					   for (int i = 0; i < e.getListTransicion().Count; i++)
				    	{
					 		w = e.getListTransicion()[i];
							if (t != w && !w.getVisitada())
							{
								if (w.getEstadoSig() == t.getEstadoSig())
								{
                                	t.ActEtiqueta("|" + w.getEtiqueta());
                                    t.AddEtiqueta(w.getListEtiquetas()[0]);
                                    w.setVisitado(true);
									LT.Add(w);
								}
							}
					    }

				//Eliminar transiciones repetidas
				foreach (CTransicion t in LT)
					e.getListTransicion().Remove(t);
			}
		}
	}
}


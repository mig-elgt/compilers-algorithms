using System;
using System.Collections.Generic;
using System.Text;
using AFD_Subconjuntos.Clases.AFN;

namespace AFD_Subconjuntos.Clases
{
    class CSubconjuntos
    {
        //Atributos
        private CAutomata AFN;
        private CAutomata AFD;
        private List<string> alfabeto;
        private List<CEstado> conjuntoEstados;
        private List<CEstado> Lista;
        private int numEstado;
        private CEstado estadoFinal;

        //Constructor
        public CSubconjuntos() { }

        public CSubconjuntos(CAutomata AFN, List<string> alfabeto)
        {
            this.AFN = AFN;
            this.alfabeto = alfabeto;
            conjuntoEstados = new List<CEstado>();
            AFD = new CAutomata();
            numEstado = 65;
            estadoFinal = AFN.getEstadoFinal();
            Lista = new List<CEstado>();
        }

        //Metodos publicos
		/*
		 * Este método es para crear el AFD utilizando el algoritmo de subconjuntos*/
        public CAutomata creaAFD()
        {
            List<CEstado> LE, nueva;
            CEstado aux, nuevo, e;

            creaEstadoInicial();

            for (int i = 0; i < conjuntoEstados.Count; i++)//Se analiza cada subconjunto creado por la transicion de epsilon
            {
                e = conjuntoEstados[i];

				//Para el conjunto seleccionado se busca una transición con la entrada de un simbolo del alfabeto
                foreach (string w in alfabeto)
                {
                    LE = new List<CEstado>();

                    foreach (CEstado x in e.getListaEstados())
                        if ((aux = buscaTransicion(x, w)) != null)
                            LE.Add(aux);

                    if (LE.Count > 0)//Se encontro un conjunto de estados con transicion w desde e a x 
                    {
                        nueva = mueve(LE);
                        if ((aux = ExisteConjuntoEstado(nueva)) != null)
                            AFD.InsTransicion(e, aux, w);
                        else//Crear nuevo estado, insertar la transicion y agregarlo al conunto de estados
                        {
                            nuevo = new CEstado(++numEstado, "");
                            nuevo.setListaEstados(nueva);
                            AFD.AddEstado(nuevo);
                            AFD.InsTransicion(e, nuevo, w);
                            conjuntoEstados.Add(nuevo);
                        }
                    }
                }
            }

            estableceEstados();
            AFD.EstablceCoordenadas();
            return (AFD);
        }

        public void setAFN(CAutomata afn)
        {
            this.AFN = afn;
        }

        public void setAlfabeto(List<string> a)
        {
            this.alfabeto = a;
        }

        //Métodos privados
       private void estableceEstados()
        {
            int nameEstado = estadoFinal.getNombre();

            foreach (CEstado e in conjuntoEstados)
            {
                e.setEstado("Normal");
                foreach (CEstado w in e.getListaEstados())
                    if (w.getNombre() == nameEstado)
                    {
                        e.setEstado("Final");
                        break;
                    }
            }
                  
        }

		/*
		 * Se checa si el nuevo conjunto creado por la transicion de epsilon de un conjunto de estados
		 * ya existe el la la lista de subconjuntos de estaos*/
        private CEstado ExisteConjuntoEstado(List<CEstado> nueva)
        {
            CEstado estado = null;
            bool band;

            foreach (CEstado e in conjuntoEstados)
            {
                band = true;

                if (e.getListaEstados().Count == nueva.Count)
                {
                    foreach (CEstado w in nueva)
                        if (!e.getListaEstados().Contains(w))
                        {
                            band = false;
                            break;
                        }

                    if (band)
                    {
                        estado = e;
                        break;
                    }
                }
            }

            return (estado);
        }
		
		private CEstado buscaTransicion(CEstado e, string ent)
        {
            CEstado estado = null;

            foreach (CTransicion t in e.getListTransicion())
                if (t.getEtiqueta().CompareTo(ent) == 0)
                {
                    estado = t.getEstadoSig();
                    break;
                }

            return (estado);
        }

        private void creaEstadoInicial()
        {
            CEstado inicial;

            inicial = new CEstado(numEstado, "");

            inicial.setListaEstados(cerraduraEpsilon(AFN.getEstadoInicial()));
            conjuntoEstados.Add(inicial);
            AFD.AddEstado(inicial);
            AFD.setEstadoInicial(inicial);
        }

		/**Este método hace la funcion la cerradura epsilon.
		 * Recibe como parametro un estado, y entrega una losta de estados que fueron
		 * alcanzados por la cerradura epsilon*/
        private List<CEstado> cerraduraEpsilon(CEstado e)
        {
            List<CEstado> LE;

            LE = new List<CEstado>();
			buscaEstados(e, LE);
           
			foreach (CEstado w in LE)
				w.setVisitado(false);

            return (LE);
        }

        private static int ComparaEstados(CEstado a, CEstado b)
        {
            return (a.getNombre().CompareTo(b.getNombre()));
        }

        private void buscaEstados(CEstado e, List<CEstado> LE)
        {
            LE.Add(e);
			e.setVisitado(true);

            foreach (CTransicion t in e.getListTransicion())
                if (t.getEtiqueta().CompareTo("~") == 0 && !t.getEstadoSig().getVisitado())
                    buscaEstados(t.getEstadoSig(), LE);
		}

        private List<CEstado> mueve(List<CEstado> LE)
        {
            List<CEstado> nueva,aux;

            nueva = new List<CEstado>();

			foreach (CEstado e in LE)
			{
				aux = cerraduraEpsilon(e);

				foreach (CEstado w in aux)
					if (!nueva.Contains(w))
						nueva.Add(w);
			}
			
			return (nueva);
        }
	}
}
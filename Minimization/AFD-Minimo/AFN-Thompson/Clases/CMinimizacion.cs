using System;
using System.Collections.Generic;
using System.Text;
using AFD_Minimo.Clases.AFN;

namespace AFD_Subconjuntos.Clases
{
	class CMinimizacion
	{
		private CAutomata AFD;//AFD de entrada
        private CAutomata AFDM;//AFD mínimo
        private List<List<CEstado>> grupos; //Lista de grupos para las particiones
        private List<string> alfabeto;
        private int [][]M;//Matriz que contiene los indices de los grupos en alguna partición.

		public CMinimizacion() { }

		public CMinimizacion(CAutomata afd, List<string> alfabeto)
        {
            List<CEstado> eN, eA;

            this.alfabeto = alfabeto;
            eN = new List<CEstado>();
            eA = new List<CEstado>();
            
            grupos = new List<List<CEstado>>();
            afd.getEstados(eN, eA);

            //Se crea la primer particion con S y N-S grupos de estados
            if (eN.Count > 0)
            {
                if (afd.getEstadoInicial().getEstado().CompareTo("Final") == 0)
                {
                    grupos.Add(eA);
                    grupos.Add(eN);
                }
                else
                {
                    grupos.Add(eN);
                    grupos.Add(eA);
                }
            }
            else
                grupos.Add(eA);
            
            this.AFD = afd;
            AFDM = new CAutomata();
        }

        public CAutomata CreaAFD()
        {
            while (CreaAFDMinimoRec(1));

			AFDM.setEstadoInicial(AFDM.getListEstados()[0]);

			AFDM.ReduceTransiciones();
			AFDM.EstablceCoordenadas();
			estableceEstados();
            AFDM.Ordenate();

			return (AFDM);
		}

        //Método recursivo para analizar cada partición y partir los grupos de estados.
        private bool CreaAFDMinimoRec(int index)
        {
            List<CEstado> C;//Conjunto de estados de una partición que se va analizar
            List<CEstado> nuevoC;//Nuevo conjunto que sera agregado a la nueva partición
            CEstado nuevoEstado, estadoAux;
            string nameEti,nameEstado;
            int [][]MR; //Esta matriz contiene las relaciones de los estados
            bool res  = false;
            int i, j,numRel;
            bool band;

            nuevoC = null;
            C = grupos[index-1];
            M = creaMatriz(C.Count, alfabeto.Count);
            MR = creaMatriz(alfabeto.Count,2);
            numRel = 0;

			//Para cada símbolo del alfabeto, buscar los grupos correspondinetes a cada estado.
            for(j=0; j < alfabeto.Count&&!res; j++)
            {
                for(i= 0; i < C.Count; i++)
                     M[i][j] = dameGrupo(C[i],alfabeto[j]);

                 res = existeParticion(j, MR, ref nuevoC, C,ref numRel);
            }

            if (!res)//Si no hay partición, entonces continuar con el siguiente grupo de la partición
            {
                if (index < grupos.Count)
                    res = CreaAFDMinimoRec(index+1);

                //Crear los estados correspondietes
                if (!res)
                {
                    band = true;
                    if ((nuevoEstado = AFDM.buscaEstado(index.ToString())) == null)
                    {
                        nuevoEstado = new CEstado(index,"");
                        band = false;
                    }

                    for (int w = 0; w < numRel; w++)
                    {
                        nameEti = alfabeto[MR[w][0]];
                        nameEstado = MR[w][1].ToString();
                        estadoAux = AFDM.buscaEstado(nameEstado);

                        if (MR[w][1] == index)
                            estadoAux = nuevoEstado;
                        else
                           if (estadoAux == null)
                           {
                              estadoAux = new CEstado(MR[w][1],"");
                              AFDM.AddEstado(estadoAux);
                           }

                        AFDM.InsTransicion(nuevoEstado, estadoAux, nameEti);
                    }

                    if (!band)
                       AFDM.AddEstado(nuevoEstado);

                   AFDM.Ordenate();
                }
            }
            else//Se agrega el nuevo conjunto a otra partición.
            {
                foreach (CEstado e in nuevoC)
                    grupos[index - 1].Remove(e); 

                grupos.Insert(index-1, nuevoC);
            }

            return (res);
        }

		//Asigna el tipo de estado, para alguno estado nuevo en el AFDM
		private void estableceEstados()
		{
			foreach (List<CEstado> L in grupos)
				foreach (CEstado e in L)
					if (e.getEstado().CompareTo("Final") == 0)
					{
						AFDM.getListEstados()[grupos.IndexOf(L)].setEstado("Final");
						break;
					}
		}

		private string obtenEstado(int g)
		{ 
			string estado = "Normal";

			foreach (CEstado e in grupos[g])
				if (e.getEstado().CompareTo("Final") == 0)
				{
					estado = "Final";
					break;
				}
			
			return(estado);
		}

        private bool existeParticion(int col, int[][] MR, ref List<CEstado> nuevoC, List<CEstado> C,ref int nR)
        {
            List<CGrupo> L;
            bool res = false;
            int cont, indEst;

            L = new List<CGrupo>();
            nuevoC = new List<CEstado>();
            indEst = 0;
            cont = C.Count;

            for (int i = 0; i < C.Count; i++)
                  creaGrupos(L, C[i], M[i][col]);
             
            
            if (L.Count > 1)
            {
                nuevoC = L[0].getConjunto();
                res = true;
            }
            else
                if (C.Count == L[0].getConjunto().Count)
                    {
                        if (L[0].getGrupo() != 0)
                        {   
                            //No hay partición
                            MR[nR][0] = col;
                            MR[nR][1] = L[0].getGrupo();
                            nR++;
                        }
                    }
                    else
                    {
                        nuevoC = L[0].getConjunto();
                        res = true;
                    }
           
            return (res);
        }

        //iE : Indice del estado para el AFD-Min
        private void creaGrupos(List<CGrupo> LG, CEstado e, int iE)
        {
            bool band;

            if (LG.Count == 0)
                creaGrupoNuevo(LG, e, iE);
            else//Buscar el nuevo grupo
            {
                band = false;

                foreach (CGrupo g in LG)
                    if (g.getGrupo() == iE)
                    {
                        g.AddGrupo(e);
                        band = true;
                        break;
                    }

                if (!band)//Si un nuevo grupo
                    creaGrupoNuevo(LG, e, iE);
            }
        }

        private void creaGrupoNuevo(List<CGrupo> LG, CEstado e, int iE)
        {
            CGrupo grupAux;

            grupAux = new CGrupo();
            grupAux.setGrupo(iE);
            grupAux.AddGrupo(e);

            LG.Add(grupAux);
        }

        private int dameGrupo(CEstado estadoAct, string carEnt)
        {
            CEstado estadoSig = null;
            int g = 0;

            foreach (CTransicion t in estadoAct.getListTransicion())
                if (t.getEtiqueta().CompareTo(carEnt) == 0)
                {
                    estadoSig = t.getEstadoSig();
                    break;
                }

            foreach (List<CEstado> G in grupos)
                if (G.Contains(estadoSig))
                {
                    g = grupos.IndexOf(G)+1;
                    break;
                }

            return (g);
        }

        private int [][] creaMatriz(int nR, int nC)
        { 
            int [][]M = new int[nR][];

            for (int i = 0; i < nR; i++)
                M[i] = new int[nC];

            return (M);
        }
	}

    class CGrupo
    {
        private int grupo;//Indica un grupo de la particion
        private List<CEstado> listaEstados;//Representa un subconjunto de un una particion

        public CGrupo() 
        {
            listaEstados = new List<CEstado>();
        }

        public void setGrupo(int g)
        {
            this.grupo = g;
        }

        public int getGrupo()
        {
            return (this.grupo);
        }

        public void AddGrupo(CEstado e)
        {
            listaEstados.Add(e);
        }

        public List<CEstado> getConjunto()
        {
            return (listaEstados);
        }
    }
}

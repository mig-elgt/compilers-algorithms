using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Convertidor_de_Expresiones.Clases
{
    class CArchivo
    {
        private CExpresion exp; //Objeto que reprenta la expresion, creado una ves que se carga la aplicación.
        private DataGridView tablaP;
        private FileStream fs;
        private StreamReader sr;
        private List<List<string>> listaPruebas;//Contiene las pruebas leidas del archivo de pruebas
        private string nameFile;

        public CArchivo() { }

        public CArchivo(CExpresion exp, DataGridView t, string pathPrueba)
        {
            this.exp = exp;
            this.tablaP = t;
            this.nameFile = pathPrueba;
            listaPruebas = new List<List<string>>();
            listaPruebas.Add(new List<string>());
            listaPruebas.Add(new List<string>());
            listaPruebas.Add(new List<string>());
        }
        
        /*Se abre una archivo que contiene pruebas para validar el algoritmo
         *las pruebas son almacenadas en una estrutucturas de datos
         * para posteriormente cargarlas en la tabla presentada en el formulario
         * con sus respectivos resultados*/
        public void cargaPruebas()
        {
            string str1, str2;
            char car;
            int numList = 0;
            
            str1 = null;
            str2 = null;

            try
            {
                fs = new FileStream(nameFile, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
                str1 = null;

                while (!sr.EndOfStream)//Se recorre el archivo
                {
                    car = (char)sr.Read();

                    if (car != 10 && car != 13)
                    {
                        if (car != 9)
                            str1 += car;
                        else
                        {
                            listaPruebas[numList].Add(str1);
                            numList++;
                            str1 = null;
                        }
                    }
                    else
                    {
                        if (numList > 0 && str1 != null)
                        {
                            listaPruebas[numList].Add(str1);
                            str1 = null;
                        }

                        numList = 0;
                    }
                }

                if (str1 != null)
                    listaPruebas[numList].Add(str1);

            }
            catch (IOException)
            {
            }
                finally
                {
                    if (sr != null)
                        sr.Close();
                }

                ejecutaPruebas();
            }

        /*
         * Este método se encarga de ejecutar cada prueba leida del archivo y a su vez ir llenando 
         * el control de la tabla para mostrar los resultados*/
        private void ejecutaPruebas()
        {
              string expPosObt;
              string expNormObt;
              int fila;   

              tablaP.Rows.Clear();
              fila = 0;  

              for (int i = 0; i < listaPruebas[0].Count; i++)
              {
                  if (listaPruebas[0][i] != null)
                  {
                      tablaP.Rows.Add();
                      tablaP.Rows[fila].HeaderCell.Value = fila.ToString();
                      exp.setExp(listaPruebas[0][i]);

                      if (exp.validaExpresion())
                      {
                          expNormObt = exp.normalizate();
                          expPosObt = exp.Conviertete();
                      }
                      else
                      {
                          expNormObt = "ERROR";
                          expPosObt = "ERROR";
                      }

                      tablaP.Rows[fila].Cells[0].Value = (listaPruebas[0])[i];
                      for (int j = 1; j < listaPruebas.Count; j++)
                          tablaP.Rows[fila].Cells[j].Value = (listaPruebas[j])[fila];

                      tablaP.Rows[fila].Cells[3].Value = expNormObt;
                      tablaP.Rows[fila].Cells[4].Value = expPosObt;

                      if (expPosObt.CompareTo(listaPruebas[2][fila]) == 0 && expNormObt.CompareTo(listaPruebas[1][fila]) == 0)
                          tablaP.Rows[fila].Cells[5].Value = "OK";
                      else
                          tablaP.Rows[fila].Cells[5].Value = "ERROR";

                      fila++;
                  }
              }    
        }
    }
}

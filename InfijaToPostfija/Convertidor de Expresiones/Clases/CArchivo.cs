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

                    if (car != 9 && numList == 0)
                        str1 += car.ToString();
                    else
                        if (numList != 1)
                        {
                            listaPruebas[numList].Add(str1);
                            str1 = null;
                            numList = 1;
                        }

                    if (car != 9 && numList == 1)
                        if (car != 13)
                            if (car != 10)
                                str2 += car.ToString();
                            else
                            {
                                listaPruebas[numList].Add(str2);
                                str2 = null;
                                numList = 0;
                            }
                }

                if (str2 != null) 
                      listaPruebas[numList].Add(str2);
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
         * Este método se encarga de ejecutar cada prueba leida del archivo y a su ves ir llenando 
         * el control de la tabla para mostrar los resultados*/
        private void ejecutaPruebas()
        {
              string expObt;

              tablaP.Rows.Clear();
        
              for (int i = 0; i < listaPruebas[0].Count; i++)
              {
                  tablaP.Rows.Add();
                  tablaP.Rows[i].HeaderCell.Value = i.ToString();
                  exp.setExp(listaPruebas[0][i]);
                  expObt = exp.Conviertete();

                  for(int j = 0; j <listaPruebas.Count; j++)
                      tablaP.Rows[i].Cells[j].Value = (listaPruebas[j])[i];

                  tablaP.Rows[i].Cells[2].Value = expObt;
                  if (expObt.CompareTo(listaPruebas[1][i]) == 0)
                      tablaP.Rows[i].Cells[3].Value = "OK";
                  else
                      tablaP.Rows[i].Cells[3].Value = "ERROR";
              }    
        }
    }
}

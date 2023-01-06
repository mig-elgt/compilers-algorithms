using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using GramaticasRegulares.Clases.Gramatica;

namespace GramaticasRegulares
{
    public partial class FPruebasReg : Form
    {
        private List<List<string>> listaPruebas;
        private string []listaFileGram;
        private FileStream fs;
        private StreamReader sr;
        private CGramatica gramatica;
        private string nameFile;
        private string dirActGram;

        public FPruebasReg()
        {
            InitializeComponent();
            gramatica = new CGramatica();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                nameFile = openFileDialog1.FileName;
                listaPruebas = new List<List<string>>();
                listaPruebas.Add(new List<string>());
                listaPruebas.Add(new List<string>());
                textBox1.Text = nameFile;
                cargaPruebas();
            }
        }

        private void cargaPruebas()
        {
            string str1;
            char car;
            int numList = 0;

            str1 = null;
         
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

        private void ejecutaPruebas()
        {
            string expRegRes,expRegObt;
            string rutaAux;
            int fila;

            tablaP.Rows.Clear();
            fila = 0;

            for (int i = 0; i < listaPruebas[0].Count; i++)
            {
                rutaAux = null;
                if (listaPruebas[0][i] != null)
                {
                    tablaP.Rows.Add();
                    tablaP.Rows[fila].HeaderCell.Value = fila.ToString();
                    rutaAux = dirActGram;
                    rutaAux += "\\" + listaPruebas[0][i]+".txt";
                    expRegRes = listaPruebas[1][fila];
                    expRegObt = null;
                    if (File.Exists(rutaAux))
                    {
                        if (abriGramatica(rutaAux))
                        {
                            gramatica.setProducciones(tbGram.Lines);

                            if (gramatica.validate())
                            {
                                gramatica.creaExpReg();
                                expRegObt = gramatica.dameExpRegFinal();
                                tablaP.Rows[fila].Cells[2].Value = expRegObt;
                            }
                            else
                                tablaP.Rows[fila].Cells[2].Value = "ERROR";

                            if (expRegRes.CompareTo(tablaP.Rows[fila].Cells[2].Value) == 0)
                                tablaP.Rows[fila].Cells[3].Value = "OK";
                            else
                                tablaP.Rows[fila].Cells[3].Value = "FALLO";
                        }

                        tablaP.Rows[fila].Cells[0].Value = (listaPruebas[0])[i];
                        for (int j = 1; j < listaPruebas.Count; j++)
                            tablaP.Rows[fila].Cells[j].Value = (listaPruebas[j])[fila];

                        fila++;
                    }
                    else
                    {
                        MessageBox.Show("El archivo " + listaPruebas[0][i] + " no existe en el directorio de las gramaticas",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        tablaP.Rows.RemoveAt(tablaP.Rows.Count - 1);
                    }
                }
            }
        }

        private bool abriGramatica(string nameFile)
        {
            FileStream fs;
            StreamReader sr;
            string text;
            bool res = false;

            text = null;
            sr = null;
            
            try
            {
                fs = new FileStream(nameFile, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);

                while (!sr.EndOfStream)//Se recorre el archivo
                    text += (char)sr.Read();

                res = true;
            }
            catch (IOException)
            {
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

            tbGram.Text = text;
            
            return (res);
        }
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btPathGram_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Seleccione la ubicación de las gramáticas";

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
               dirActGram = tbDirGram.Text = folderBrowserDialog1.SelectedPath;
               listaFileGram = Directory.GetFiles(dirActGram);
            }
        }

        private void tbDirGram_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GramaticasRegulares.Clases.Gramatica;
using System.IO;
using Convertidor_de_Expresiones.Clases;

namespace GramaticasRegulares
{
    public partial class Form1 : Form
    {
        private CGramatica gramaticaReg;
        private Graphics g;
        private CExpresion expRegular;
        private int dx, dy;

        public Form1()
        {
            InitializeComponent();
            gramaticaReg = new CGramatica();
            expRegular = new CExpresion();
            g = panel1.CreateGraphics();
            dx = pictureBox1.Width;
            dy = pictureBox1.Height;
        }

        private void mpGeneraExp_Click(object sender, EventArgs e)
        {
            string expReg, cadAux;

            cadAux = null;

            if (tbGramatica.Text.Length != 0)
            {
                gramaticaReg.setProducciones(tbGramatica.Lines);

                if (gramaticaReg.validate())
                {
                    gramaticaReg.creaExpReg();
                    tbExpRegObt.Text = gramaticaReg.getAtEcuacion(0).getNamePro() + " -> " + gramaticaReg.getExpReg();
                    expReg = gramaticaReg.getExpReg();
                    cadAux = gramaticaReg.dameExpRegFinal();
                    tbERF.Text = gramaticaReg.getAtEcuacion(0).getNamePro() + " -> " + cadAux;
                    expRegular.setExp(cadAux);
                    expRegular.setExpRegSim(expRegular.dameCad(expRegular.Simplificate()));
                    tbExpRegSim.Text = expRegular.getExpSimpli();
                    pictureBox1.Size = new Size(1500, pictureBox1.Height + gramaticaReg.getDY() - pictureBox1.Height);
                    DibujaPasos();
                }
                else
                    MessageBox.Show("La gramatica es incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Graphics ObtenerObjectGraphics()
        {
            Bitmap mapaBits = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            pictureBox1.Image = mapaBits;
            Graphics g = Graphics.FromImage(mapaBits);
            g.Clear(Color.White);

            return (g);
        }

        //Dibuja los pasos del algoritmo
        private void DibujaPasos()
        {
            Graphics g = ObtenerObjectGraphics();
            int x, y;

            x = y = 0;

            foreach (CLineText s in gramaticaReg.getListText())
                g.DrawString(s.getText(), new Font("Arial", 10, s.getFontStyle()), Brushes.Black, s.getX(), s.getY());
        }

        private void abriGramatica_Click(object sender, EventArgs e)
        {
            FileStream fs;
            StreamReader sr;
            string nameFile;
            string text;

            text = null;
            sr = null;
            openFileDialog1.Filter = "Archivos de prueba|*.txt";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                nameFile = openFileDialog1.FileName;

                try
                {
                    fs = new FileStream(nameFile, FileMode.Open, FileAccess.Read);
                    sr = new StreamReader(fs);
                    
                    while (!sr.EndOfStream)//Se recorre el archivo
                         text += (char)sr.Read();
                }
                catch (IOException)
                {
                }
                finally
                {
                    if (sr != null)
                        sr.Close();
                }

                tbGramatica.Text = text;
                mpGeneraExp_Click(null, null);
            }
        }

        private void saveGramatica_Click(object sender, EventArgs e)
        {
            SaveFileDialog nuevoDic = new SaveFileDialog();
            FileStream fs;
            StreamWriter sw;
            string name;
            nuevoDic.Title = "Guardar Gramatica";
            nuevoDic.Filter = "Archivo |.*txt";
            nuevoDic.FileName = "Nombre";

            if (nuevoDic.ShowDialog() == DialogResult.OK)
            {
                name = nuevoDic.FileName + ".txt";
                fs = new FileStream(name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                sw = new StreamWriter(fs);

                sw.Write(tbGramatica.Text);
                sw.Close();
            }
        }

        private void tbExpRegSim_TextChanged(object sender, EventArgs e)
        {
            CExpresion expNueva;
            
            expNueva = new CExpresion();
            expNueva.setExp(expRegular.getExpSimpli());
            tbExpRegNorm.Text = expNueva.normalizate();
            tbExpRegPosf.Text = expNueva.Conviertete();
        }

        private void tbExpRegObt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            expRegular.setExp(tbERF.Text);
            expRegular.setExpRegSim(expRegular.dameCad(expRegular.Simplificate()));
            tbExpRegSim.Text = expRegular.getExpSimpli();
        }

        private void btPruebasReg_Click(object sender, EventArgs e)
        {
            FPruebasReg dlg = new FPruebasReg();

            dlg.ShowDialog();
        }
    }
}
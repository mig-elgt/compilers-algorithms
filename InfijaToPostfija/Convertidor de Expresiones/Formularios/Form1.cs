using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Convertidor_de_Expresiones.Clases;
using System.IO;

namespace Convertidor_de_Expresiones
{
    public partial class Form1 : Form
    {
        private CExpresion expresion;

        public Form1()
        {
            InitializeComponent();
        }

        private void btConvertir_Click(object sender, EventArgs e)
        {
            if (tbExpInf.Text == "")
                MessageBox.Show("Escriba una expresión","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                expresion.setExp(tbExpInf.Text);
                tBExpPosfija.Text = expresion.Conviertete();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            expresion = new CExpresion(); 
        }

        private void btPruebaRegresion_Click(object sender, EventArgs e)
        {
             openFileDialog1.Filter = "Archivos de prueba|*.txt";

             if (openFileDialog1.ShowDialog() == DialogResult.OK)
                 (new CArchivo(expresion, tablaPruebas, openFileDialog1.FileName)).cargaPruebas();
        }
    }
}
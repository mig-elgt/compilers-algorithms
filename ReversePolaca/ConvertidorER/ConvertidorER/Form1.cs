using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Convertidor_de_Expresiones.Clases;

namespace ConvertidorER
{
    public partial class Form1 : Form
    {
        private CExpresion expReg;

        public Form1()
        {
             InitializeComponent();
             expReg = new CExpresion();
        }
        
        private void btNormalizaExp_Click(object sender, EventArgs e)
        {
            expReg.setExp(tbExpReg.Text);

            if ( tbExpReg.Text.Length > 0 && expReg.validaExpresion())
            {
                tbExpNorm.Text = expReg.normalizate();
                lbExpPosfija.Text = expReg.Conviertete();
            }
            else
            {
                tbExpNorm.Text = "ERROR";
                lbExpPosfija.Text = "ERROR";
            }
        }

        private void btLeerPruebas_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos de prueba|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                (new CArchivo(expReg, tablaPruebasReg, openFileDialog1.FileName)).cargaPruebas();
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
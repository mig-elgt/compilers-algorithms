namespace GramaticasRegulares
{
    partial class FPruebasReg
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tablaP = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btPathGram = new System.Windows.Forms.Button();
            this.tbDirGram = new System.Windows.Forms.TextBox();
            this.tbGram = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tablaP)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Leer Archivo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(131, 365);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(690, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tablaP
            // 
            this.tablaP.AllowUserToAddRows = false;
            this.tablaP.AllowUserToDeleteRows = false;
            this.tablaP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.tablaP.Location = new System.Drawing.Point(38, 74);
            this.tablaP.Name = "tablaP";
            this.tablaP.ReadOnly = true;
            this.tablaP.Size = new System.Drawing.Size(783, 282);
            this.tablaP.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Gramatica";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ER Esperada";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "ER Obtenida";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Estado";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(734, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btPathGram
            // 
            this.btPathGram.Location = new System.Drawing.Point(38, 12);
            this.btPathGram.Name = "btPathGram";
            this.btPathGram.Size = new System.Drawing.Size(96, 56);
            this.btPathGram.TabIndex = 4;
            this.btPathGram.Text = "Ubicación de las gramaticas";
            this.btPathGram.UseVisualStyleBackColor = true;
            this.btPathGram.Click += new System.EventHandler(this.btPathGram_Click);
            // 
            // tbDirGram
            // 
            this.tbDirGram.Location = new System.Drawing.Point(140, 31);
            this.tbDirGram.Name = "tbDirGram";
            this.tbDirGram.Size = new System.Drawing.Size(681, 20);
            this.tbDirGram.TabIndex = 5;
            this.tbDirGram.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDirGram_KeyPress);
            // 
            // tbGram
            // 
            this.tbGram.Location = new System.Drawing.Point(38, 491);
            this.tbGram.Multiline = true;
            this.tbGram.Name = "tbGram";
            this.tbGram.Size = new System.Drawing.Size(100, 20);
            this.tbGram.TabIndex = 6;
            // 
            // FPruebasReg
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(851, 439);
            this.Controls.Add(this.tbGram);
            this.Controls.Add(this.tbDirGram);
            this.Controls.Add(this.btPathGram);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tablaP);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FPruebasReg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FPruebasReg";
            ((System.ComponentModel.ISupportInitialize)(this.tablaP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView tablaP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btPathGram;
        private System.Windows.Forms.TextBox tbDirGram;
        private System.Windows.Forms.TextBox tbGram;
    }
}
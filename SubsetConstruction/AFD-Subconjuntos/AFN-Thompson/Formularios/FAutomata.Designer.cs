namespace AFN_Thompson.Formularios
{
    partial class FAutomata
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btAcercar = new System.Windows.Forms.Button();
            this.btAlejar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 559);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(852, 539);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btAcercar
            // 
            this.btAcercar.Location = new System.Drawing.Point(707, 610);
            this.btAcercar.Name = "btAcercar";
            this.btAcercar.Size = new System.Drawing.Size(75, 23);
            this.btAcercar.TabIndex = 4;
            this.btAcercar.Text = "Acercar";
            this.btAcercar.UseVisualStyleBackColor = true;
            this.btAcercar.Click += new System.EventHandler(this.btAcercar_Click);
            // 
            // btAlejar
            // 
            this.btAlejar.Location = new System.Drawing.Point(788, 610);
            this.btAlejar.Name = "btAlejar";
            this.btAlejar.Size = new System.Drawing.Size(75, 23);
            this.btAlejar.TabIndex = 5;
            this.btAlejar.Text = "Alejar";
            this.btAlejar.UseVisualStyleBackColor = true;
            this.btAlejar.Click += new System.EventHandler(this.btAlejar_Click);
            // 
            // FAutomata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 674);
            this.Controls.Add(this.btAlejar);
            this.Controls.Add(this.btAcercar);
            this.Controls.Add(this.panel1);
            this.Name = "FAutomata";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thompson";
            this.Load += new System.EventHandler(this.FAutomata_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btAcercar;
        private System.Windows.Forms.Button btAlejar;
    }
}
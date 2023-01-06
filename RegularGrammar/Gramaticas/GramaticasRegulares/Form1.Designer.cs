namespace GramaticasRegulares
{
    partial class Form1
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
            this.tbGramatica = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tbExpRegObt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbExpRegSim = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbERF = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbExpRegNorm = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbExpRegPosf = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btPruebasReg = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.abriGramatica = new System.Windows.Forms.ToolStripButton();
            this.saveGramatica = new System.Windows.Forms.ToolStripButton();
            this.mpGeneraExp = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbGramatica
            // 
            this.tbGramatica.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGramatica.Location = new System.Drawing.Point(15, 43);
            this.tbGramatica.Multiline = true;
            this.tbGramatica.Name = "tbGramatica";
            this.tbGramatica.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbGramatica.Size = new System.Drawing.Size(163, 271);
            this.tbGramatica.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(25, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 271);
            this.panel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(260, 422);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Expresión Regular :";
            // 
            // tbExpRegObt
            // 
            this.tbExpRegObt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbExpRegObt.Location = new System.Drawing.Point(383, 417);
            this.tbExpRegObt.Name = "tbExpRegObt";
            this.tbExpRegObt.Size = new System.Drawing.Size(624, 22);
            this.tbExpRegObt.TabIndex = 2;
            this.tbExpRegObt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbExpRegObt_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(27, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "ER Simplificada :";
            // 
            // tbExpRegSim
            // 
            this.tbExpRegSim.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbExpRegSim.Location = new System.Drawing.Point(134, 28);
            this.tbExpRegSim.Name = "tbExpRegSim";
            this.tbExpRegSim.Size = new System.Drawing.Size(619, 22);
            this.tbExpRegSim.TabIndex = 4;
            this.tbExpRegSim.TextChanged += new System.EventHandler(this.tbExpRegSim_TextChanged);
            this.tbExpRegSim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbExpRegObt_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Location = new System.Drawing.Point(251, 456);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Expresion Regular F :";
            // 
            // tbERF
            // 
            this.tbERF.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbERF.Location = new System.Drawing.Point(383, 449);
            this.tbERF.Name = "tbERF";
            this.tbERF.Size = new System.Drawing.Size(624, 22);
            this.tbERF.TabIndex = 3;
            this.tbERF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbExpRegObt_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label6.Location = new System.Drawing.Point(26, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "ER Normalizada :";
            // 
            // tbExpRegNorm
            // 
            this.tbExpRegNorm.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbExpRegNorm.Location = new System.Drawing.Point(134, 55);
            this.tbExpRegNorm.Name = "tbExpRegNorm";
            this.tbExpRegNorm.Size = new System.Drawing.Size(619, 22);
            this.tbExpRegNorm.TabIndex = 5;
            this.tbExpRegNorm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbExpRegObt_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(31, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "Polaca Inversa :";
            // 
            // tbExpRegPosf
            // 
            this.tbExpRegPosf.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbExpRegPosf.Location = new System.Drawing.Point(134, 81);
            this.tbExpRegPosf.Name = "tbExpRegPosf";
            this.tbExpRegPosf.Size = new System.Drawing.Size(619, 22);
            this.tbExpRegPosf.TabIndex = 6;
            this.tbExpRegPosf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbExpRegObt_KeyPress);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(39, 39);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abriGramatica,
            this.saveGramatica,
            this.toolStripSeparator1,
            this.mpGeneraExp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1069, 46);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbGramatica);
            this.groupBox1.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(25, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 334);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gramatica Regular";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(249, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(808, 332);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pasos para la Conversión";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.tbExpRegNorm);
            this.groupBox3.Controls.Add(this.tbExpRegSim);
            this.groupBox3.Controls.Add(this.tbExpRegPosf);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(254, 497);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(775, 121);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Conversión a Polaca Inversa";
            // 
            // btPruebasReg
            // 
            this.btPruebasReg.Location = new System.Drawing.Point(25, 417);
            this.btPruebasReg.Name = "btPruebasReg";
            this.btPruebasReg.Size = new System.Drawing.Size(200, 34);
            this.btPruebasReg.TabIndex = 10;
            this.btPruebasReg.Text = "Pruebas  de Regresión";
            this.btPruebasReg.UseVisualStyleBackColor = true;
            this.btPruebasReg.Click += new System.EventHandler(this.btPruebasReg_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(730, 265);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // abriGramatica
            // 
            this.abriGramatica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.abriGramatica.Image = global::GramaticasRegulares.Properties.Resources.OpenGramatica;
            this.abriGramatica.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.abriGramatica.Name = "abriGramatica";
            this.abriGramatica.Size = new System.Drawing.Size(43, 43);
            this.abriGramatica.Text = "&Abrir";
            this.abriGramatica.Click += new System.EventHandler(this.abriGramatica_Click);
            // 
            // saveGramatica
            // 
            this.saveGramatica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveGramatica.Image = global::GramaticasRegulares.Properties.Resources.SaveGramatica;
            this.saveGramatica.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveGramatica.Name = "saveGramatica";
            this.saveGramatica.Size = new System.Drawing.Size(43, 43);
            this.saveGramatica.Text = "&Guardar";
            this.saveGramatica.Click += new System.EventHandler(this.saveGramatica_Click);
            // 
            // mpGeneraExp
            // 
            this.mpGeneraExp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mpGeneraExp.Image = global::GramaticasRegulares.Properties.Resources.Start;
            this.mpGeneraExp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mpGeneraExp.Name = "mpGeneraExp";
            this.mpGeneraExp.Size = new System.Drawing.Size(43, 43);
            this.mpGeneraExp.Text = "Crear Expresión Regular";
            this.mpGeneraExp.Click += new System.EventHandler(this.mpGeneraExp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1069, 634);
            this.Controls.Add(this.btPruebasReg);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tbERF);
            this.Controls.Add(this.tbExpRegObt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gramaticas Regulares";
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbGramatica;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbExpRegObt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbExpRegSim;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbERF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbExpRegNorm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbExpRegPosf;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton abriGramatica;
        private System.Windows.Forms.ToolStripButton saveGramatica;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mpGeneraExp;
        private System.Windows.Forms.Button btPruebasReg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}


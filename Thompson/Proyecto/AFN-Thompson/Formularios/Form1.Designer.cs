namespace AFN_Thompson
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
            this.tbExpReg = new System.Windows.Forms.TextBox();
            this.btCrearAFN = new System.Windows.Forms.Button();
            this.treViewAFN = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbGramatica = new System.Windows.Forms.TextBox();
            this.btCrearExpReg = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pagePruebas = new System.Windows.Forms.TabPage();
            this.tbPathPruebasReg = new System.Windows.Forms.TextBox();
            this.tbLeerPruebas = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tablaPruebas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageThompson = new System.Windows.Forms.TabPage();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btAcercar = new System.Windows.Forms.Button();
            this.btAlejar = new System.Windows.Forms.Button();
            this.pictureThompson = new System.Windows.Forms.PictureBox();
            this.MenuAbrirGramatica = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pagePruebas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPruebas)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.pageThompson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureThompson)).BeginInit();
            this.SuspendLayout();
            // 
            // tbExpReg
            // 
            this.tbExpReg.Location = new System.Drawing.Point(277, 59);
            this.tbExpReg.Name = "tbExpReg";
            this.tbExpReg.Size = new System.Drawing.Size(227, 20);
            this.tbExpReg.TabIndex = 0;
            // 
            // btCrearAFN
            // 
            this.btCrearAFN.Location = new System.Drawing.Point(522, 56);
            this.btCrearAFN.Name = "btCrearAFN";
            this.btCrearAFN.Size = new System.Drawing.Size(75, 23);
            this.btCrearAFN.TabIndex = 1;
            this.btCrearAFN.Text = "Crear AFN";
            this.btCrearAFN.UseVisualStyleBackColor = true;
            this.btCrearAFN.Click += new System.EventHandler(this.button1_Click);
            // 
            // treViewAFN
            // 
            this.treViewAFN.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treViewAFN.Location = new System.Drawing.Point(20, 31);
            this.treViewAFN.Name = "treViewAFN";
            this.treViewAFN.Size = new System.Drawing.Size(184, 309);
            this.treViewAFN.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(277, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Espresión Regular";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAbrirGramatica});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1072, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treViewAFN);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(25, 288);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 350);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Árbol de Relación";
            // 
            // tbGramatica
            // 
            this.tbGramatica.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGramatica.Location = new System.Drawing.Point(20, 38);
            this.tbGramatica.Multiline = true;
            this.tbGramatica.Name = "tbGramatica";
            this.tbGramatica.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbGramatica.Size = new System.Drawing.Size(184, 138);
            this.tbGramatica.TabIndex = 7;
            // 
            // btCrearExpReg
            // 
            this.btCrearExpReg.Location = new System.Drawing.Point(20, 182);
            this.btCrearExpReg.Name = "btCrearExpReg";
            this.btCrearExpReg.Size = new System.Drawing.Size(184, 27);
            this.btCrearExpReg.TabIndex = 8;
            this.btCrearExpReg.Text = "Crear Exp. Regular";
            this.btCrearExpReg.UseVisualStyleBackColor = true;
            this.btCrearExpReg.Click += new System.EventHandler(this.btCrearExpReg_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbGramatica);
            this.groupBox2.Controls.Add(this.btCrearExpReg);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(25, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 223);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gramática Regular";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.statusStrip1.Location = new System.Drawing.Point(0, 650);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1072, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pagePruebas
            // 
            this.pagePruebas.Controls.Add(this.tbPathPruebasReg);
            this.pagePruebas.Controls.Add(this.tbLeerPruebas);
            this.pagePruebas.Controls.Add(this.radioButton1);
            this.pagePruebas.Controls.Add(this.tablaPruebas);
            this.pagePruebas.Location = new System.Drawing.Point(4, 22);
            this.pagePruebas.Name = "pagePruebas";
            this.pagePruebas.Padding = new System.Windows.Forms.Padding(3);
            this.pagePruebas.Size = new System.Drawing.Size(762, 501);
            this.pagePruebas.TabIndex = 3;
            this.pagePruebas.Text = "Pruebas de Regresión";
            this.pagePruebas.UseVisualStyleBackColor = true;
            // 
            // tbPathPruebasReg
            // 
            this.tbPathPruebasReg.Enabled = false;
            this.tbPathPruebasReg.Location = new System.Drawing.Point(98, 455);
            this.tbPathPruebasReg.Name = "tbPathPruebasReg";
            this.tbPathPruebasReg.Size = new System.Drawing.Size(647, 20);
            this.tbPathPruebasReg.TabIndex = 3;
            // 
            // tbLeerPruebas
            // 
            this.tbLeerPruebas.Location = new System.Drawing.Point(17, 452);
            this.tbLeerPruebas.Name = "tbLeerPruebas";
            this.tbLeerPruebas.Size = new System.Drawing.Size(75, 23);
            this.tbLeerPruebas.TabIndex = 2;
            this.tbLeerPruebas.Text = "Leer Archivo";
            this.tbLeerPruebas.UseVisualStyleBackColor = true;
            this.tbLeerPruebas.Click += new System.EventHandler(this.tbLeerPruebas_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 29);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(75, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Thompson";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // tablaPruebas
            // 
            this.tablaPruebas.AllowUserToAddRows = false;
            this.tablaPruebas.AllowUserToDeleteRows = false;
            this.tablaPruebas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaPruebas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaPruebas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.tablaPruebas.Location = new System.Drawing.Point(17, 66);
            this.tablaPruebas.Name = "tablaPruebas";
            this.tablaPruebas.ReadOnly = true;
            this.tablaPruebas.Size = new System.Drawing.Size(728, 370);
            this.tablaPruebas.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Expresión Regular";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Thompson Esperado";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Thompson Obtenido";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Estado";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pageThompson);
            this.tabControl1.Controls.Add(this.pagePruebas);
            this.tabControl1.Location = new System.Drawing.Point(277, 105);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(770, 527);
            this.tabControl1.TabIndex = 11;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // pageThompson
            // 
            this.pageThompson.AutoScroll = true;
            this.pageThompson.Controls.Add(this.pictureThompson);
            this.pageThompson.Location = new System.Drawing.Point(4, 22);
            this.pageThompson.Name = "pageThompson";
            this.pageThompson.Padding = new System.Windows.Forms.Padding(3);
            this.pageThompson.Size = new System.Drawing.Size(762, 501);
            this.pageThompson.TabIndex = 0;
            this.pageThompson.Text = "Thompson";
            this.pageThompson.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btAcercar
            // 
            this.btAcercar.Image = global::AFN_Thompson.Properties.Resources._1352934237_Zoom_In;
            this.btAcercar.Location = new System.Drawing.Point(983, 59);
            this.btAcercar.Name = "btAcercar";
            this.btAcercar.Size = new System.Drawing.Size(57, 60);
            this.btAcercar.TabIndex = 12;
            this.btAcercar.UseVisualStyleBackColor = true;
            this.btAcercar.Click += new System.EventHandler(this.AcercaAutomata);
            // 
            // btAlejar
            // 
            this.btAlejar.Image = global::AFN_Thompson.Properties.Resources._1352934239_Zoom_Out;
            this.btAlejar.Location = new System.Drawing.Point(918, 59);
            this.btAlejar.Name = "btAlejar";
            this.btAlejar.Size = new System.Drawing.Size(59, 60);
            this.btAlejar.TabIndex = 12;
            this.btAlejar.UseVisualStyleBackColor = true;
            this.btAlejar.Click += new System.EventHandler(this.AlejaAutomata);
            // 
            // pictureThompson
            // 
            this.pictureThompson.Location = new System.Drawing.Point(6, 6);
            this.pictureThompson.Name = "pictureThompson";
            this.pictureThompson.Size = new System.Drawing.Size(735, 475);
            this.pictureThompson.TabIndex = 1;
            this.pictureThompson.TabStop = false;
            // 
            // MenuAbrirGramatica
            // 
            this.MenuAbrirGramatica.ForeColor = System.Drawing.Color.Black;
            this.MenuAbrirGramatica.Image = global::AFN_Thompson.Properties.Resources.OpenGramatica;
            this.MenuAbrirGramatica.Name = "MenuAbrirGramatica";
            this.MenuAbrirGramatica.Size = new System.Drawing.Size(122, 24);
            this.MenuAbrirGramatica.Text = "Abrir Gramática";
            this.MenuAbrirGramatica.Click += new System.EventHandler(this.MenuAbrirGramatica_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1072, 672);
            this.Controls.Add(this.btAcercar);
            this.Controls.Add(this.btAlejar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btCrearAFN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbExpReg);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AFN con Reglas de Thompson";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pagePruebas.ResumeLayout(false);
            this.pagePruebas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPruebas)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.pageThompson.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureThompson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbExpReg;
        private System.Windows.Forms.Button btCrearAFN;
        private System.Windows.Forms.TreeView treViewAFN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbGramatica;
        private System.Windows.Forms.Button btCrearExpReg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem MenuAbrirGramatica;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btAlejar;
        private System.Windows.Forms.Button btAcercar;
        private System.Windows.Forms.TabPage pagePruebas;
        private System.Windows.Forms.TextBox tbPathPruebasReg;
        private System.Windows.Forms.Button tbLeerPruebas;
        private System.Windows.Forms.DataGridView tablaPruebas;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pageThompson;
        private System.Windows.Forms.PictureBox pictureThompson;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}


namespace AFD_Subconjuntos
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
            this.components = new System.ComponentModel.Container();
            this.treViewAFN = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuAbrirGramatica = new System.Windows.Forms.ToolStripMenuItem();
            this.moverEsatdoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moverAutómataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbGramatica = new System.Windows.Forms.TextBox();
            this.btCrearExpReg = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btAcercar = new System.Windows.Forms.Button();
            this.btAlejar = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pageThompson = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureThompson = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tbPathPruebasReg = new System.Windows.Forms.TextBox();
            this.tbLeerPruebas = new System.Windows.Forms.Button();
            this.tablaPruebas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbExpReg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btCrearAFN = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btEjecutarSim = new System.Windows.Forms.Button();
            this.tbCadena = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pageThompson.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureThompson)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPruebas)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // treViewAFN
            // 
            this.treViewAFN.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treViewAFN.Location = new System.Drawing.Point(20, 21);
            this.treViewAFN.Name = "treViewAFN";
            this.treViewAFN.Size = new System.Drawing.Size(184, 381);
            this.treViewAFN.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAbrirGramatica,
            this.moverEsatdoToolStripMenuItem,
            this.moverAutómataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1172, 43);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuAbrirGramatica
            // 
            this.MenuAbrirGramatica.ForeColor = System.Drawing.Color.Black;
            this.MenuAbrirGramatica.Image = global::AFD_Subconjuntos.Properties.Resources.OpenGramatica;
            this.MenuAbrirGramatica.Name = "MenuAbrirGramatica";
            this.MenuAbrirGramatica.Size = new System.Drawing.Size(137, 39);
            this.MenuAbrirGramatica.Text = "Abrir Gramática";
            this.MenuAbrirGramatica.Click += new System.EventHandler(this.MenuAbrirGramatica_Click);
            // 
            // moverEsatdoToolStripMenuItem
            // 
            this.moverEsatdoToolStripMenuItem.Image = global::AFD_Subconjuntos.Properties.Resources.mueveNodo1;
            this.moverEsatdoToolStripMenuItem.Name = "moverEsatdoToolStripMenuItem";
            this.moverEsatdoToolStripMenuItem.Size = new System.Drawing.Size(126, 39);
            this.moverEsatdoToolStripMenuItem.Text = "Mover Estado";
            this.moverEsatdoToolStripMenuItem.Click += new System.EventHandler(this.moverEsatdoToolStripMenuItem_Click);
            // 
            // moverAutómataToolStripMenuItem
            // 
            this.moverAutómataToolStripMenuItem.Image = global::AFD_Subconjuntos.Properties.Resources.mueveGrafo1;
            this.moverAutómataToolStripMenuItem.Name = "moverAutómataToolStripMenuItem";
            this.moverAutómataToolStripMenuItem.Size = new System.Drawing.Size(144, 39);
            this.moverAutómataToolStripMenuItem.Text = "Mover Autómata";
            this.moverAutómataToolStripMenuItem.Click += new System.EventHandler(this.moverAutómataToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treViewAFN);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(25, 258);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 413);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Árbol de Relación";
            // 
            // tbGramatica
            // 
            this.tbGramatica.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGramatica.Location = new System.Drawing.Point(20, 21);
            this.tbGramatica.Multiline = true;
            this.tbGramatica.Name = "tbGramatica";
            this.tbGramatica.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbGramatica.Size = new System.Drawing.Size(184, 131);
            this.tbGramatica.TabIndex = 7;
            // 
            // btCrearExpReg
            // 
            this.btCrearExpReg.Location = new System.Drawing.Point(39, 158);
            this.btCrearExpReg.Name = "btCrearExpReg";
            this.btCrearExpReg.Size = new System.Drawing.Size(147, 25);
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
            this.groupBox2.Location = new System.Drawing.Point(25, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 197);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gramática Regular";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btAcercar
            // 
            this.btAcercar.Image = global::AFD_Subconjuntos.Properties.Resources._1352934237_Zoom_In;
            this.btAcercar.Location = new System.Drawing.Point(19, 453);
            this.btAcercar.Name = "btAcercar";
            this.btAcercar.Size = new System.Drawing.Size(57, 60);
            this.btAcercar.TabIndex = 12;
            this.btAcercar.UseVisualStyleBackColor = true;
            this.btAcercar.Click += new System.EventHandler(this.AcercaAutomata);
            // 
            // btAlejar
            // 
            this.btAlejar.Image = global::AFD_Subconjuntos.Properties.Resources._1352934239_Zoom_Out;
            this.btAlejar.Location = new System.Drawing.Point(17, 387);
            this.btAlejar.Name = "btAlejar";
            this.btAlejar.Size = new System.Drawing.Size(59, 60);
            this.btAlejar.TabIndex = 12;
            this.btAlejar.UseVisualStyleBackColor = true;
            this.btAlejar.Click += new System.EventHandler(this.AlejaAutomata);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(862, 516);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "AFD";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPage1_Paint);
            this.tabPage1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabPage1_MouseMove);
            this.tabPage1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tabPage1_Scroll);
            this.tabPage1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPage1_MouseDown);
            // 
            // pageThompson
            // 
            this.pageThompson.AutoScroll = true;
            this.pageThompson.BackColor = System.Drawing.Color.DarkGray;
            this.pageThompson.Controls.Add(this.panel1);
            this.pageThompson.Controls.Add(this.btAcercar);
            this.pageThompson.Controls.Add(this.btAlejar);
            this.pageThompson.Location = new System.Drawing.Point(4, 22);
            this.pageThompson.Name = "pageThompson";
            this.pageThompson.Padding = new System.Windows.Forms.Padding(3);
            this.pageThompson.Size = new System.Drawing.Size(862, 516);
            this.pageThompson.TabIndex = 0;
            this.pageThompson.Text = "AFN";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureThompson);
            this.panel1.Location = new System.Drawing.Point(93, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 507);
            this.panel1.TabIndex = 13;
            // 
            // pictureThompson
            // 
            this.pictureThompson.BackColor = System.Drawing.Color.White;
            this.pictureThompson.Location = new System.Drawing.Point(3, 3);
            this.pictureThompson.Name = "pictureThompson";
            this.pictureThompson.Size = new System.Drawing.Size(743, 494);
            this.pictureThompson.TabIndex = 1;
            this.pictureThompson.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pageThompson);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(277, 129);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(870, 542);
            this.tabControl1.TabIndex = 11;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.radioButton1);
            this.tabPage2.Controls.Add(this.tbPathPruebasReg);
            this.tabPage2.Controls.Add(this.tbLeerPruebas);
            this.tabPage2.Controls.Add(this.tablaPruebas);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(862, 516);
            this.tabPage2.TabIndex = 6;
            this.tabPage2.Text = "Pruebas de Regresión";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(67, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(114, 17);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "AFD-Subconjuntos";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // tbPathPruebasReg
            // 
            this.tbPathPruebasReg.Enabled = false;
            this.tbPathPruebasReg.Location = new System.Drawing.Point(148, 475);
            this.tbPathPruebasReg.Name = "tbPathPruebasReg";
            this.tbPathPruebasReg.Size = new System.Drawing.Size(647, 20);
            this.tbPathPruebasReg.TabIndex = 9;
            // 
            // tbLeerPruebas
            // 
            this.tbLeerPruebas.Location = new System.Drawing.Point(67, 472);
            this.tbLeerPruebas.Name = "tbLeerPruebas";
            this.tbLeerPruebas.Size = new System.Drawing.Size(75, 23);
            this.tbLeerPruebas.TabIndex = 8;
            this.tbLeerPruebas.Text = "Leer Archivo";
            this.tbLeerPruebas.UseVisualStyleBackColor = true;
            this.tbLeerPruebas.Click += new System.EventHandler(this.tbLeerPruebas_Click);
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
            this.tablaPruebas.Location = new System.Drawing.Point(67, 62);
            this.tablaPruebas.Name = "tablaPruebas";
            this.tablaPruebas.ReadOnly = true;
            this.tablaPruebas.Size = new System.Drawing.Size(728, 391);
            this.tablaPruebas.TabIndex = 7;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Expresión Regular";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "AFD Esperado";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "AFD Obtenido";
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
            // tbExpReg
            // 
            this.tbExpReg.Location = new System.Drawing.Point(277, 74);
            this.tbExpReg.Name = "tbExpReg";
            this.tbExpReg.Size = new System.Drawing.Size(305, 20);
            this.tbExpReg.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(277, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Expresión Regular";
            // 
            // btCrearAFN
            // 
            this.btCrearAFN.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCrearAFN.Location = new System.Drawing.Point(277, 100);
            this.btCrearAFN.Name = "btCrearAFN";
            this.btCrearAFN.Size = new System.Drawing.Size(190, 23);
            this.btCrearAFN.TabIndex = 1;
            this.btCrearAFN.Text = "Crear Autómatas";
            this.btCrearAFN.UseVisualStyleBackColor = true;
            this.btCrearAFN.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.trackBar1);
            this.groupBox3.Controls.Add(this.btEjecutarSim);
            this.groupBox3.Controls.Add(this.tbCadena);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Enabled = false;
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(610, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(537, 81);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Simulación";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(476, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Lento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(389, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Normal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rápido";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 30;
            this.trackBar1.Location = new System.Drawing.Point(302, 19);
            this.trackBar1.Maximum = 150;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(225, 45);
            this.trackBar1.SmallChange = 5;
            this.trackBar1.TabIndex = 3;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 75;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // btEjecutarSim
            // 
            this.btEjecutarSim.Location = new System.Drawing.Point(77, 49);
            this.btEjecutarSim.Name = "btEjecutarSim";
            this.btEjecutarSim.Size = new System.Drawing.Size(113, 26);
            this.btEjecutarSim.TabIndex = 2;
            this.btEjecutarSim.Text = "Ejecutar";
            this.btEjecutarSim.UseVisualStyleBackColor = true;
            this.btEjecutarSim.Click += new System.EventHandler(this.btEjecutarSim_Click);
            // 
            // tbCadena
            // 
            this.tbCadena.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.tbCadena.Location = new System.Drawing.Point(77, 21);
            this.tbCadena.Name = "tbCadena";
            this.tbCadena.Size = new System.Drawing.Size(206, 22);
            this.tbCadena.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cadena :";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1172, 683);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tabControl1);
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
            this.Text = "AFD-Mínimo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pageThompson.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureThompson)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPruebas)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treViewAFN;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbGramatica;
        private System.Windows.Forms.Button btCrearExpReg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem MenuAbrirGramatica;
        private System.Windows.Forms.Button btAlejar;
        private System.Windows.Forms.Button btAcercar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage pageThompson;
        private System.Windows.Forms.PictureBox pictureThompson;
		private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox tbExpReg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCrearAFN;
        private System.Windows.Forms.ToolStripMenuItem moverEsatdoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moverAutómataToolStripMenuItem;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox tbCadena;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btEjecutarSim;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox tbPathPruebasReg;
        private System.Windows.Forms.Button tbLeerPruebas;
        private System.Windows.Forms.DataGridView tablaPruebas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}


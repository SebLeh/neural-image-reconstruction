namespace Neural_Image_Recontruction
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadWeightMatrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWeightMatrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dATAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.status_bar = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.layer_box = new System.Windows.Forms.GroupBox();
            this.ui_layers = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ui_neurons = new System.Windows.Forms.NumericUpDown();
            this.ui_load = new System.Windows.Forms.Button();
            this.ui_noiseType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.status_bar.SuspendLayout();
            this.layer_box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_layers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_neurons)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.dATAToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(381, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menu";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadWeightMatrixToolStripMenuItem,
            this.saveWeightMatrixToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // loadWeightMatrixToolStripMenuItem
            // 
            this.loadWeightMatrixToolStripMenuItem.Name = "loadWeightMatrixToolStripMenuItem";
            this.loadWeightMatrixToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.loadWeightMatrixToolStripMenuItem.Text = "load weight matrix";
            // 
            // saveWeightMatrixToolStripMenuItem
            // 
            this.saveWeightMatrixToolStripMenuItem.Name = "saveWeightMatrixToolStripMenuItem";
            this.saveWeightMatrixToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.saveWeightMatrixToolStripMenuItem.Text = "save weight matrix";
            // 
            // dATAToolStripMenuItem
            // 
            this.dATAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setPathToolStripMenuItem});
            this.dATAToolStripMenuItem.Name = "dATAToolStripMenuItem";
            this.dATAToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.dATAToolStripMenuItem.Text = "DATA";
            // 
            // setPathToolStripMenuItem
            // 
            this.setPathToolStripMenuItem.Name = "setPathToolStripMenuItem";
            this.setPathToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.setPathToolStripMenuItem.Text = "set path";
            this.setPathToolStripMenuItem.Click += new System.EventHandler(this.setPathToolStripMenuItem_Click);
            // 
            // status_bar
            // 
            this.status_bar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.status_bar.Location = new System.Drawing.Point(0, 302);
            this.status_bar.Name = "status_bar";
            this.status_bar.Size = new System.Drawing.Size(381, 22);
            this.status_bar.TabIndex = 998;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // layer_box
            // 
            this.layer_box.Controls.Add(this.ui_neurons);
            this.layer_box.Controls.Add(this.label2);
            this.layer_box.Controls.Add(this.label1);
            this.layer_box.Controls.Add(this.ui_layers);
            this.layer_box.Location = new System.Drawing.Point(0, 27);
            this.layer_box.Name = "layer_box";
            this.layer_box.Size = new System.Drawing.Size(369, 177);
            this.layer_box.TabIndex = 999;
            this.layer_box.TabStop = false;
            this.layer_box.Text = "Layers";
            // 
            // ui_layers
            // 
            this.ui_layers.Location = new System.Drawing.Point(147, 19);
            this.ui_layers.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.ui_layers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ui_layers.Name = "ui_layers";
            this.ui_layers.Size = new System.Drawing.Size(120, 20);
            this.ui_layers.TabIndex = 0;
            this.ui_layers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 900;
            this.label1.Text = "Number of hidden Layers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 901;
            this.label2.Text = "Neurons per Layer";
            // 
            // ui_neurons
            // 
            this.ui_neurons.Location = new System.Drawing.Point(147, 48);
            this.ui_neurons.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.ui_neurons.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.ui_neurons.Name = "ui_neurons";
            this.ui_neurons.Size = new System.Drawing.Size(120, 20);
            this.ui_neurons.TabIndex = 1;
            this.ui_neurons.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // ui_load
            // 
            this.ui_load.Location = new System.Drawing.Point(294, 276);
            this.ui_load.Name = "ui_load";
            this.ui_load.Size = new System.Drawing.Size(75, 23);
            this.ui_load.TabIndex = 1000;
            this.ui_load.Text = "load data";
            this.ui_load.UseVisualStyleBackColor = true;
            this.ui_load.Click += new System.EventHandler(this.ui_load_Click);
            // 
            // ui_noiseType
            // 
            this.ui_noiseType.FormattingEnabled = true;
            this.ui_noiseType.Items.AddRange(new object[] {
            "Gaussian Noise (weak)",
            "Gaussian Noise (more)",
            "Gaussian Noise (strong)",
            "Salt & Pepper (weak)",
            "Salt & Pepper (more)",
            "Salt & Pepper (strong)",
            "Gauss + S&P (weak)",
            "Gauss + S&P (more)",
            "Gauss + S&P (strong)",
            "Random Gauss + S&P"});
            this.ui_noiseType.Location = new System.Drawing.Point(147, 278);
            this.ui_noiseType.Name = "ui_noiseType";
            this.ui_noiseType.Size = new System.Drawing.Size(135, 21);
            this.ui_noiseType.TabIndex = 1001;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 1002;
            this.label3.Text = "Type of data";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 324);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ui_noiseType);
            this.Controls.Add(this.ui_load);
            this.Controls.Add(this.layer_box);
            this.Controls.Add(this.status_bar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.status_bar.ResumeLayout(false);
            this.status_bar.PerformLayout();
            this.layer_box.ResumeLayout(false);
            this.layer_box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_layers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_neurons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip status_bar;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadWeightMatrixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWeightMatrixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dATAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.GroupBox layer_box;
        private System.Windows.Forms.NumericUpDown ui_neurons;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ui_layers;
        private System.Windows.Forms.Button ui_load;
        private System.Windows.Forms.ComboBox ui_noiseType;
        private System.Windows.Forms.Label label3;
    }
}


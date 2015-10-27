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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dATAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 302);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(381, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
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
            this.setPathToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.setPathToolStripMenuItem.Text = "set path";
            this.setPathToolStripMenuItem.Click += new System.EventHandler(this.setPathToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 324);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadWeightMatrixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWeightMatrixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dATAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setPathToolStripMenuItem;
    }
}


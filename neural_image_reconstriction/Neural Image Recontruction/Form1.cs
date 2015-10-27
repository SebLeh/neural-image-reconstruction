﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Neural_Image_Recontruction
{
    public partial class Form1 : Form
    {
        public string data_path = "C:\\Users\\Sebi\\OneDrive\\Dokumente\\Master\\Erasmus\\Vorlesungen\\project\\code\\data\\noisy";
        public string label_path = "C:\\Users\\Sebi\\OneDrive\\Dokumente\\Master\\Erasmus\\Vorlesungen\\project\\code\\data\\clean";
        public Form1()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            FileLoader file_loader = new FileLoader();
            file_loader.open(label_path, "gauss_5");
        }

        private void setPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = this.data_path;
            DialogResult result = fbd.ShowDialog();
            data_path = fbd.SelectedPath;
        }
    }
}

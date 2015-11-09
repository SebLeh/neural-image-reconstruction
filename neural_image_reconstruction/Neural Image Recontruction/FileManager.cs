using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Neural_Image_Recontruction
{
    class FileManager
    {
        private string file = string.Empty;
        private string defaultPath = "C:\\Users\\Sebi\\OneDrive\\Dokumente\\Master\\Erasmus\\Vorlesungen\\project\\code\\save-files";

        private double[][][] weights = new double[1][][];

        public FileManager()
        {

        }

        public void prepareSave(double[][][] weightMatrix)
        {
            weights = weightMatrix;
        }

        public void save()
        {
            file = toString(weights);

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Weights Matrix|*.wght";
            saveFile.Title = "Save Weight Matrix";
            //saveFile.ShowDialog();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                if (saveFile.FileName != string.Empty)
                {
                    try
                    {
                        File.WriteAllText(saveFile.FileName, file);
                    }
                    catch (System.IO.IOException)
                    {
                        MessageBox.Show("something went wrong... fix it, you fool!");
                    } //try
                }
                else
                {
                    MessageBox.Show("Please enter valid filename!");
                } //if
            } //if              
        } //save

        public double[][][] load()
        {
            double[][][] imgArray = new double[1][][];
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Weight Matrix|*.wght";
            openFile.Title = "Open Weight Matrix";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string path = openFile.FileName;
                string file = File.ReadAllText(path);
                imgArray = toArray(file);
            }
            return imgArray;
        } //load

        private string toString(double[][][] weights)
        {
            string file = string.Empty;
            file += "{\"number of layers\":" + weights.Length.ToString() + "}";
            file += "{\"neurons per layer\":";
            for (int i=0; i<weights.Length; i++)
            {
                file += weights[i].Length.ToString();
                if (i != weights.Length - 1)
                {
                    file += ",";
                }
            }
            file += "}";

            for (int i=0; i<weights.Length; i++)
            {
                file += "[";
                for (int j=0; j< weights[i].Length; j++)
                {
                    file += "[";
                    for (int k=0; k<weights[i][j].Length; k++)
                    {
                        file += weights[i][j][k].ToString();
                        if (k != weights[i][j].Length - 1)
                        {
                            file += ";";
                        }
                    }
                    file += "]";
                }
                file += "]";
            }

            return file;
        } //toString

        private double[][][] toArray(string file)
        {
            double[][][] weights = new double[1][][];

            return weights;
        } //toArray
    }
}

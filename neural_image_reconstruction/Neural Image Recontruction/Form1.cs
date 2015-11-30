using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace Neural_Image_Recontruction    
{
    public partial class Form1 : Form
    {
        public string dataPath = "C:\\Users\\Sebi\\OneDrive\\Dokumente\\Master\\Erasmus\\Vorlesungen\\project\\code\\data\\noisy";
        public string labelPath = "C:\\Users\\Sebi\\OneDrive\\Dokumente\\Master\\Erasmus\\Vorlesungen\\project\\code\\data\\clean";
        private Data data = new Data();
        private NN nn;

        public Form1()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            int[] layers = { 600, 1500, 600, 1500};
            //nn = new NN(4, layers);
            nn = new NN(2, 800);
        }

        private void setDataPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ui_statusLabel.Text = "... Setting Data Path";
            ui_progressBar.Value = 50;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = this.dataPath;
            DialogResult result = fbd.ShowDialog();
            dataPath = fbd.SelectedPath;
            ui_statusLabel.Text = "Data Path set.";
            ui_progressBar.Value = 100;
        }

        private void setLabelPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ui_statusLabel.Text = "... Setting Label Path";
            ui_progressBar.Value = 50;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = this.labelPath;
            DialogResult result = fbd.ShowDialog();
            labelPath = fbd.SelectedPath;
            ui_statusLabel.Text = "Label Path set.";
            ui_progressBar.Value = 100;
        }

        private void ui_load_Click(object sender, EventArgs e)
        {
            DataLoader fileLoader = new DataLoader();
            fileLoader.prepareOpen(dataPath, "train", "gauss_5", 1000, 0);
            fileLoader.open();
            data.trainingData = fileLoader._imgArr;

            fileLoader.prepareOpen(labelPath, "train", "clean", 1000, 0);
            fileLoader.open();
            data.trainingLabels = fileLoader._imgArr;

            for (int i=0; i<999; i++)
            {
                double[] input = data.normalize(data.trainingData[i]);
                double[] target = data.normalize(data.trainingLabels[i]);
                nn.prepareFeed(input, target);
                nn.feedForward();
                nn.backprop();
                nn.trainingErrors[i] = nn.getError();
            }

            //FileLoader testDataLoader = new FileLoader();
            //FileLoader testLabelLoader = new FileLoader();
            //FileLoader trainDataLoader = new FileLoader();
            //FileLoader trainLabelLoader = new FileLoader();
            //status_bar.Text = "Loading test Data. PLease wait!";
            //int type = ui_noiseType.SelectedIndex;
            //string noiseType = string.Empty;

            //switch (type)
            //{
            //    case 0:
            //        noiseType = "gauss_5";
            //        break;
            //    case 1:
            //        noiseType = "gauss_10";
            //        break;
            //    case 2:
            //        noiseType = "gauss_15";
            //        break;
            //    case 3:
            //        noiseType = "snp_002";
            //        break;
            //    case 4:
            //        noiseType = "snp_005";
            //        break;
            //    case 5:
            //        noiseType = "snp_01";
            //        break;
            //    case 6:
            //        noiseType = "gauss_5_snp_005";
            //        break;
            //    case 7:
            //        noiseType = "gauss_10_snp_002";
            //        break;
            //    case 8:
            //        noiseType = "gauss_15_snp_01";
            //        break;
            //    case 9:
            //        noiseType = "random";
            //        break;
            //}

            //try
            //{
            //    testDataLoader.prepareOpen(dataPath, "test", noiseType, 100);
            //    Thread testDataThread = new Thread(new ThreadStart(testDataLoader.open));
            //    testLabelLoader.prepareOpen(labelPath, "test", "clean", 100);
            //    Thread testLabelThread = new Thread(new ThreadStart(testLabelLoader.open));
            //    trainDataLoader.prepareOpen(dataPath, "train", noiseType, 600);
            //    Thread trainDataThread = new Thread(new ThreadStart(trainDataLoader.open));
            //    trainLabelLoader.prepareOpen(labelPath, "train", "clean", 600);
            //    Thread trainLabelThread = new Thread(new ThreadStart(trainLabelLoader.open));

            //    testDataThread.Start();
            //    testDataThread.Join();
            //    testLabelThread.Start();
            //    testLabelThread.Join();
            //    trainDataThread.Start();
            //    trainDataThread.Join();
            //    trainLabelThread.Start();
            //    trainLabelThread.Join();
            //    //file_loader.open(label_path, "test", "clean", 10000);
            //}
            //catch (Exception ex)
            //{
            //    //somethign went wrong
            //    status_bar.Text = "Shit happened with the file loader... fix it!";
            //}

            //data.testData = testDataLoader._imgArr;
            //data.testLabels = testLabelLoader._imgArr;
            //data.trainingData = trainDataLoader._imgArr;
            //data.trainingLabels = trainLabelLoader._imgArr;
        }

        private void saveWeightMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager fileMng = new FileManager();
            fileMng.prepareSave(nn.getWeights());
            Thread saveThread = new Thread(new ThreadStart(fileMng.save));

            ui_statusLabel.Text = "...writing File, please wait";
            ui_progressBar.Value = 50;
            saveThread.Start();
            saveThread.Join();
            //while (saveThread.IsAlive)
            //{                
            //    if (ui_progressBar.Value == 100)
            //    {
            //        ui_progressBar.Value = 5;
            //    }
            //    else
            //    {
            //        ui_progressBar.Increment(5);
            //    }
            //}
            if (!saveThread.IsAlive)
            {
                ui_statusLabel.Text = "File saved successfully";
                ui_progressBar.Value = 100;
            }
        }

        private void loadWeightMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager fileMng = new FileManager();
            fileMng.load();
        }

        private void ui_experiment_Click(object sender, EventArgs e)
        {
            DataLoader fileLoader = new DataLoader();
            fileLoader.prepareOpen(dataPath, "train", "gauss_15", 1000, 0);
            fileLoader.open();
            data.trainingData = fileLoader._imgArr;

            fileLoader.prepareOpen(labelPath, "train", "clean", 1000, 0);
            fileLoader.open();
            data.trainingLabels = fileLoader._imgArr;

            NN nn = new NN(9, 2, 4); //units, (hidden) layers, sidmoid levels
            for (int i = 0; i < 999; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {

                    }
                }
                double[] input = data.normalize(data.trainingData[i]);
                double[] target = data.normalize(data.trainingLabels[i]);
                nn.prepareFeed(input, target);
                nn.feedForward();
                nn.backprop();
                nn.trainingErrors[i] = nn.getError();
            }

        }
    }
}

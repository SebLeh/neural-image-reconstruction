using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Image_Recontruction
{
    // object for holding all image data
    // and process it if necessary
    class Data
    {
        public int[][] trainingData;
        public int[][] trainingLabels;
        public int[][] testData;
        public int[][] testLabels;

        public Data()
        {

        }

        public double[][] normalize(int[][] imageArray)
        {
            double[][] normalized = new double[imageArray.Length][];
            for (int i=0; i<imageArray.Length; i++)
            {
                Array.Resize(ref normalized[i], imageArray[i].Length);
                for (int j=0; j < imageArray[i].Length; j++)
                {
                    double norm = imageArray[i][j];
                    normalized[i][j] = norm / 255; //devide by max pixel value to set max value to 1
                }
            }
            return normalized;
        }

        public double[] normalize(int[] inputVector)
        {
            double[] normalized = new double[inputVector.Length];
            for (int i=0; i<normalized.Length; i++)
            {
                double norm = inputVector[i];
                normalized[i] = norm / 255;
            }
            return normalized;
        }
    }
}

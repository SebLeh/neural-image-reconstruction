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

        public float[][] normalize(int[][] imageArray)
        {
            float[][] normalized = new float[imageArray.Length][];
            for (int i=0; i<imageArray.Length; i++)
            {
                Array.Resize(ref normalized[i], imageArray[i].Length);
                for (int j=0; j < imageArray[i].Length; j++)
                {
                    float norm = imageArray[i][j];
                    normalized[i][j] = norm / 255; //devide by max pixel value to set max value to 1
                }
            }
            return normalized;
        }
    }
}

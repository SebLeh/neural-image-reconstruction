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
    }
}

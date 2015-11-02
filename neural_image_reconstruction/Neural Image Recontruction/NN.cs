using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Image_Recontruction
{
    class NN

    {
        public NN()
        {
            // default: 1 hidden layer with 784 units
        }

        public NN(int hiddenLayers, int unitsPerLayer)
        {
            // all layers have the same number of units

        }

        public NN(int hiddenLayers, int[] unitsPerLayer)
        {
            // layers have different numbers of units
        }
    }
}

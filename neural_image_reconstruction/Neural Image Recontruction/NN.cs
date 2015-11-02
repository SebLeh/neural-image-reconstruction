using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Image_Recontruction
{
    class NN

    {
        public int noHidden = 1;
        public int hiddenUnits = 784;
        public int[] diffHiddenUnits = new int[1];



        public NN()
        {
            // default: 1 hidden layer with 784 units
            init();
        }

        public NN(int hiddenUnits)
        {
            // 1 hidden layer with custom amount of units
            this.hiddenUnits = hiddenUnits;
            init();
        }

        public NN(int hiddenLayers, int unitsPerLayer)
        {
            // all layers have the same number of units
            noHidden = hiddenLayers;
            hiddenUnits = unitsPerLayer;
            init();
        }

        public NN(int hiddenLayers, int[] unitsPerLayer)
        {
            // layers have different numbers of units
            noHidden = hiddenLayers;
            diffHiddenUnits = unitsPerLayer;
            init();
        }

        public void init()
        {

        }
    }
}

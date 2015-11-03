using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Image_Recontruction
{
    class NN

    {
        public double learningRate = 0.3;
        public double momentum = 1.2;

        private int noHidden = 1;
        private int hiddenUnits = 784;
        private int[] diffHiddenUnits = new int[1];

        private bool differingLayers = false;

        private double[][][] weights = new double[1][][];

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
            differingLayers = true;
            init();
        }

        private void init()
        {
            initlayers();
            initWeights();
        } //init

        private void initlayers()
        {
            Array.Resize(ref weights, noHidden + 1);
            if (!differingLayers)
            {
                Array.Resize(ref diffHiddenUnits, noHidden);
                for (int i = 0; i < noHidden; i++)
                {
                    diffHiddenUnits[i] = hiddenUnits + 1;  // +1 for bias
                }
            } //if


            Array.Resize(ref weights[0], 785);  //first layer: 28x28 + bias
            for (int i = 1; i <= noHidden; i++)
            {
                Array.Resize(ref weights[i], diffHiddenUnits[i - 1]);
            }
            for (int i = 0; i < weights.Length - 1; i++)
            {
                for (int j = 0; j < weights[i].Length; j++)
                {
                    Array.Resize(ref weights[i][j], diffHiddenUnits[i]);
                }
            }
            for (int i = 0; i < weights[weights.Length - 1].Length; i++)
            {
                Array.Resize(ref weights[weights.Length - 1][i], 784); // 784 output units
            }
        } //initLayers

        private void initWeights()
        {
            Random rand = new Random();
            for (int i=0; i<weights.Length; i++)
            {
                for (int j=0; j<weights[i].Length; j++)
                {
                    for (int k=0; k < weights[i][j].Length; k++)
                    {
                        int randInt = rand.Next(-1000, 1000);
                        double randDbl = randInt;
                        weights[i][j][k] = randDbl/10000;
                    } //for(k)
                } //for(j)
            } //for(i)
        } // initWeights

        public void feedForward(int[] input)
        {

        }
    }
}

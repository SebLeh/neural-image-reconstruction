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
        public double momentum = 1;

        private int noHidden = 1;                           // no of hidden layers
        private int hiddenUnits = 784;                      // default value
        private int[] diffHiddenUnits = new int[1];         // number of unis for hidden layer i

        private bool differingLayers = false;               // true, when hidden layers have different no of units

        private double[][][] weights = new double[1][][];   // [layer number][current layer][layer before] = weight

        private double[] inputVector = new double[1];
        public double[] outputVector = new double[1];

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


            //Array.Resize(ref weights[0], 784);  //first layer: 28x28 + bias
            for (int i = 0; i < noHidden; i++)
            {
                Array.Resize(ref weights[i], diffHiddenUnits[i]); 
            }
            Array.Resize(ref weights[weights.Length - 1], 784); // 784 outputs
            for (int i=0; i<weights[0].Length; i++)
            {
                Array.Resize(ref weights[0][i], 785); // 28x28 inputs + bias unit
            }
            for (int i = 1; i < weights.Length - 1; i++)
            {
                for (int j = 0; j < weights[i].Length; j++)
                {
                    Array.Resize(ref weights[i][j], diffHiddenUnits[i - 1] + 1); // + bias unit
                }
            }
            for (int i = 0; i < weights[weights.Length - 1].Length; i++)
            {
                Array.Resize(ref weights[weights.Length - 1][i], diffHiddenUnits[diffHiddenUnits.Length -1] + 1); 
                // last output depends on last hidden layer (+ its bias unit)
            }
        } //initLayers

        private void initWeights()
        {
            // initialize weights with values between -0.1 and 0.1 (4 decimals)
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

        public void prepareFeed(double[] inputVector)
        {
            this.inputVector = inputVector;
        }

        public void feedForward()
        {
            double[] layerValues = inputVector;
            for(int i=0; i<weights.Length; i++)
            {
                double[] iLayer = new double[weights[i].Length];
                Parallel.For(0, weights[i].Length, (j) =>
                {
                    iLayer[j] += 1 * weights[i][j][0]; //bias value
                    Parallel.For(1, weights[i][j].Length, (k) =>
                    {
                        iLayer[j] += layerValues[k - 1] * weights[i][j][k];
                    }); // for(k) - parallel
                }); // for(j) - parallel
                layerValues = iLayer;
            } // for(i)
            outputVector = layerValues;
        } // feedForward

        public double[][][] getWeights()
        {
            return weights;
        }
    }
}

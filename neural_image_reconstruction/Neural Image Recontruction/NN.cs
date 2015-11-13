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
        public double[] trainingErrors = new double[60000]; // storing error of all training examples
        public double[] testingErrors = new double[10000];  // storing error of all test examples
        public double[] outputVector = new double[784];     // vector NN produces
        public double[] target = new double[784];           // vector NN should produce

        private int noHidden = 1;                           // no of hidden layers
        private int hiddenUnits = 784;                      // default value
        private int[] diffHiddenUnits = new int[1];         // number of unis for hidden layer i
        private bool differingLayers = false;               // true, when hidden layers have different no of units
        private double[][][] weights = new double[1][][];   // [layer number][current layer][layer before] = weight
        private double[] inputVector = new double[784];     // input values to NN
        private double[] errorVector = new double[784];     // difference between target and output
        private double[][] hiddenVectors = new double[1][]; // storing vectors hidden layers produced; needed for backprop
        private double[][] hiddenErrors = new double[1][];  // storing errors on hidden layers

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
            Array.Resize(ref hiddenVectors, noHidden);
            for (int i = 0; i < noHidden; i++)
            {
                Array.Resize(ref hiddenVectors[i], diffHiddenUnits[i]);
            }
            Array.Resize(ref hiddenErrors, noHidden);
            for (int i = 0; i < noHidden; i++)
            {
                Array.Resize(ref hiddenErrors[i], diffHiddenUnits[i] + 1); //bias
            }
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

        public void prepareFeed(double[] inputVector, double[] target)
        {
            this.inputVector = inputVector;
            this.target = target;
        }

        public void feedForward()
        {
            double[] layerValues = inputVector;
            for(int i=0; i<weights.Length; i++)
            {
                double[] iLayer = new double[weights[i].Length];
                Parallel.For(0, weights[i].Length, (j) =>
                {
                    double net = 0;
                    net += 1 * weights[i][j][0]; //bias value
                    Parallel.For(1, weights[i][j].Length, (k) =>
                    {
                        net += layerValues[k - 1] * weights[i][j][k];
                    }); // for(k) - parallel
                    iLayer[j] = sigmoid(net);
                }); // for(j) - parallel
                layerValues = iLayer;
                try
                {
                    hiddenVectors[i] = iLayer;
                }
                catch (System.IndexOutOfRangeException)
                {
                    //planned exception: array is not big enough (output does not vount as hidden vector)
                }
            } // for(i)
            outputVector = layerValues;
            calcError();
        } // feedForward

        public double[][][] getWeights()
        {
            return weights;
        }

        private double sigmoid(double netValue)
        {
            double sigmoid = 0;
            sigmoid = 1 / (1 + Math.Exp(-netValue));
            return sigmoid;
        }

        private void calcError()
        {
            for (int i=0; i < errorVector.Length; i++)
            {
                errorVector[i] = outputVector[i] * (1 - outputVector[i]) * (target[i] - outputVector[i]);
            }
        }

        public void backprop()
        {
            for (int i=0; i<noHidden; i++)
            {
                int ii = noHidden - i - 1; //has to start with layer closest to output
                if (i == 0) //last hidden layer has to be calculated by outputs
                {
                    double sum0 = 0;
                    Parallel.For(0, errorVector.Length, (k) =>
                    {
                        sum0 += errorVector[k] * weights[ii + 1][k][0];
                    });
                    hiddenErrors[ii][0] = 1  * sum0; //calculating error for bias

                    Parallel.For(1, hiddenErrors[ii].Length, (j) =>
                    {
                        double sumJ = 0;
                        Parallel.For(0, errorVector.Length, (k) =>
                        {
                            sumJ += errorVector[k] * weights[ii + 1][k][j];
                        });
                        hiddenErrors[ii][j] = hiddenVectors[ii][j - 1] * (1 - hiddenVectors[ii][j - 1]) * sumJ;
                        // j-1: vectors don't contain bias -> 1 less value
                    });
                }
                else
                {
                    double sum0 = 0;
                    Parallel.For(0, hiddenVectors[ii + 1].Length, (k) =>
                    {
                        sum0 += hiddenVectors[ii + 1][k] * weights[ii + 1][k][0];
                    });
                    hiddenErrors[ii][0] = 1 * sum0; //calculating error for bias
                    Parallel.For(1, hiddenErrors[ii].Length, (j) =>
                    {
                        double sumJ = 0;
                        Parallel.For(1, hiddenErrors[ii + 1].Length, (k) =>
                        {
                            sumJ += hiddenVectors[ii + 1][k - 1] * weights[ii + 1][k - 1][j];
                        });
                        hiddenErrors[ii][j] = hiddenVectors[ii][j - 1] * (1 - hiddenVectors[ii][j - 1]) * sumJ;
                    });
                } //if            
            } //for(i)
            adaptWeights();
        } // backprop

        private void adaptWeights()
        {

        } // adaptWeights
    } // class NN
}

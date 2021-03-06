﻿using System;
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

        private double gain = 1.0;
        private int sigmoidLevels = 1;

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

        public NN(int units, int layers, int levels)
        {
            // used for experimental phase with small subsections
            hiddenUnits = units;
            noHidden = layers;
            sigmoidLevels = levels;
            initExperiment();
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
                    diffHiddenUnits[i] = hiddenUnits;
                }
            } //if
            for (int i = 0; i < noHidden; i++)
            {
                Array.Resize(ref weights[i], diffHiddenUnits[i]); 
            }
            Array.Resize(ref weights[weights.Length - 1], 784); // 784 outputs
            for (int i=0; i<weights[0].Length; i++)  //input layer; 784+1
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
            calcGain();
            calcError();
        } // feedForward

        public double[][][] getWeights()
        {
            return weights;
        }

        private double sigmoid(double netValue)
        {
            double sigmoid = 0;
            sigmoid = 1 / (1 + Math.Exp(-netValue*gain));
            return sigmoid;
        }

        private double mlSigmoid(double netValue, int levels)
        {
            double output = 0;
            for (int i=-levels; i<=levels; i++)
            {
                output += 1 / (1 + Math.Exp(-netValue - 8*i));
            }
            return output;
        }

        private void calcError()
        {
            Parallel.For(0, errorVector.Length, (i) =>
            {
                errorVector[i] = outputVector[i] * (1 - outputVector[i]) * (target[i] - outputVector[i]);
                //errorVector[i] = target[i] - outputVector[i];
            });
            //for (int i=0; i < errorVector.Length; i++)
            //{
            //    errorVector[i] = outputVector[i] * (1 - outputVector[i]) * (target[i] - outputVector[i]);
            //}
        }

        private void calcErrorLevels(int sigmoidLevels)
        {
            Parallel.For(0, errorVector.Length, (i) =>
            {
                double derivate = 0;
                for (int j = -(sigmoidLevels/2 -1); j < sigmoidLevels/2 -1; j++)
                {
                    derivate += (1 / (1 + Math.Exp(-outputVector[i] + 8 * j)))*(1 - 1 / (1 + Math.Exp(-outputVector[i] + 8 * j)));
                }
                errorVector[i] = (target[i] - outputVector[i]) * derivate;
            });
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
                        for (int k=0; k<errorVector.Length; k++)
                        {
                            sumJ += errorVector[k] * weights[ii + 1][k][j];
                        }
                        //Parallel.For(0, errorVector.Length, (k) =>
                        //{
                        //    sumJ += errorVector[k] * weights[ii + 1][k][j];
                        //});
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
                        for (int k=1; k<hiddenErrors[ii+1].Length; k++)
                        {
                            sumJ += hiddenVectors[ii + 1][k - 1] * weights[ii + 1][k - 1][j];
                        }
                        //Parallel.For(1, hiddenErrors[ii + 1].Length, (k) =>
                        //{
                        //    sumJ += hiddenVectors[ii + 1][k - 1] * weights[ii + 1][k - 1][j];
                        //});
                        hiddenErrors[ii][j] = hiddenVectors[ii][j - 1] * (1 - hiddenVectors[ii][j - 1]) * sumJ;
                    });
                } //if            
            } //for(i)
            adaptWeights();
        } // backprop

        private void adaptWeights()
        {
            //first layer weights 
            Parallel.For(0, weights[0].Length, (j) =>
            {
                weights[0][j][0] = weights[0][j][0] + learningRate * 1 * hiddenVectors[0][j]; //bias weight
                for (int k=0; k<weights[0][j].Length - 1; k++)
                {
                    weights[0][j][k + 1] = weights[0][j][k + 1] + learningRate * inputVector[k] * hiddenVectors[0][j];
                    //other weights
                }
                //Parallel.For(0, weights[0][j].Length - 1, (k) =>
                //{
                //    weights[0][j][k + 1] = weights[0][j][k + 1] + learningRate * inputVector[j] * hiddenVectors[0][k];
                //    //other weights
                //});
            });
            Parallel.For(1, weights.Length, (i) =>
            {
                if (i < weights.Length - 1)
                {
                    // dependent on hidden layers
                    Parallel.For(0, weights[i].Length, (j) =>
                    {
                        weights[i][j][0] = weights[i][j][0] + learningRate * hiddenVectors[i][j]; //bias weight
                        for (int k=0; k<weights[i][j].Length - 1; k++)
                        {
                            weights[i][j][k + 1] = weights[i][j][k + 1] + learningRate * hiddenVectors[i-1][k] * hiddenVectors[i][j];
                            //other weights
                        }
                        //Parallel.For(0, weights[i][j].Length - 1, (k) =>
                        //{
                        //    weights[i][j][k + 1] = weights[i][j][k + 1] + learningRate * hiddenVectors[i-1][k] * hiddenVectors[i][j];
                        //    //other weights
                        //});
                    });
                }
                else
                {
                    // dependent on output layer
                    Parallel.For(0, weights[i].Length, (j) =>
                    {
                        weights[i][j][0] = weights[i][j][0] + learningRate * errorVector[j]; //bias weight
                        for (int k = 0; k < weights[i][j].Length - 1; k++)
                        {
                            weights[i][j][k + 1] = weights[i][j][k + 1] + learningRate * errorVector[j] * hiddenVectors[i - 1][k];
                            //other weights
                        }
                        //Parallel.For(0, weights[i][j].Length -1, (k) =>
                        //{
                        //    weights[i][j][k + 1] = weights[i][j][k + 1] + learningRate * errorVector[j] * hiddenVectors[i - 1][k];
                        //    //other weights
                        //});
                    });
                }
            });
        } // adaptWeights

        public double getError()
        {
            double error = 0;
            Parallel.For(0, errorVector.Length, (i) =>
            {
                error += Math.Abs(errorVector[i]);
            });
            return error;
        }

        private void calcGain()
        {
            double e = 0;
            for (int i=0; i<target.Length - 1; i++)
            {
                if (Math.Abs(target[i] - outputVector[i]) > Math.Abs(target[i+1] - outputVector[i + 1]))
                {
                    e = Math.Abs(target[i] - outputVector[i]);
                }
                else
                {
                    // max difference at last index
                    e = Math.Abs(target[target.Length - 1] - outputVector[outputVector.Length - 1]);
                }
            }
            double approx = e / 0.5;
            if (approx > 1)
            {
                gain = 0.5 / e;
            }
            else
            {
                gain = 1;
            }
        }

        private void initExperiment()
        {
            Array.Resize(ref weights, noHidden + 1);
            for (int i = 0; i <= noHidden; i++)
            {
                Array.Resize(ref weights[i], 9);
            }
            for (int i = 0; i < weights.Length; i++)
            {
                for (int j = 0; j < weights[i].Length; j++)
                {
                    Array.Resize(ref weights[i][j], 10); // + bias unit
                }
            }
            initWeights();
            Array.Resize(ref hiddenVectors, noHidden);
            for (int i=0; i<noHidden; i++)
            {
                Array.Resize(ref hiddenVectors[i], 9);
            }
        }
    } // class NN
}

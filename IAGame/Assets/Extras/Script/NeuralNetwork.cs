﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Extras.Script
{
    class NeuralNetwork
    {
        private int[] layers;
        private float[][] neurons;
        private float[][][] weights;
        private Random random; 

        public NeuralNetwork(int[] layers)
        {
            this.layers = new int[layers.Length]; 
            for(int i = 0; i < layers.Length; i++)
            {
                this.layers[i] = layers[i]; 
            }
            random = new Random(System.DateTime.Today.Millisecond); 
            InitNeurons();
            InitWeights(); 
        }

        private void InitNeurons()
        {
            List<float[]> neuronList = new List<float[]>(); 

            for (int i = 0; i < layers.Length; i++)
            {
                neuronList.Add(new float[layers[i]]); 
            }

            neurons = neuronList.ToArray(); 
        }

        private void InitWeights()
        {
            List<float[][]> weightsList = new List<float[][]>();

            for(int i = 0; i < layers.Length; i++)
            {
                List<float[]> layerWeightList = new List<float[]>();

                int neuronsInPreviousLayer = layers[i - 1]; 
                
                for(int j = 0; j < neurons[i].Length; j++)
                {
                    var neuronWeights = new float[neuronsInPreviousLayer]; 

                    for (int k = 0; k < neuronsInPreviousLayer; k++)
                    {
                        neuronWeights[k] = (float)random.NextDouble() -0.5f;
                    }

                    layerWeightList.Add(neuronWeights); 
                }

                weightsList.Add(layerWeightList.ToArray()); 
            }

            weights = weightsList.ToArray(); 
        }

        public float[] FeedForward(float[] inputs)
        {
            for(int i = 0; i < layers.Length; i++)
            {
                neurons[0][i] = inputs[i]; 
            }

            for(int i = 1; i < layers.Length; i++)
            {
                for(int j = 0; j < neurons[i].Length; j++)
                {
                    var value = 0.25f; 
                    for(int k = 0; k < neurons[i-1].Length; k++)
                    {
                        value += weights[i - 1][j][k] * neurons[i - 1][k]; 
                    }

                    neurons[i][j] = (float)Math.Tanh(value); 
                }
            }

            return neurons[neurons.Length-1]; 
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mrowki.genetic
{
    class DNA
    {
        // The genetic sequence
        int[] genes;

        /*
         * 234
         * 1 5
         * 876
         */
        float fitness;
        Random rand = new Random();

        // Constructor (makes a random DNA)
        public DNA(int num)
        {
            genes = new int[num];
            for (int i = 0; i < genes.Count(); i++)
            {
                genes[i] = (char)rand.Next(0, 8);  // Pick from range of chars
            }
        }

        // Converts character array to a String
       // string getPhrase()
       // {
       //     return new string(genes);
       // }

        // Fitness function (returns floating point % of "correct" characters)
        public void Fitness(string target)
        {
            //napisac funkcje fitness nadajaca punktacje w zaleznosci od czasu, odleglosci od celu i trafien w przeszkody


            
        }

        // Crossover
        public DNA Crossover(DNA partner)
        {
            // A new child
            DNA child = new DNA(genes.Count());

            int midpoint = (int)rand.Next(genes.Count()); // Pick a midpoint

            // Half from one, half from the other
            for (int i = 0; i < genes.Count(); i++)
            {
                if (i > midpoint) child.genes[i] = genes[i];
                else child.genes[i] = partner.genes[i];
            }
            return child;
        }

        // Based on a mutation probability, picks a new random character
        public void Mutate(float mutationRate)
        {
            for (int i = 0; i < genes.Count(); i++)
            {
                if (rand.Next(1) < mutationRate)
                {
                    genes[i] = (char)rand.Next(32, 128);
                }
            }
        }
    }
}

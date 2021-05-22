/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mrowki.genetic
{
    public class Population
    {
        float mutationRate;           // Mutation rate
        DNA[] population;             // Array to hold the current population
        List<DNA> matingPool;    // ArrayList which we will use for our "mating pool"
        float target;                // Target phrase
        int generations;              // Number of generations
        bool finished;             // Are we finished evolving?
        int perfectScore;

        public Population(string p, float m, int num)
        {
            target = p;
            mutationRate = m;
            population = new DNA[num];
            for (int i = 0; i < population.Count(); i++)
            {
                population[i] = new DNA((int)target);
            }
            CalcFitness();
            matingPool = new List<DNA>();
            finished = false;
            generations = 0;

            perfectScore = 1;
        }

        // Fill our fitness array with a value for every member of the population
        public void CalcFitness()
        {
            for (int i = 0; i < population.Count(); i++)
            {
                population[i].Fitness(target);
            }
        }

        // Generate a mating pool
        public void NaturalSelection()
        {
            // Clear the ArrayList
            matingPool.Clear();

            float maxFitness = 0;
            for (int i = 0; i < population.Count(); i++)
            {
                if (population[i].fitness > maxFitness)
                {
                    maxFitness = population[i].fitness;
                }
            }

            //metoda monte carlo
        }

        // Create a new generation
        public void Generate()
        {
            // Refill the population with children from the mating pool
            for (int i = 0; i < population.length; i++)
            {
                int a = int(random(matingPool.size()));
                int b = int(random(matingPool.size()));
                DNA partnerA = matingPool.get(a);
                DNA partnerB = matingPool.get(b);
                DNA child = partnerA.crossover(partnerB);
                child.mutate(mutationRate);
                population[i] = child;
            }
            generations++;
        }


        // Compute the current "most fit" member of the population
        public string GetBest()
        {
            float worldrecord = (float)0.0;
            int index = 0;
            for (int i = 0; i < population.length; i++)
            {
                if (population[i].fitness > worldrecord)
                {
                    index = i;
                    worldrecord = population[i].fitness;
                }
            }

            if (worldrecord == perfectScore) finished = true;
            return population[index].getPhrase();
        }

        bool Finished()
        {
            return finished;
        }

        int GetGenerations()
        {
            return generations;
        }

        // Compute average fitness for the population
        float GetAverageFitness()
        {
            float total = 0;
            for (int i = 0; i < population.Count(); i++)
            {
                total += population[i].fitness;
            }
            return total / (population.Count());
        }

        string AllPhrases()
        {
            string everything = "";

            int displayLimit = Math.Min(population.Count(), 50);


            for (int i = 0; i < displayLimit; i++)
            {
                everything += population[i].getPhrase() + "\n";
            }
            return everything;
        }
    }
}*/

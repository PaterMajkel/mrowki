using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace mrowki.genetic
{
    public class Population
    {
        double mutationRate;           // Mutation rate
        DNA[] population;             // Array to hold the current population
        List<DNA> matingPool;    // ArrayList which we will use for our "mating pool"
        Point target;                // Target phrase
        int generations;              // Number of generations
        bool finished;             // Are we finished evolving?
        int perfectScore;

        public Population(Point fin, float m, int num, Point start)
        {
            target = fin;
            mutationRate = m;
            population = new DNA[num];
            for (int i = 0; i < population.Count(); i++)
            {
                population[i] = new DNA(start);
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


        public DNA MonteCarlo(double maxFitness)
        {
            Random rand = new Random();
            int escape = 0;
            while(true)
            {
                int pop = rand.Next(0, population.Length);
                int max = (int)Math.Floor(maxFitness * 10000) + 1;
                int r = rand.Next(0, max);
                DNA partner = this.population[pop];
                if (r < partner.Fitness(target) * 10000)
                {
                    return partner;
                }
                escape++;
                if(escape>10000)
                {
                    return null;
                }

            }
            
        }

        // Create a new generation
        public void Generate()
        {
            double maxFitness = 0;
            for (int i = 0; i < population.Count(); i++)
            {
                if (population[i].fitness > maxFitness)
                {
                    maxFitness = population[i].fitness;
                }
            }

            Random rand = new Random();
            DNA[] newPopulation = new DNA[population.Length-1];
            // Refill the population with children from the mating pool
            for (int i = 0; i < population.Count(); i++)
            {
                DNA partnerA = MonteCarlo(maxFitness);
                DNA partnerB = MonteCarlo(maxFitness);

                DNA child = partnerA.Crossover(partnerB);
                child.Mutate(mutationRate);
                newPopulation[i] = child;
            }
            population = newPopulation;
            generations++;
        }


        // Compute the current "most fit" member of the population
        public int GetBest()
        {
            double worldrecord = 0.0;
            int index = 0;
            for (int i = 0; i < population.Length; i++)
            {
                if (population[i].fitness > worldrecord)
                {
                    index = i;
                    worldrecord = population[i].Fitness(target);
                }
            }

            if (worldrecord == perfectScore) finished = true;
            return index;
        }

        public bool Finished()
        {
            return finished;
        }

        public int GetGenerations()
        {
            return generations;
        }

        // Compute average fitness for the population
        public double GetAverageFitness()
        {
            double total = 0;
            for (int i = 0; i < population.Count(); i++)
            {
                total += population[i].Fitness(target);
            }
            return total / (population.Count());
        }

        public Point[] AllLocations()
        {
            Point[] points = new Point[population.Length - 1];

            int displayLimit = Math.Min(population.Count(), 50);


            for (int i = 0; i < displayLimit; i++)
            {
                points[i] = population[i].currlocation;
            }
            return points;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace mrowki.genetic
{
    public class DNA
    {
        // The genetic sequence
        int[] genes;
        Point slocation;
        public Point currlocation;
        /*
         * 1 2 3
         * 4   5
         * 6 7 8
         * 
         */
        public bool dead = false;
        public double fitness;
        Random rand = new Random();

        // Constructor (makes a random DNA)
        public DNA(Point location,int time)
        {
            genes = new int[time];
            this.slocation = location;
            this.currlocation = location;

            for(int i=0; i<time; i++)
            {
                genes[i]=rand.Next(1, 8);
                changeLocation(genes[i]);
            }

        }

        public Point FinalLocation()
        {
            for(int i=0; i<genes.Length; i++)
                changeLocation(genes[i]);
            return currlocation;

        }
        public Point StepLocation(int i)
        {
            changeLocation(genes[i]);
            return currlocation;
        }
        public void changeLocation(int a)
        {
            switch(a)
            {
                case 1:
                    {
                        currlocation.X -= 3;
                        currlocation.Y += 3;
                        break;
                    }
                case 2:
                    {
                        currlocation.Y += 3;
                        break;
                    }
                case 3:
                    {
                        currlocation.X += 3;
                        currlocation.Y += 3;
                        break;
                    }
                case 4:
                    {
                        currlocation.X -= 3; 
                        break;
                    }
                case 5:
                    {
                        currlocation.X += 3;
                        break;
                    }
                case 6:
                    {
                        currlocation.X -= 3;
                        currlocation.Y -= 3;
                        break;
                    }
                case 7:
                    {
                        currlocation.Y -= 3;
                        break;
                    }
                case 8:
                    {
                        currlocation.X += 3;
                        currlocation.Y -= 3;
                        break;
                    }


            }
        }

        

        // Converts character array to a String
       // string getPhrase()
       // {
       //     return new string(genes);
       // }

        // Fitness function (returns floating point % of "correct" characters)
        public double Fitness(Point target)
        {
            //napisac funkcje fitness nadajaca punktacje w zaleznosci od czasu, odleglosci od celu i trafien w przeszkody

            double length = Math.Sqrt(Math.Pow((target.X - currlocation.X), 2) + Math.Pow((target.Y - currlocation.Y), 2));
            if(length==0)
            {
                length = 1;
            }
            fitness = 1 / length;

            return fitness;

            
        }

        // Crossover
        public DNA Crossover(DNA partner)
        {
            // A new child
            DNA child = new DNA(slocation, partner.genes.Length);

            int midpoint = (int)rand.Next(genes.Count()); // Pick a midpoint

            // Half from one, half from the other
            for (int i = 0; i < genes.Count(); i++)
            {
                if (i > midpoint) child.genes[i]=genes[i];
                else child.genes[i]=partner.genes[i];
            }
            return child;
        }

        // Based on a mutation probability, picks a new random character
        public void Mutate(double mutationRate)
        {
            for (int i = 0; i < genes.Count(); i++)
            {
                if (rand.NextDouble() < mutationRate)
                {
                    genes[i] = rand.Next(1, 8);
                }
            }
        }
    }
}

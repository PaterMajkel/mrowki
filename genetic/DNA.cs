using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace mrowki.genetic
{
    public class DNA
    {
        // The genetic sequence
        List<int> genes;
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
        public DNA(Point location)
        {
            genes = new List<int>();
            this.slocation = location;
            this.currlocation = location;

                genes.Add(rand.Next(1, 8));
            changeLocation(genes[genes.Count - 1]);
        }
        public void changeLocation(int a)
        {
            switch(a)
            {
                case 1:
                    {
                        currlocation.X -= 5;
                        currlocation.Y += 5;
                        break;
                    }
                case 2:
                    {
                        currlocation.Y += 5;
                        break;
                    }
                case 3:
                    {
                        currlocation.X += 5;
                        currlocation.Y += 5;
                        break;
                    }
                case 4:
                    {
                        currlocation.X -= 5; 
                        break;
                    }
                case 5:
                    {
                        currlocation.X += 5;
                        break;
                    }
                case 6:
                    {
                        currlocation.X -= 5;
                        currlocation.Y -= 5;
                        break;
                    }
                case 7:
                    {
                        currlocation.X -= 5;
                        currlocation.Y -= 5;
                        break;
                    }
                case 8:
                    {
                        currlocation.X += 5;
                        currlocation.Y -= 5;
                        break;
                    }


            }
        }

        public void Step()
        {
            genes.Add(rand.Next(1, 8));
            changeLocation(genes[genes.Count - 1]);
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

            double length = Math.Sqrt((target.X - currlocation.X) ^ 2 + (target.Y - currlocation.Y) ^ 2);
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
            DNA child = new DNA(slocation);

            int midpoint = (int)rand.Next(genes.Count()); // Pick a midpoint

            // Half from one, half from the other
            for (int i = 0; i < genes.Count(); i++)
            {
                if (i > midpoint) child.genes.Add(genes[i]);
                else child.genes.Add(partner.genes[i]);
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

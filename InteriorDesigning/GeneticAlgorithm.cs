using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorDesigning
{
    class GeneticAlgorithm<T>
    {
        public List<DNA<T>> _Population;
        private int _Generation;
        private float _FitnessSum;
        private float _BestFitness;
        private T[] _BestGenes;

        public T[] BestGenes
        {
            get { return _BestGenes; }
            set { _BestGenes = value; }
        }

        public float BestFitness
        {
            get { return _BestFitness; }
            set { _BestFitness = value; }
        }

        public List<DNA<T>> Population
        {
            get { return _Population; }
            set { _Population = value; }
        }

        public int Generation
        {
            get { return _Generation; }
            set { _Generation = value; }
        }

        public float MutationRate;
        private Random rnd;

        public GeneticAlgorithm(int populationSize, int dnaSize, Random rnd, 
            Func<T> getRandomGene, Func<int, float> fitnessFunction, float mutationRate = 0.01f)
        {
            Generation = 1;
            MutationRate = mutationRate;
            Population = new List<DNA<T>>();
            this.rnd = rnd;

            BestGenes = new T[dnaSize];

            for(int i= 0; i< populationSize; i++)
            {
                Population.Add(new DNA<T>(dnaSize, rnd, getRandomGene, fitnessFunction, shouldInitGenes: true));
            }
        }

        public void NewGeneration()
        {
            if(Population.Count <= 0)
            {
                return;
            }

            CalulateFitness();
            List<DNA<T>> newPopulation = new List<DNA<T>>();

            for(int i=0; i<Population.Count; i++)
            {
                DNA<T> parent1 = ChooseParent();
                DNA<T> parent2 = ChooseParent();

                DNA<T> child = parent1.CrossOver(parent2);
                child.Mutation(MutationRate);

                newPopulation.Add(child);
            }

            Population = newPopulation;
            Generation++;
        }

        public void CalulateFitness()
        {
            _FitnessSum = 0;
            DNA<T> best = Population[0];
            for (int i = 0; i < Population.Count; i++)
            {
                _FitnessSum += Population[i].CalculateFitness(i);  
                if(Population[i].Fitness > best.Fitness)
                {
                    best = Population[i];
                }
            }
            BestFitness = best.Fitness;
            best.Genes.CopyTo(BestGenes, 0);
        }

        private DNA<T> ChooseParent()
        {
            double randomNumber = rnd.NextDouble() * _FitnessSum;
            for(int i = 0; i<Population.Count; i++)
            {
                if(randomNumber < Population[i].Fitness)
                {
                    return Population[i];
                }
                else
                {
                    randomNumber -= Population[i].Fitness;
                }
            }
            return null;
        }
    }
}

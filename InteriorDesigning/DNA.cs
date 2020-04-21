using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorDesigning
{
    public class DNA <T>
    {
        private T[] _Genes;
        private float _Fitness;
        private Random rnd;
        private Func<T> _GetRandomGene;
        private Func<int, float> _FitnessFunction;

        public T[] Genes
        {
            get { return _Genes; }
            set { _Genes = value; }
        }

        public float Fitness
        {
            get { return _Fitness; }
            set { _Fitness = value; }
        }

        public DNA(int size, Random rnd, Func<T> getRandomGene, Func<int, float> fitnessFunction,  bool shouldInitGenes = true)
        {
            Genes = new T[size];
            this.rnd = rnd;
            this._GetRandomGene = getRandomGene;
            this._FitnessFunction = fitnessFunction;
            if (shouldInitGenes)
            {
                for (int i = 0; i < Genes.Length; i++)
                {
                    Genes[i] = getRandomGene();
                }
            }
        }

        public float CalculateFitness(int index)
        {
            Fitness = _FitnessFunction(index);
            return Fitness;
        }

        public DNA<T> CrossOver(DNA<T> otherParent)
        {
            DNA<T> child = new DNA<T>(Genes.Length, rnd, _GetRandomGene, _FitnessFunction, shouldInitGenes: false);
            for(int i=0; i < Genes.Length; i++)
            {
                child.Genes[i] = rnd.NextDouble() < 0.5 ? Genes[i] : otherParent.Genes[i];
            }
            return child;
        }

        public void Mutation(float mutationRate)
        {
            for (int i = 0; i < Genes.Length; i++)
            {
                if(rnd.NextDouble() < mutationRate)
                {
                    Genes[i] = _GetRandomGene();
                }
            }
        }
    }
}

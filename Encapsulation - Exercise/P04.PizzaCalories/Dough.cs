using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private Dictionary<string, double> flourTypeCall = new Dictionary<string, double>
        {
            {"white", 1.5 },
            {"wholegrain", 1.0}
        };
        private Dictionary<string, double> bakingTechniqueCall = new Dictionary<string, double>
        {
            { "crispy",0.9 },
            { "chewy", 1.1},
            { "homemade", 1.0}
        };
        private const int CaloriePerGram = 2;
        private string flourType;
        private string bakingTechnique;
        private double weight;
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (!flourTypeCall.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (!bakingTechniqueCall.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }
        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 && value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }
        public double Callories => CaloriePerGram * Weight * flourTypeCall[this.FlourType.ToLower()] * bakingTechniqueCall[this.bakingTechnique.ToLower()];

    }
}

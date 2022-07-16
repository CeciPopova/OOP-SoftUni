using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Cat : Feline
    {
        private const double CatWeightMultiplier = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {

        }
        protected override IReadOnlyCollection<Type> PreferredFoods => new List<Type> { typeof(Meat), typeof(Vegetable) }.AsReadOnly();
        protected override double WeightMultiplier => CatWeightMultiplier;
        public override string ProduseSound()
        {
            return "Meow";
        }
    }
}

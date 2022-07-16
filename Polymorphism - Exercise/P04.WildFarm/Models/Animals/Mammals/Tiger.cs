using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Tiger : Feline
    {
        private const double TigerWeightMultiplier = 1;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }
        protected override IReadOnlyCollection<Type> PreferredFoods => new List<Type> { typeof(Meat) }.AsReadOnly();
        protected override double WeightMultiplier => TigerWeightMultiplier;

        public override string ProduseSound()
        {
            return "ROAR!!!";
        }
    }
}

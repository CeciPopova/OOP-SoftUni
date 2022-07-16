using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    internal class Mouse : Mammal
    {
        private const double MouseWeightMultiplier = 0.10;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }


        protected override IReadOnlyCollection<Type> PreferredFoods => new List<Type> { typeof(Fruit), typeof(Vegetable) }.AsReadOnly();
        protected override double WeightMultiplier => MouseWeightMultiplier;

        public override string ProduseSound()
        {
            return "Squeak";
        }
        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using WildFarm.Exception;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;

        }

        public string Name { get; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        protected virtual IReadOnlyCollection<Type> PreferredFoods { get; set; }
        protected abstract double WeightMultiplier { get; }
        public abstract string ProduseSound();
        public virtual void Eat(Food food)
        {
            if (!this.PreferredFoods.Contains(food.GetType()))
            {
                throw new FoodNotPreferedException(String.Format(ExeptionMessages.FoodNotPreffered, this.GetType().Name, food.GetType().Name));
            }
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightMultiplier;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}

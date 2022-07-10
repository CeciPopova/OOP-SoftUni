using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Dough Dough
        {
            get { return dough; }
            internal set { dough = value; }
        }
        public IReadOnlyList<Topping> Toppings
        {
            get { return toppings; }

        }
        public void AddTopping(Topping topping)
        {

            if (this.toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);

        }
        public double GetTotalCalories()
        {
            double totalCalories = Dough.Callories + toppings.Sum(t => t.Calories);
            return totalCalories;
        }
    }
}

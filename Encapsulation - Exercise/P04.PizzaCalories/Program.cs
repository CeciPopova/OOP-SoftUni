using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split(' ');
                string pizzaName = pizzaInfo[1];

                string[] doughInfo = Console.ReadLine().Split(' ');
                string doughType = doughInfo[1];
                string doughBakingTech = doughInfo[2];
                double doughWeight = double.Parse(doughInfo[3]);

                Dough dough = new Dough(doughType, doughBakingTech, doughWeight);

                Pizza pizza = new Pizza(pizzaName, dough);
                string input = Console.ReadLine();
                while (input != "END")
                {
                    string[] inputArgs = input.Split(' ');

                    string toppingType = inputArgs[1];
                    double toppWeight = double.Parse(inputArgs[2]);
                    Topping topping = new Topping(toppingType, toppWeight);
                    pizza.AddTopping(topping);
                    input = Console.ReadLine();
                }
                Console.WriteLine($"{pizzaName} - {pizza.GetTotalCalories():f2} Calories.");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}

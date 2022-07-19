using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();
            IBuyer buyer = null;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                if (input.Length == 4)
                {
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthdate = input[3];
                    buyer = new Human(name, age, id, birthdate);
                }
                else if (input.Length == 3)
                {
                    int age = int.Parse(input[1]);
                    string group = input[2];
                    buyer = new Rebel(name, age, group);
                }

                buyers[name] = buyer;
            }
            string buyerName = Console.ReadLine();
            while (buyerName != "End")
            {
                if (buyers.ContainsKey(buyerName))
                {
                    buyers[buyerName].BuyFood();
                }
                buyerName = Console.ReadLine();
            }
            int totalAmountOfFood = buyers.Sum(b => b.Value.Food);
            Console.WriteLine(totalAmountOfFood);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> peoples = new List<Person>();
            string[] input1 = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                foreach (var person in input1)
                {
                    string[] persinInfo = person.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    Person newPerson = new Person(persinInfo[0], decimal.Parse(persinInfo[1]));
                    peoples.Add(newPerson);
                }
                List<Product> products = new List<Product>();
                string[] input2 = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var product in input2)
                {
                    string[] productInfo = product.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    Product newProduct = new Product(productInfo[0], decimal.Parse(productInfo[1]));
                    products.Add(newProduct);
                }
                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] cmndArgs = command.Split();
                    string peopleName = cmndArgs[0];
                    string productName = cmndArgs[1];
                    Person buyer = peoples.FirstOrDefault(p => p.Name == peopleName);
                    Product productToBuy = products.FirstOrDefault(p => p.Name == productName);

                    buyer.BayProduct(productToBuy);
                    command = Console.ReadLine();
                }
                foreach (var person in peoples)
                {

                    if (person.BagOfProducts.Count == 0)
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                    else
                    {
                        Console.Write($"{person.Name} - ");
                        int count = 0;
                        foreach (var item in person.BagOfProducts)
                        {
                            count++;
                            if (count != person.BagOfProducts.Count)
                            {
                                Console.Write($"{item.Name}, ");
                            }
                            else
                            {
                                Console.WriteLine($"{item.Name}");
                            }
                        }
                    }
                }
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
        }
    }
}

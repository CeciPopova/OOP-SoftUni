using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentificable> humanoids = new List<IIdentificable>();
            IIdentificable humanoid;

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] personData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (personData.Length == 3)
                {
                    string name = personData[0];
                    int age = int.Parse(personData[1]);
                    string id = personData[2];
                    humanoid = new Human(name, age, id);
                }
                else
                {
                    string model = personData[0];
                    string id = personData[1];
                    humanoid = new Robot(model, id);
                }
                humanoids.Add(humanoid);

                input = Console.ReadLine();
            }
            string fakeIdLastNums = Console.ReadLine();
            List<string> fakeIds = humanoids.Where(h => h.Id.EndsWith(fakeIdLastNums)).Select(h => h.Id).ToList();
            foreach (var item in fakeIds)
            {
                Console.WriteLine(item);
            }
        }
    }
}

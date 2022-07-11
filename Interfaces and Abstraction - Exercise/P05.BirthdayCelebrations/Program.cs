using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ICelebratable> celebrates = new List<ICelebratable>();
            ICelebratable celebratable = null;
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (inputData[0] == "Citizen")
                {
                    string name = inputData[1];
                    int age = int.Parse(inputData[2]);
                    string id = inputData[3];
                    string birthdate = inputData[4];
                    celebratable = new Human(name, age, id, birthdate);

                }
                else if (inputData[0] == "Pet")
                {
                    string name = inputData[1];
                    string birthdate = inputData[2];
                    celebratable = new Pet(name, birthdate);
                }
                else
                {
                    input = Console.ReadLine();
                    continue;
                }
                celebrates.Add(celebratable);

                input = Console.ReadLine();
            }
            string birthYear = Console.ReadLine();
            List<string> birthdays = celebrates.Where(c => c.Birthdate.EndsWith(birthYear)).Select(c => c.Birthdate).ToList();
            if (birthdays.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, birthdays));
            }

        }
    }
}

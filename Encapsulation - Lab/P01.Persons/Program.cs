using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int lines = int.Parse(Console.ReadLine());
            var people = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                string[] cmndArgs = Console.ReadLine().Split(' ');
                Person person = new Person(cmndArgs[0], cmndArgs[1], int.Parse(cmndArgs[2]));
                people.Add(person);
            }
            people.OrderBy(p => p.FirstName)
                .ThenBy(p => p.Age)
                .ToList()
                .ForEach(p => Console.WriteLine(p.ToString())); ;

        }
    }
}

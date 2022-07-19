using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding.Core
{
    public class Engine : IEngine
    {

        public void Start()
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                try
                {
                    BaseHero hero = null;
                    if (type == "Druid")
                    {
                        hero = new Druid(name, type);
                    }
                    else if (type == "Paladin")
                    {
                        hero = new Paladin(name, type);
                    }
                    else if (type == "Rogue")
                    {
                        hero = new Rogue(name, type);
                    }
                    else if (type == "Warrior")
                    {
                        hero = new Warrior(name, type);
                    }
                    else
                    {
                        i--;
                        throw new Exception("Invalid hero!");
                    }
                    heroes.Add(hero);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            int bossPower = int.Parse(Console.ReadLine());
            int totalPower = 0;
            if (heroes.Any())
            {
                totalPower = heroes.Sum(x => x.Power);
                foreach (var hero in heroes)
                {
                    Console.WriteLine(hero.CastAbility());

                }
            }

            if (totalPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}

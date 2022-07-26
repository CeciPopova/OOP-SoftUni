using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            var knights = new List<Knight>();
            var barbarians = new List<Barbarian>();

            foreach (var hero in players)
            {
                if (hero is Knight)
                {
                    knights.Add(hero as Knight);

                }
                else
                {
                    barbarians.Add(hero as Barbarian);
                }
            }
            while (knights.Any(x => x.IsAlive) || barbarians.Any(x => x.IsAlive))
            {
                foreach (var knight in knights)
                {
                    foreach (var barbarian in barbarians)
                    {
                        if (knight.IsAlive)
                        {
                            barbarian.TakeDamage(knight.Weapon.DoDamage());
                        }

                    }
                }
                foreach (var barbarian in barbarians)
                {
                    foreach (var knight in knights)
                    {
                        if (barbarian.IsAlive)
                        {
                            knight.TakeDamage(barbarian.Weapon.DoDamage());
                        }
                    }
                }

            }
            if (knights.Any(x => x.IsAlive))
            {
                return $"The knights took {knights.Where(k => k.IsAlive).ToList().Count} casualties but won the battle.";
            }
            else
            {
                return $"The barbarians took {barbarians.Where(b => b.IsAlive).ToList().Count} casualties but won the battle.";
            }
        }
    }
}

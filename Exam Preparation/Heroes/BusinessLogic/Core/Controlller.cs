using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IHero> heroes;
        private readonly IRepository<IWeapon> weapons;
        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();

        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            var hero = heroes.FindByName(heroName);
            var weapon = weapons.FindByName(weaponName);
            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }

            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }
            hero.AddWeapon(weapon);
            weapons.Remove(weapon);

            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            var hero = this.heroes.FindByName(name);
            if (hero != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }
            if (type == nameof(Knight))
            {
                var knight = new Knight(name, health, armour);
                heroes.Add(knight);
                return $"Successfully added Sir {name} to the collection.";
            }
            else if (type == nameof(Barbarian))
            {
                var barbarian = new Barbarian(name, health, armour);
                heroes.Add(barbarian);
                return $"Successfully added Barbarian {name} to the collection.";
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {

            if (this.weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }
            if (type == nameof(Mace))
            {
                var mace = new Mace(name, durability);
                weapons.Add(mace);
                return $"A {type.ToLower()} {name} is added to the collection.";
            }
            else if (type == nameof(Claymore))
            {
                var claymore = new Claymore(name, durability);
                weapons.Add(claymore);
                return $"A {type.ToLower()} {name} is added to the collection.";
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }
        }

        public string HeroReport()
        {
            var sb = new StringBuilder();
            var sortedHeroes = heroes.Models
                .OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(h => h.Name).ToList();
            foreach (var hero in sortedHeroes)
            {
                sb.AppendLine(hero.ToString());
            }
            return sb.ToString().Trim();
        }

        public string StartBattle()
        {
            var map = new Map();
            var herosReadyForBattle = heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToList();
            return map.Fight(herosReadyForBattle);
        }
    }
}

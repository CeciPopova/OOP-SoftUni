using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private readonly ICollection<IMilitaryUnit> units;
        private readonly ICollection<IWeapon> weapons;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.units = new List<IMilitaryUnit>();
            this.weapons = new List<IWeapon>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }



        public double Budget
        {
            get { return this.budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                this.budget = value;
            }
        }

        public double MilitaryPower => TotalAmount();

        private double TotalAmount()
        {
            double totalAmount = Army.Sum(x => x.EnduranceLevel) + Weapons.Sum(x => x.DestructionLevel);
            if (this.Army.Any(x => x.GetType().Name == "AnonymousImpactUnit"))
            {
                totalAmount += 0.30 * totalAmount;
            }

            if (Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
            {
                totalAmount += 0.45 * totalAmount;
            }

            return Math.Round(totalAmount, 3);
        }


        public IReadOnlyCollection<IMilitaryUnit> Army => units as IReadOnlyCollection<IMilitaryUnit>;

        public IReadOnlyCollection<IWeapon> Weapons => (IReadOnlyCollection<IWeapon>)weapons;

        public void AddUnit(IMilitaryUnit unit)
        {

            this.units.Add(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.Add(weapon);
        }

        public string PlanetInfo()
        {
            //    "Planet: {planetName}
            //    --Budget: { budgetAmount} billion QUID
            //    --Forces: { militaryUnitName1}, { militaryUnitName2}, { militaryUnitName3} (…) / No units
            //    --Combat equipment: { weaponName1}, { weaponName2}, { weaponName3} (…) / No weapons
            //    --Military Power: { militaryPower}
            //    "
            var armysToString = Army.Count == 0 ? "No units" : string.Join(", ", Army.Select(x => x.GetType().Name));
            var weaponsToString = Weapons.Count == 0
                ? "No weapons"
                : string.Join(", ", Weapons.Select(x => x.GetType().Name));

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {Budget}  billion QUID");
            sb.AppendLine($"--Forces: {armysToString}");
            sb.AppendLine($"--Combat equipment: {weaponsToString}");
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().TrimEnd();

        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            if (this.Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in Army)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}

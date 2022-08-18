using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            planets = new PlanetRepository();
        }
        public string CreatePlanet(string name, double budget)
        {
            var planet = planets.FindByName(name);
            if (planet != null)
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }

            var newPlanet = new Planet(name, budget);
            planets.AddItem(newPlanet);
            return String.Format(OutputMessages.NewPlanet, name);
        }


        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IMilitaryUnit unit;
            if (unitTypeName == nameof(AnonymousImpactUnit))
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            IMilitaryUnit militaryUnit = planet.Army.FirstOrDefault(x => x.GetType().Name == unitTypeName);
            if (militaryUnit != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }
            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }


        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IWeapon weapon;
            if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            var planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName,
                    planetName));
            }
            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }


        public string SpecializeForces(string planetName)
        {
            var planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NoUnitsFound));
            }
            planet.Spend(1.25);
            planet.TrainArmy();
            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }


        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var enemyPlanet = planets.FindByName(planetOne);
            var planet = planets.FindByName(planetTwo);

            bool isNuclearWeaponOnPlanet = planet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon");
            bool isNuclearWeaponOnEnemy = enemyPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon");
            string output = String.Empty;
            if (enemyPlanet.MilitaryPower == planet.MilitaryPower)
            {

                if ((isNuclearWeaponOnEnemy == true && isNuclearWeaponOnPlanet == true) ||
                    (isNuclearWeaponOnEnemy == false && isNuclearWeaponOnPlanet == false))
                {
                    output = String.Format(OutputMessages.NoWinner);
                    planet.Spend(planet.Budget / 2);
                    enemyPlanet.Spend(enemyPlanet.Budget / 2);
                }
                else if (isNuclearWeaponOnEnemy == true && isNuclearWeaponOnPlanet == false)
                {
                    enemyPlanet.Spend(enemyPlanet.Budget / 2);
                    enemyPlanet.Profit(planet.Budget / 2);
                    enemyPlanet.Profit(planet.Army.Sum(x => x.Cost) + planet.Weapons.Sum(x => x.Price));
                    planets.RemoveItem(planetTwo);
                    output = String.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
                }
                else if (isNuclearWeaponOnEnemy == false && isNuclearWeaponOnPlanet == true)
                {
                    planet.Spend(planet.Budget / 2);
                    planet.Profit(enemyPlanet.Budget / 2);
                    planet.Profit(enemyPlanet.Army.Sum(x => x.Cost) + enemyPlanet.Weapons.Sum(x => x.Price));
                    planets.RemoveItem(planetOne);
                    output = String.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                }

            }
            else if (enemyPlanet.MilitaryPower > planet.MilitaryPower)
            {
                enemyPlanet.Spend(enemyPlanet.Budget / 2);
                enemyPlanet.Profit(planet.Budget / 2);
                enemyPlanet.Profit(planet.Army.Sum(x => x.Cost) + planet.Weapons.Sum(x => x.Price));
                planets.RemoveItem(planetTwo);
                output = String.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }
            else
            {
                planet.Spend(planet.Budget / 2);
                planet.Profit(enemyPlanet.Budget / 2);
                planet.Profit(enemyPlanet.Army.Sum(x => x.Cost) + enemyPlanet.Weapons.Sum(x => x.Price));
                planets.RemoveItem(planetOne);
                output = String.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);

            }

            return output;

        }


        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

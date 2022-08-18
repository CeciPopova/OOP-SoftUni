﻿using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly ICollection<IMilitaryUnit> models;
        public UnitRepository()
        {
            models = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => (IReadOnlyCollection<IMilitaryUnit>)models;

        public void AddItem(IMilitaryUnit model)
        {
            models.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            var unit = models.FirstOrDefault(x => x.GetType().Name == name);
            if (unit == null)
            {
                return null;
            }
            return unit;
        }

        public bool RemoveItem(string name)
        {
            var item = models.FirstOrDefault(x => x.GetType().Name == name);
            if (item == null)
            {
                return false;
            }
            models.Remove(item);
            return true;
        }
    }
}

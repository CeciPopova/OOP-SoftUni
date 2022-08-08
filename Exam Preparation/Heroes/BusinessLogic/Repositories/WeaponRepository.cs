using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly Collection<IWeapon> models;
        public WeaponRepository() : base()
        {
            models = new Collection<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models { get { return this.models; } }


        public IWeapon FindByName(string name)
        {
            var weapon = Models.FirstOrDefault(x => x.Name == name);
            if (weapon == null)
            {
                return null;
            }
            else
            {
                return weapon;
            }
        }

        public void Add(IWeapon model)
        {
            if (models.Contains(model))
            {
                throw new InvalidOperationException($"The weapon {model.Name} already exists.");
            }
            models.Add(model);
        }

        public bool Remove(IWeapon model)
        {
            var weaponToRemove = models.FirstOrDefault(x => x.Name == model.Name);

            if (weaponToRemove != null)
            {
                models.Remove(weaponToRemove);
                return true;
            }
            return false;
        }
    }

}

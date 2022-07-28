using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly IList<IWeapon> models;
        public WeaponRepository() : base()
        {
            models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models { get { return (IReadOnlyList<IWeapon>)Models; } }


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
            if (!models.Contains(model))
            {
                models.Add(model);
            }
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

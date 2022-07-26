using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly IList<IWeapon> weapons;
        public WeaponRepository() : base()
        {
            weapons = new List<IWeapon>();
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
            if (weapons.All(x => x.Name != model.Name))
            {
                weapons.Add(model);
            }
        }

        public bool Remove(IWeapon model)
        {
            var weaponToRemove = weapons.FirstOrDefault(x => x.Name == model.Name);

            if (weaponToRemove != null)
            {
                var index = weapons.IndexOf(model);

                weapons.RemoveAt(index);
                return true;
            }
            return false;
        }
    }

}

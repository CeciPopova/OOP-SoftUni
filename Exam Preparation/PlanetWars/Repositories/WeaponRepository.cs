using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> models;
        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => (IReadOnlyCollection<IWeapon>)models;

        public void AddItem(IWeapon model)
        {
            models.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            var weapon = models.FirstOrDefault(x => x.GetType().Name == name);
            if (weapon == null)
            {
                return null;
            }

            return weapon;
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

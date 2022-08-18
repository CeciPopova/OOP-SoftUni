using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly ICollection<IPlanet> models;
        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => (IReadOnlyCollection<IPlanet>)models;


        public void AddItem(IPlanet model)
        {
            models.Add(model);
        }


        public IPlanet FindByName(string name)
        {
            var planet = this.models.FirstOrDefault(p => p.Name == name);
            if (planet == null)
            {
                return null;
            }
            return planet;
        }


        public bool RemoveItem(string name)
        {
            var item = models.FirstOrDefault(x => x.Name == name);
            if (item == null)
            {
                return false;
            }
            models.Remove(item);
            return true;
        }
    }
}

using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly IList<IHero> models;


        public IReadOnlyCollection<IHero> Models { get { return (IReadOnlyList<IHero>)models; } }

        public void Add(IHero model)
        {
            if (!models.Contains(model))
            {
                models.Add(model);
            }
        }
        public bool Remove(IHero model)
        {
            var heroToRemove = models.FirstOrDefault(x => x.Name == model.Name);

            if (heroToRemove != null)
            {
                models.Remove(heroToRemove);
                return true;
            }
            return false;
        }
        public IHero FindByName(string name)
        {
            var hero = Models.FirstOrDefault(h => h.Name == name);
            if (hero == null)
            {
                return null;
            }
            else
            {
                return hero;
            }
        }
    }
}

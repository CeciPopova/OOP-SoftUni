using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly IList<IHero> heroes;


        public IReadOnlyCollection<IHero> Models { get { return (IReadOnlyList<IHero>)heroes; } }

        public void Add(IHero model)
        {
            if (heroes.All(x => x.Name != model.Name))
            {
                heroes.Add(model);
            }
        }
        public bool Remove(IHero model)
        {
            var heroToRemove = heroes.FirstOrDefault(x => x.Name == model.Name);

            if (heroToRemove != null)
            {
                var index = heroes.IndexOf(model);

                heroes.RemoveAt(index);
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

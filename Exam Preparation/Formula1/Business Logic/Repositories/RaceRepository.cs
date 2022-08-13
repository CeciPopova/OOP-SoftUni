using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly ICollection<IRace> models;
        public RaceRepository()
        {
            models = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models => (IReadOnlyCollection<IRace>)this.models;

        public void Add(IRace model)
        {
            var race = this.Models.FirstOrDefault(x => x.RaceName == model.RaceName);
            if (race != null)
            {
                throw new InvalidOperationException($"Race {model.RaceName} is already created.");
            }
            models.Add(model);
        }

        public IRace FindByName(string name)
        {
            var race = this.Models.FirstOrDefault(x => x.RaceName == name);
            if (race == null)
            {
                //return null;
                throw new NullReferenceException($"Race {name} does not exist.");
            }
            else
            {
                return race;
            }
        }

        public bool Remove(IRace model)
        {
            var race = models.FirstOrDefault(r => r.RaceName == model.RaceName);
            if (race != null)
            //if (this.Models.Contains(model))
            {
                models.Remove(model);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

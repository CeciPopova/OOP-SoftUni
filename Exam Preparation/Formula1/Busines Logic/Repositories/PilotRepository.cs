using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly ICollection<IPilot> models;
        public PilotRepository()
        {
            models = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => (IReadOnlyCollection<IPilot>)this.models;

        public void Add(IPilot model)
        {
            if (this.models.Contains(model))
            {
                throw new InvalidOperationException($"Pilot {model.FullName} is already created.");
            }
            models.Add(model);
        }

        public IPilot FindByName(string name)
        {
            var car = this.Models.FirstOrDefault(x => x.FullName == name);
            if (car == null)
            {
                return null;
                //throw new NullReferenceException($"Car {name} does not exist.");
            }
            else
            {
                return car;
            }
        }

        public bool Remove(IPilot model)
        {
            //var pilot = models.FirstOrDefault(p=>p.FullName==model.FullName);
            //if(pilot!=null)        
            if (this.Models.Contains(model))
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

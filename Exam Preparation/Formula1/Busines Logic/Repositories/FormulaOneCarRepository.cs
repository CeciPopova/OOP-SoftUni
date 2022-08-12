using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly ICollection<IFormulaOneCar> models;
        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => (IReadOnlyCollection<IFormulaOneCar>)this.models;

        public void Add(IFormulaOneCar model)
        {
            if (this.models.Contains(model))
            {
                throw new InvalidOperationException($"Formula one car {model.Model} is already created.");
            }
            models.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            var car = this.Models.FirstOrDefault(x => x.Model == name);
            if (car == null)
            {
                //return null;
                throw new NullReferenceException($"Car {name} does not exist.");
            }
            else
            {
                return car;
            }

        }

        public bool Remove(IFormulaOneCar model)
        {
            //var car = models.FirstOrDefault(c=>c.Model==model.Model);
            //if(car!=null)        
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

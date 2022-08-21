using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly ICollection<IEquipment> models;
        public EquipmentRepository()
        {
            this.models = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models => throw new System.NotImplementedException();

        public void Add(IEquipment model)
        {
            models.Add(model);  
        }

        public IEquipment FindByType(string type)
        {
            var model = models.FirstOrDefault(x => x.GetType().Name == type);
            return model;
        }

        public bool Remove(IEquipment model)
        {
           return models.Remove(model); 
        }
    }
}

using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Repositories
{

    public class DecorationRepository : IRepository<IDecoration>
    {
        private ICollection<IDecoration> models;
        public DecorationRepository()
        {
            models = new List<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models => (IReadOnlyCollection<IDecoration>)models;

        public void Add(IDecoration model)
        {
            this.models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            var decoration = Models.FirstOrDefault(x => x.GetType().Name == type);

            return decoration;

        }

        public bool Remove(IDecoration model)
        {
            var decoration = Models.FirstOrDefault(x => x.Equals(model));
            if (decoration == null)
            {
                return false;
            }
            models.Remove(decoration);
            return true;
        }
    }
}

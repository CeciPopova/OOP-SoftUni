using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private ICollection<IAstronaut> models;
        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }
        /// <inheritdoc />
        public IReadOnlyCollection<IAstronaut> Models { get; }

        /// <inheritdoc />
        public void Add(IAstronaut model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Remove(IAstronaut model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public IAstronaut FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private ICollection<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }
        /// <inheritdoc />
        public IReadOnlyCollection<IPlanet> Models { get; }

        /// <inheritdoc />
        public void Add(IPlanet model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Remove(IPlanet model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public IPlanet FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

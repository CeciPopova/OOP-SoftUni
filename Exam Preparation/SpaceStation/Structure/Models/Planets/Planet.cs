using SpaceStation.Models.Planets.Contracts;
using System.Collections.Generic;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private ICollection<string> items;
        public Planet(string name)
        {
            this.items = new List<string>();
        }
        /// <inheritdoc />
        public ICollection<string> Items { get; }

        /// <inheritdoc />
        public string Name { get; }
    }
}

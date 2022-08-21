using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags.Contracts;
using System;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        public Astronaut(string name, double oxygen)
        {

        }
        /// <inheritdoc />
        public string Name { get; }

        /// <inheritdoc />
        public double Oxygen { get; }

        /// <inheritdoc />
        public bool CanBreath { get; }

        /// <inheritdoc />
        public IBag Bag { get; }

        /// <inheritdoc />
        public virtual void Breath()
        {
            throw new NotImplementedException();
        }
    }
}

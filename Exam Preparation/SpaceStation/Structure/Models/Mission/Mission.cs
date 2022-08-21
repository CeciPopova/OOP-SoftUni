using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public Mission()
        {

        }
        /// <inheritdoc />
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            throw new NotImplementedException();
        }
    }
}

using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private readonly ICollection<IVessel> vesselRepository;
        public VesselRepository()
        {
            this.vesselRepository = new List<IVessel>();
        }
        /// <inheritdoc />
        public IReadOnlyCollection<IVessel> Models => throw new NotImplementedException();

        /// <inheritdoc />
        public void Add(IVessel model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Remove(IVessel model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public IVessel FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

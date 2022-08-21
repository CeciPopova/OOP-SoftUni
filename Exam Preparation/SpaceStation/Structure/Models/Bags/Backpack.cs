using SpaceStation.Models.Bags.Contracts;
using System.Collections.Generic;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        private ICollection<string> items;
        public Backpack()
        {
            this.items = new List<string>();
        }
        /// <inheritdoc />
        public ICollection<string> Items { get; }
    }
}

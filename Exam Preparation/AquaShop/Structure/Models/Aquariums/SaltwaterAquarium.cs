using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System.Collections.Generic;

namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        public SaltwaterAquarium(string name, int capacity) : base(name, 25)
        {
        }

        
    }
}

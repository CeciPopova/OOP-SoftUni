﻿using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System.Collections.Generic;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        public Aquarium(string name, int capacity)
        {

        }
        public string Name => throw new System.NotImplementedException();

        public int Capacity => throw new System.NotImplementedException();

        public int Comfort => throw new System.NotImplementedException();

        public ICollection<IDecoration> Decorations => throw new System.NotImplementedException();

        public ICollection<IFish> Fish => throw new System.NotImplementedException();

        public void AddDecoration(IDecoration decoration)
        {
            throw new System.NotImplementedException();
        }

        public void AddFish(IFish fish)
        {
            throw new System.NotImplementedException();
        }

        public void Feed()
        {
            throw new System.NotImplementedException();
        }

        public string GetInfo()
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveFish(IFish fish)
        {
            throw new System.NotImplementedException();
        }
    }
}

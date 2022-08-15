using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fishes;
        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fishes = new List<IFish>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {

                this.capacity = value;
            }
        }

        public int Comfort => decorations.Sum(x => x.Comfort);


        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fishes;

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fishes.Count == this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            this.fishes.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var fishNames = Fish.Select(x => x.Name).ToList();


            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            if (fishNames.Count == 0)
            {
                sb.AppendLine("Fish: none");
            }
            else
            {
                sb.AppendLine($"Fish: {string.Join(", ", fishNames)}");
            }
            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");
            return sb.ToString().TrimEnd();

        }

        public bool RemoveFish(IFish fish)
        {
            var fishToRemove = Fish.FirstOrDefault(x => x.Name == fish.Name);
            if (fishToRemove == null)
            {
                return false;
            }
            Fish.Remove(fishToRemove);
            return true;
        }
    }
}

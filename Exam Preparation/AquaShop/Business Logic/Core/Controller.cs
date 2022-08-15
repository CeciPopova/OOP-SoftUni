using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;
        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);

            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);

            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
            aquariums.Add(aquarium);
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            Decoration decoration;
            if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else if (decorationType == nameof(Plant))
            {
                decoration = new Plant();
            }
            else
            {
                return "Invalid decoration type.";
            }
            decorations.Add(decoration);
            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }
            var aquarium = aquariums.Find(a => a.Name == aquariumName);
            if ((aquarium.GetType().Name == nameof(FreshwaterAquarium) && fish.GetType().Name == nameof(FreshwaterFish)) || (aquarium.GetType().Name == nameof(SaltwaterAquarium) && fishType == nameof(SaltwaterFish)))
            {
                aquarium.Fish.Add(fish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            else
            {
                return "Water not suitable.";
            }

        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal aquariumValue = aquarium.Decorations.Sum(x => x.Price);
            return $"The value of Aquarium {aquariumName} is {aquariumValue:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();
            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            var decoration = decorations.FindByType(decorationType);
            if (decoration != null)
            {
                aquarium.AddDecoration(decoration);
                decorations.Remove(decoration);
                return $"Successfully added {decorationType} to {aquariumName}.";
            }
            else
            {
                return $"There isn't a decoration of type {decorationType}.";
            }

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

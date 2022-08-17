using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly DecorationRepository decorations;
        private readonly ICollection<IAquarium> aquariums;
        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new HashSet<IAquarium>();
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
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            aquariums.Add(aquarium);
            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            Decoration decoration;
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidDecorationType));
            }
            decorations.Add(decoration);
            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
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
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidFishType));
            }
            var aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            if ((aquarium?.GetType().Name == nameof(FreshwaterAquarium) && fish.GetType().Name == nameof(FreshwaterFish)) || (aquarium?.GetType().Name == nameof(SaltwaterAquarium) && fishType == nameof(SaltwaterFish)))
            {
                aquarium.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquarium.Name);
            }
            else
            {
                return string.Format(OutputMessages.UnsuitableWater);
            }

        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal aquariumValue = aquarium!.Decorations.Sum(x => x.Price) + aquarium.Fish.Sum(x => x.Price);
            return String.Format(OutputMessages.AquariumValue, aquariumName, aquariumValue);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium?.Feed();
            var fishCount = aquarium?.Fish.Count();
            return String.Format(OutputMessages.FishFed, fishCount);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            var decoration = decorations.FindByType(decorationType);
            if (decoration != null)
            {
                aquarium?.AddDecoration(decoration);
                decorations.Remove(decoration);
                return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
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

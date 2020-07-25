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
        public Controller() { }

        private DecorationRepository decorations = new DecorationRepository();
        private List<IAquarium> aquariums = new List<IAquarium>();
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    aquariums.Add(new FreshwaterAquarium(aquariumName));
                    break;
                case "SaltwaterAquarium":
                    aquariums.Add(new SaltwaterAquarium(aquariumName));
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            switch (decorationType)
            {
                case "Ornament":
                    decorations.Add(new Ornament());
                    break;
                case "Plant":
                    decorations.Add(new Plant());
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            Fish fish;
            switch (fishType)
            {
                case "FreshwaterFish":
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    break;
                case "SaltwaterFish":
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            var aquariumType = aquarium.GetType().Name;

            if ((aquariumType == "FreshwaterAquarium" && fishType == "FreshwaterFish") || (aquariumType == "SaltwaterAquarium" && fishType == "SaltwaterFish"))
            {
                aquarium.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }

            return OutputMessages.UnsuitableWater;

        }

        public string CalculateValue(string aquariumName)
        {
            decimal value = 0;
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            var decorations = aquarium.Decorations;
            var fishes = aquarium.Fish;
            
            foreach (var item in decorations)
            {
                value += item.Price;    
            }

            foreach (var item in fishes)
            {
                value += item.Price;
            }

            return string.Format(OutputMessages.AquariumValue, aquariumName, $"{value:f2}");

        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();
            var count = aquarium.Fish.Count();
            return string.Format(OutputMessages.FishFed, count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            decorations.Remove(decoration);
            aquariums.FirstOrDefault(x => x.Name == aquariumName).AddDecoration(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var item in aquariums)
            {
                sb.AppendLine(item.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

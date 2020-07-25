using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        public Aquarium(string name, int capacity) 
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        private List<IDecoration> decorations = new List<IDecoration>();
        private Dictionary<string, IFish> fishes= new Dictionary<string,IFish>();
        private string name;
        public string Name { get => this.name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }
        

        public int Capacity { get; private set; }

        public int Comfort => CalculateComfort();

        public ICollection<IDecoration> Decorations => decorations;

        public ICollection<IFish> Fish => fishes.Values;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fishes.Count() >= this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fishes.Add(fish.Name, fish);
        }

        public void Feed()
        {
            foreach (var fish in this.fishes.Values)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            if (fishes.Any())
            {
                sb.AppendLine($"Fish: {string.Join(", ", fishes.Select(x=>x.Key))}");
            }
            else 
            {
                sb.AppendLine($"Fish: none");
            }
            sb.AppendLine($"Decorations: {this.decorations.Count()}");
            sb.AppendLine($"Comfort: {this.Comfort}");
            return sb.ToString().TrimEnd();
            
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fishes.Remove(fish.Name);
        }

        private int CalculateComfort() 
        {
            var sum = 0;
            foreach (var decor in decorations)
            {
                sum += decor.Comfort;
            }
            return sum;
        }
    }
}

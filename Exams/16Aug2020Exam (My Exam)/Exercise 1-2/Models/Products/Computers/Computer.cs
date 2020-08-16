using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components = new List<IComponent>();
        private List<IPeripheral> peripherals = new List<IPeripheral>();
        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            this.OverallPerformance = overallPerformance;
            this.Price = price;
        }

        private double computerPerformace;

        private decimal pcPrice;
        public new decimal Price
        {
            get => this.peripherals.Sum(x => x.Price) + this.components.Sum(x => x.Price) + this.pcPrice;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }
                this.pcPrice = value;
            }
        }

        public new double OverallPerformance
        {
            get
            {
                if (components.Count() == 0)
                {
                    return this.computerPerformace;
                }
                else
                {
                    return this.computerPerformace + components.Average(x => x.OverallPerformance);
                }
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);
                }
                this.computerPerformace = value;
            }
        }
        public IReadOnlyCollection<IComponent> Components => this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals;

        public void AddComponent(IComponent component)
        {
            if (components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }
            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }
            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = components.FirstOrDefault(x => x.GetType().Name == componentType);
            if (component == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }
            components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheral = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (peripheral == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }
            peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Overall Performance: {this.OverallPerformance:f2}. Price: {this.Price:f2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            sb.AppendLine($" Components ({this.components.Count()}):");
            foreach (var item in components)
            {
                sb.AppendLine("  "+ item.ToString());
            }
            if (peripherals.Count() == 0)
            {
                sb.AppendLine($" Peripherals ({0}); Average Overall Performance ({0:f2}):");
            }
            else
            {
                sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({this.peripherals.Average(x => x.OverallPerformance):f2}):");
            }
            foreach (var item in peripherals)
            {
                sb.AppendLine("  "+item.ToString());
            }
            return sb.ToString().TrimEnd();

        }
    }
}

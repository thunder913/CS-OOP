using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers = new List<IComputer>();
        private List<IComponent> components = new List<IComponent>();
        private List<IPeripheral> peripherals = new List<IPeripheral>();

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComponent component = null;
            ExistingComputer(computerId);
            IComputer computer = computers.First(x => x.Id == computerId);
            if (this.components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
            switch (componentType)
            {
                case "CentralProcessingUnit":
                    component = new CentralProcessingUnit(id,manufacturer,model,price,overallPerformance,generation);
                    break;
                case "Motherboard":
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "PowerSupply":
                    component =  new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "RandomAccessMemory":
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "SolidStateDrive":
                    component =  new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "VideoCard":
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
            computer.AddComponent(component);
            components.Add(component);
            return string.Format(SuccessMessages.AddedComponent, componentType,id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(x=>x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }
            switch (computerType)
            {
                case "Laptop":
                    this.computers.Add(new Laptop(id, manufacturer, model, price));
                    break;
                case "DesktopComputer":
                    this.computers.Add(new DesktopComputer(id, manufacturer, model, price));
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
            
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            ExistingComputer(computerId);
            IPeripheral peripheral = null ;
            if (this.peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheralId));
            }
            switch (peripheralType)
            {
                case "Headset":
                    peripheral = new Headset(id,manufacturer,model,price,overallPerformance,connectionType);
                    break;
                case "Keyboard":
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Monitor":
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Mouse":
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }
            computers.First(x => x.Id == computerId).AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);
            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            var computer = computers.Where(x => x.Price <= budget).OrderByDescending(x => x.OverallPerformance).FirstOrDefault();
            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
            computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            ExistingComputer(id);
            var computer = computers.First(x => x.Id == id);
            computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            ExistingComputer(id);
            var computer = computers.First(x => x.Id == id);
            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            ExistingComputer(computerId);
            var component = computers.First(x => x.Id == computerId).RemoveComponent(componentType);
            components.Remove(component);
            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            ExistingComputer(computerId);
            var peripheral = computers.First(x=>x.Id==computerId).RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);
            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        private void ExistingComputer(int id) 
        {
            if (!this.computers.Any(x=>x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}

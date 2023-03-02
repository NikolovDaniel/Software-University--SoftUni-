using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        private List<IComputer> computers;
        public Controller()
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
            this.computers = new List<IComputer>();
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            CheckIfComputerIdExists(computerId);

            IComponent component = null;

            switch (componentType)
            {
                case nameof(CentralProcessingUnit):
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(Motherboard):
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(PowerSupply):
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(RandomAccessMemory):
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(SolidStateDrive):
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(VideoCard):
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            IComponent existingComponent = components.FirstOrDefault(x => x.Id == component.Id);

            if (existingComponent != null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComputer computer = computers.First(x => x.Id == computerId);

            computer.AddComponent(component);
            components.Add(component);

            return string.Format(SuccessMessages.AddedComponent, component.GetType().Name, component.Id, computer.Id);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = null;

            switch (computerType)
            {
                case nameof(Laptop):
                    computer = new Laptop(id, manufacturer, model, price);
                    break;
                case nameof(DesktopComputer):
                    computer = new DesktopComputer(id, manufacturer, model, price);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            IComputer existingComputer = computers.FirstOrDefault(x => x.Id == computer.Id);

            if (existingComputer != null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, computer.Id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            CheckIfComputerIdExists(computerId);

            IPeripheral peripheral = null;

            switch (peripheralType)
            {
                case nameof(Monitor):
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case nameof(Mouse):
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case nameof(Headset):
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case nameof(Keyboard):
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            IPeripheral existingPeripheral = peripherals.FirstOrDefault(x => x.Id == peripheral.Id);

            if (existingPeripheral != null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            computers.First(x => x.Id == computerId).AddPeripheral(peripheral);
            peripherals.Add(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheral.GetType().Name, peripheral.Id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            IComputer boughtComputer = computers.OrderByDescending(x => x.OverallPerformance).FirstOrDefault(x => x.Price <= budget);

            if (computers.Count == 0 || boughtComputer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            computers.Remove(boughtComputer);

            return boughtComputer.ToString();
        }

        public string BuyComputer(int id)
        {
            CheckIfComputerIdExists(id);

            IComputer computer = computers.First(x => x.Id == id);
            computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            CheckIfComputerIdExists(id);

            IComputer computer = computers.First(x => x.Id == id);

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckIfComputerIdExists(computerId);

            IComputer computer = computers.First(x => x.Id == computerId);
            IComponent component = components.FirstOrDefault(x => x.GetType().Name == componentType);

            if (component == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, computer.GetType().Name, computer.Id));
            }

            computer.RemoveComponent(component.GetType().Name);
            components.Remove(component);

            return string.Format(SuccessMessages.RemovedComponent, component.GetType().Name, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckIfComputerIdExists(computerId);

            IComputer computer = computers.First(x => x.Id == computerId);
            IPeripheral peripheral = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (peripheral == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, this.GetType().Name, peripheral.GetType(), computer.Id));
            }

            computer.RemovePeripheral(peripheral.GetType().Name);
            peripherals.Remove(peripheral);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheral.GetType().Name, peripheral.Id);
        }

        private void CheckIfComputerIdExists(int id)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == id);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}

using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IPeripheral> peripherals;
        private List<IComponent> components;
        private double averageOverallPerformance => peripherals.Count == 0 ? 0 : peripherals.Sum(x => x.OverallPerformance) / peripherals.Count;
        public IReadOnlyCollection<IComponent> Components => components;
        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals;
        public override double OverallPerformance
        {
            get
            {
                if (components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    return base.OverallPerformance + components.Average(x => x.OverallPerformance);
                }
            }
        }
        public override decimal Price => base.Price + Components.Sum(x => x.Price) + Peripherals.Sum(x => x.Price);

        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.peripherals = new List<IPeripheral>();
            this.components = new List<IComponent>();
        }
        public void AddComponent(IComponent component)
        {
            IComponent existingComponent = components.FirstOrDefault(x => x.Model == component.Model);

            if (existingComponent != null)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, existingComponent.Id));
            }

            components.Add(component);
        }
        public void AddPeripheral(IPeripheral peripheral)
        {
            IPeripheral existingPeripheral = peripherals.FirstOrDefault(x => x.Model == peripheral.Model);

            if (existingPeripheral != null)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, existingPeripheral.Id));
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = components.FirstOrDefault(x => x.GetType().Name == componentType);

            if (components.Count == 0 || component == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            components.Remove(component);

            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheral = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (peripherals.Count == 0 || peripheral == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, peripheralType, this.GetType().Name, this.Id));
            }

            peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(SuccessMessages.ProductToString, OverallPerformance, Price, this.GetType().Name, Manufacturer, Model, Id));
            sb.AppendLine($" {string.Format(SuccessMessages.ComputerComponentsToString, components.Count)}");

            foreach (var component in components)
            {
                sb.AppendLine($"  {component}");
            }

            double avgPerformance = peripherals.Count == 0 ? 0 : averageOverallPerformance;

            sb.AppendLine($" {string.Format(SuccessMessages.ComputerPeripheralsToString, peripherals.Count, avgPerformance)}");

            foreach (var peripheral in peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

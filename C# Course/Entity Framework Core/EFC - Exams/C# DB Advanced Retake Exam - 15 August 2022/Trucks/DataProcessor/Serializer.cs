namespace Trucks.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System.Xml;
    using System.Xml.Serialization;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            XmlRootAttribute rootAttribute = new XmlRootAttribute("Despatchers");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportDespatcherDto[]), rootAttribute);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var despatchers = context.Despatchers
                                     .Where(d => d.Trucks.Count > 0)
                                     .Select(d => new ExportDespatcherDto()
                                     {
                                         Count = d.Trucks.Count,
                                         DespatcherName = d.Name,
                                         Trucks = d.Trucks.Select(t => new ExportDespatcherTruck()
                                         {
                                             RegistrationNumber = t.RegistrationNumber,
                                             Make = ((MakeType)t.MakeType).ToString()
                                         })
                                         .OrderBy(t => t.RegistrationNumber)
                                         .ToArray()
                                     })
                                     .OrderByDescending(d => d.Trucks.Count())
                                     .ThenBy(d => d.DespatcherName)
                                     .ToArray();

            using StringWriter writer = new StringWriter();

            serializer.Serialize(writer, despatchers, namespaces);

            string result = writer.ToString();

            return result;
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                                 .AsEnumerable()
                                 .Where(c => c.ClientsTrucks.Select(t => t.Truck.TankCapacity >= capacity).Count() > 0)
                                 .Select(c => new ExportClientWithMostTrucksDto()
                                 {
                                     Name = c.Name,
                                     Trucks = c.ClientsTrucks
                                     .Where(ct => ct.Truck.TankCapacity >= capacity)
                                     .Select(ct => new ExportTruckDto()
                                     {
                                         TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                                         VinNumber = ct.Truck.VinNumber,
                                         TankCapacity = ct.Truck.TankCapacity,
                                         CargoCapacity = ct.Truck.CargoCapacity,
                                         CategoryType = ((CategoryType)(ct.Truck.CategoryType)).ToString(),
                                         MakeType = ((MakeType)(ct.Truck.MakeType)).ToString()
                                     })
                                     .OrderBy(t => t.MakeType)
                                     .ThenByDescending(t => t.CargoCapacity)
                                     .ToArray()
                                 })
                                 .OrderByDescending(c => c.Trucks.Count())
                                 .ThenBy(c => c.Name)
                                 .Take(10)
                                 .ToArray();

            return JsonConvert.SerializeObject(clients, Newtonsoft.Json.Formatting.Indented);
        }
    }
}

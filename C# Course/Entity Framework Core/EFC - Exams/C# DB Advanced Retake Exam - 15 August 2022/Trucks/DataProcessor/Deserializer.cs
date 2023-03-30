namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Trucks.Data.Models;
    using Trucks.DataProcessor.ImportDto;
    using Trucks.Data.Models.Enums;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            IMapper mapper = CreateMapper();

            XmlRootAttribute rootAttribute = new XmlRootAttribute("Despatchers");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportDespatcherDto[]), rootAttribute);

            using StringReader reader = new StringReader(xmlString);

            ImportDespatcherDto[] despatcherDtos = (ImportDespatcherDto[])serializer.Deserialize(reader);

            reader.Close();

            List<Despatcher> validDespatchers = new List<Despatcher>();

            StringBuilder sb = new StringBuilder();

            foreach (var despatcherDto in despatcherDtos)
            {
                try
                {

                    if (despatcherDto.Name.Length < 2 || despatcherDto.Name.Length > 40)
                    {
                        throw new Exception();
                    }

                    if (string.IsNullOrEmpty(despatcherDto.Position))
                    {
                        throw new Exception();
                    }

                    List<Truck> validTrucks = new List<Truck>();

                    foreach (var truckDto in despatcherDto.Trucks)
                    {
                        if (truckDto.RegistrationNumber.Length != 8
                            || string.IsNullOrEmpty(truckDto.RegistrationNumber)
                            || string.IsNullOrEmpty(truckDto.VinNumber)
                            || truckDto.TankCapacity < 950
                            || truckDto.TankCapacity > 1420
                            || truckDto.CargoCapacity < 5000
                            || truckDto.CargoCapacity > 29000
                            || truckDto.VinNumber.Length != 17)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        Truck truck = new Truck()
                        {
                            RegistrationNumber = truckDto.RegistrationNumber,
                            VinNumber = truckDto.VinNumber,
                            TankCapacity = truckDto.TankCapacity,
                            CargoCapacity = truckDto.CargoCapacity,
                            CategoryType = (CategoryType)truckDto.CategoryType,
                            MakeType = (MakeType)truckDto.MakeType
                        };

                        validTrucks.Add(truck);
                    }

                    Despatcher despatcher = new Despatcher()
                    {
                        Name = despatcherDto.Name,
                        Position = despatcherDto.Position,
                        Trucks = validTrucks
                    };

                    validDespatchers.Add(despatcher);

                    sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
                }
                catch (Exception)
                {

                    sb.AppendLine(ErrorMessage);
                    continue;
                }
            }

            context.Despatchers.AddRange(validDespatchers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

      
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            ImportClientDto[] clientDtos = JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Client> validClients = new List<Client>();

            foreach (var clientDto in clientDtos)
            {
                try
                {
                    if (clientDto.Name.Length < 3 || clientDto.Name.Length > 40 || string.IsNullOrEmpty(clientDto.Name)
                        || clientDto.Nationality.Length < 2 || clientDto.Nationality.Length > 40 || string.IsNullOrEmpty(clientDto.Name)
                        || string.IsNullOrEmpty(clientDto.Type) || clientDto.Type == "usual")
                    {
                        throw new Exception();
                    }

                    Client client = new Client()
                    {
                        Name = clientDto.Name,
                        Nationality = clientDto.Nationality,
                        Type = clientDto.Type
                    };

                    foreach (var truckId in clientDto.Trucks.DistinctBy(id => id))
                    {
                        if (context.Trucks.Find(truckId) == null)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        ClientTruck clientTruck = new ClientTruck()
                        {
                            TruckId = truckId
                        };

                        client.ClientsTrucks.Add(clientTruck);
                    }

                    validClients.Add(client);
                    sb.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
                }
                catch (Exception)
                {

                    sb.AppendLine(ErrorMessage);
                    continue;
                }
            }

            context.Clients.AddRange(validClients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static IMapper CreateMapper() =>
          new Mapper(new MapperConfiguration(cfg =>
          {
              cfg.AddProfile<TrucksProfile>();
          }));

    }
}
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            CreateAndPopulateDatabase(context);
        }

        // Problem 01. Import Suppliers
        public static void ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            ImportSupplierDto[] suppliersDtos = Deserialize<ImportSupplierDto[]>("Suppliers", inputXml);

            Supplier[] validSuppliers = mapper.Map<Supplier[]>(suppliersDtos);

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();
        }

        // Problem 02. Import Parts
        public static void ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            ImportPartDto[] partsDtos = Deserialize<ImportPartDto[]>("Parts", inputXml);

            List<Part> validParts = new List<Part>();

            foreach (var partDto in partsDtos)
            {
                if (context.Suppliers.Find(partDto.SupplierId) == null)
                {
                    continue;
                }

                Part part = mapper.Map<ImportPartDto, Part>(partDto);

                validParts.Add(part);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();
        }

        // Problem 03. Import Cars
        public static void ImportCars(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            ImportCarDto[] carsDtos = Deserialize<ImportCarDto[]>("Cars", inputXml);

            List<Car> validCars = new List<Car>();

            foreach (ImportCarDto carDto in carsDtos)
            {
                Car car = mapper.Map<Car>(carDto);

                foreach (ImportCarPartDto carPartDto in carDto.Parts.DistinctBy(p => p.PartId))
                {
                    if (!context.Parts.Any(p => p.Id == carPartDto.PartId))
                    {
                        continue;
                    }

                    PartCar carPart = new PartCar()
                    {
                        PartId = carPartDto.PartId
                    };

                    car.PartsCars.Add(carPart);
                }

                validCars.Add(car);
            }

            context.Cars.AddRange(validCars);
            context.SaveChanges();
        }

        // Problem 04. Import Customers
        public static void ImportCustomers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            ImportCustomerDto[] customersDto = Deserialize<ImportCustomerDto[]>("Customers", inputXml);

            Customer[] validCustomers = mapper.Map<Customer[]>(customersDto);

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();
        }

        // Problem 05. Import Sales
        public static void ImportSales(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            ImportSaleDto[] salesDto = Deserialize<ImportSaleDto[]>("Sales", inputXml);

            List<Sale> validSales = new List<Sale>();

            foreach (var saleDto in salesDto)
            {
                if (context.Cars.Find(saleDto.CarId) == null)
                {
                    continue;
                }

                Sale sale = mapper.Map<Sale>(saleDto);

                validSales.Add(sale);
            }

            context.Sales.AddRange(validSales);
            context.SaveChanges();
        }

        // Problem 06. Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ExportCarWithDistanceDto[] cars = context.Cars
                                              .Where(c => c.TraveledDistance > 2000000)
                                              .OrderBy(c => c.Make)
                                              .ThenBy(c => c.Model)
                                              .Select(c => new ExportCarWithDistanceDto()
                                              {
                                                  Make = c.Make,
                                                  Model = c.Model,
                                                  TraveledDistance = c.TraveledDistance
                                              })
                                              .Take(10)
                                              .ToArray();

            return Serializer("cars", cars, "cars.xml");
        }

        // Problem 07. Export Cars From Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();

            var cars = context.Cars
                              .Where(c => c.Make == "BMW")
                              .OrderBy(c => c.Model)
                              .ThenByDescending(c => c.TraveledDistance)
                              //.ProjectTo<ExportCarFromMakeBmwDto>(mapper.ConfigurationProvider) with AutoMapper
                              .Select(c => new ExportCarFromMakeBmwDto()
                              {
                                  Id = c.Id,
                                  Model = c.Model,
                                  TraveledDistance = c.TraveledDistance
                              })
                              .ToArray();

            return Serializer("cars", cars, "carsBmw.xml");
        }

        // Problem 08. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                               .Where(s => s.IsImporter == false)
                               .Select(s => new ExportLocalSupplierDto()
                               {
                                   Id = s.Id,
                                   Name = s.Name,
                                   PartsCount = s.Parts.Count
                               })
                               .ToArray();

            return Serializer("suppliers", suppliers, "localSuppliers.xml");
        }

        // Problem 09. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                              .Select(c => new ExportCarsWithListOfPartsDto()
                              {
                                  Make = c.Make,
                                  Model = c.Model,
                                  TraveledDistance = c.TraveledDistance,
                                  Parts = c.PartsCars.Select(pc => new ExportPartDto()
                                  {
                                      Name = pc.Part.Name,
                                      Price = pc.Part.Price
                                  })
                                  .OrderByDescending(p => p.Price)
                                  .ToArray()
                              })
                              .OrderByDescending(c => c.TraveledDistance)
                              .Take(5)
                              .ToArray();

            return Serializer("cars", cars, "carsWithParts.xml");
        }

        // Problem 10. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                                   .Where(c => c.Sales.Count > 0)
                                   .AsEnumerable()
                                   .Select(c => new ExportTotalSalesByCustomerDto()
                                   {
                                       FullName = c.Name,
                                       BoughtCars = c.Sales.Count,
                                       SpentMoney = c.Sales.Sum(s => s.Car.PartsCars.Sum(pc => pc.Part.Price))
                                   })
                                   .OrderByDescending(c => c.SpentMoney)
                                   .ToArray();

            return Serializer("customers", customers, "customersSales.xml");
        }

        // Problem 11. Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                               .Select(s => new ExportSalesWithAppliedDiscountDto()
                               {
                                   Car = new ExportCarDto()
                                   {
                                       Make = s.Car.Make,
                                       Model = s.Car.Model,
                                       TraveledDistance = s.Car.TraveledDistance
                                   },
                                   Discount = s.Discount,
                                   CustomerName = s.Customer.Name,
                                   Price = $"{s.Car.PartsCars.Sum(pc => pc.Part.Price):F2}",
                                   PriceWithDiscount = $"{(s.Car.PartsCars.Sum(pc => pc.Part.Price) - (s.Car.PartsCars.Sum(pc => pc.Part.Price) * s.Discount / 100)):F2}"

                               })
                               .ToArray();

            return Serializer("sales", sales, "salesWithDiscount.xml");
        }

        private static string Serializer<T>(string root, T elements, string fileName)
        {
            XmlRootAttribute rootAttribute = new XmlRootAttribute(root);
            XmlSerializer serializer = new XmlSerializer(typeof(T), rootAttribute);

            XmlSerializerNamespaces emptyNamespaces = new XmlSerializerNamespaces();
            emptyNamespaces.Add(string.Empty, string.Empty);

            using StreamWriter writer = new StreamWriter(fileName);

            serializer.Serialize(writer, elements, emptyNamespaces);

            writer.Close();

            string xml = File.ReadAllText(fileName);

            return xml;

        }
        private static T Deserialize<T>(string root, string inputXml)
        {
            XmlRootAttribute rootAttribute = new XmlRootAttribute(root);
            XmlSerializer serializer = new XmlSerializer(typeof(T), rootAttribute);

            using StringReader reader = new StringReader(inputXml);

            T deserializedDtos = (T)serializer.Deserialize(reader);

            return deserializedDtos;
        }
        private static IMapper CreateMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        private static void CreateAndPopulateDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            string partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            string carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            string customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            string salesXml = File.ReadAllText("../../../Datasets/sales.xml");

            ImportSuppliers(context, suppliersXml);
            ImportParts(context, partsXml);
            ImportCars(context, carsXml);
            ImportCustomers(context, customersXml);
            ImportSales(context, salesXml);
        }
    }
}
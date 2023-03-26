using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //Recreate the DB and fill it up.
            ImportAllData(context);

            Console.WriteLine(GetSalesWithAppliedDiscount(context));

        }

        // Problem 01. Import Suppliers
        public static void ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportSupplierDto[] suppliers = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);

            Supplier[] validSuppliers = mapper.Map<Supplier[]>(suppliers);

            context.AddRange(validSuppliers);
            context.SaveChanges();
        }

        // Problem 02. Import Parts
        public static void ImportParts(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportPartDto[] parts = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);

            ICollection<Part> validParts = new List<Part>();

            foreach (var partDto in parts)
            {
                Part part = mapper.Map<Part>(partDto);

                Supplier supplier = context.Suppliers.Find(part.SupplierId);

                if (supplier == null)
                {
                    continue;
                }

                validParts.Add(part);
            }

            context.AddRange(validParts);
            context.SaveChanges();
        }

        // Problem 03. Import Cars
        public static void ImportCars(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            var cars = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);


            foreach (var carDto in cars)
            {
                Car car = mapper.Map<Car>(carDto);

                context.Cars.Add(car);

                //foreach (var partId in carDto.PartsId)
                //{
                //    PartCar partCar = new PartCar()
                //    {
                //        CarId = 1,
                //        PartId = partId
                //    };

                //    if (car.PartsCars.FirstOrDefault(p => p.PartId == partId) == null)
                //    {
                //        context.PartsCars.Add(partCar);
                //    }
                //}
            }

            context.SaveChanges();
        }

        // Problem 04. Import Customers
        public static void ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.AddRange(customers);
            context.SaveChanges();
        }

        // Problem 05. Import Sales
        public static void ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            Sale[] validSales = mapper.Map<Sale[]>(sales);

            context.AddRange(validSales);
            context.SaveChanges();
        }

        // Problem 06. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    c.IsYoungDriver
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            });
        }

        // Problem 07. Export Cars from Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
        }

        // Problem 08. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        // Problem 09. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new ExportCarDto
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TraveledDistance = c.TraveledDistance
                    },
                    parts = c.PartsCars
                    .Select(p => new ExportPartDto
                    {
                        Name = p.Part.Name,
                        Price = $"{p.Part.Price:F2}"
                    })
                    .ToList()
                })
                .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        // Problem 10. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new ExportCustomerWithCarDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartsCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        // Problem 11. Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = $"{s.Discount:F2}",
                    price = $"{s.Car.PartsCars.Sum(p => p.Part.Price):F2}",
                    priceWithDiscount = $"{(s.Car.PartsCars.Sum(p => p.Part.Price) - s.Car.PartsCars.Sum(p => p.Part.Price) * s.Discount / 100):F2}"
                })
                .ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }

        private static IMapper CreateMapper()
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            return mapper;
        }

        private static void ImportAllData(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string importSuppliers = File.ReadAllText(@"../../../Datasets/suppliers.json");
            string importParts = File.ReadAllText(@"../../../Datasets/parts.json");
            string importCars = File.ReadAllText(@"../../../Datasets/cars.json");
            string importCustomers = File.ReadAllText(@"../../../Datasets/customers.json");
            string importSales = File.ReadAllText(@"../../../Datasets/sales.json");


            ImportSuppliers(context, importSuppliers);
            ImportParts(context, importParts);
            ImportCars(context, importCars);
            ImportCustomers(context, importCustomers);
            ImportSales(context, importSales);
        }
    }
}
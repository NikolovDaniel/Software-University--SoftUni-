using System.Xml;
using System.Xml.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string usersXml = File.ReadAllText(@"/Users/danielnikolov/Desktop/users.xml");
            string productsXml = File.ReadAllText(@"/Users/danielnikolov/Desktop/products.xml");
            string categoriesXml = File.ReadAllText(@"/Users/danielnikolov/Desktop/categories.xml");
            string categoriesProductsXml = File.ReadAllText(@"/Users/danielnikolov/Desktop/categories-products.xml");

            Console.WriteLine(ImportUsers(context, usersXml));
            Console.WriteLine(ImportProducts(context, productsXml));
            Console.WriteLine(ImportCategories(context, categoriesXml));
            Console.WriteLine(ImportCategoryProducts(context, categoriesProductsXml));
            Console.WriteLine(GetUsersWithProducts(context));
        }

        // Problem 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var usersDto = Deserializer<ImportUserDto[]>("Users", inputXml);

            var validUsers = usersDto
                                    .Select(u => new User()
                                    {
                                        FirstName = u.FirstName,
                                        LastName = u.LastName,
                                        Age = u.Age
                                    })
                                    .ToArray();

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Length}";
        }

        // Problem 02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var productsDto = Deserializer<ImportProductDto[]>("Products", inputXml);

            List<Product> validProducts = new List<Product>();

            foreach (var productDto in productsDto)
            {

                Product product = new Product()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    SellerId = productDto.SellerId,
                    BuyerId = productDto.BuyerId
                };

                validProducts.Add(product);
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        // Problem 03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var categoriesDto = Deserializer<ImportCategoryDto[]>("Categories", inputXml);

            List<Category> validCategories = new List<Category>();

            foreach (var categoryDto in categoriesDto)
            {
                if (categoryDto.Name == null)
                {
                    continue;
                }

                Category category = new Category()
                {
                    Name = categoryDto.Name
                };

                validCategories.Add(category);
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        // Problem 04. Import Categories And Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var categoryProductsDto = Deserializer<ImportCategoryProductsDto[]>("CategoryProducts", inputXml);

            List<CategoryProduct> validCategoryProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoryProductsDto)
            {
                if (!context.Categories.Any(c => c.Id == categoryProductDto.CategoryId)
                    || !context.Products.Any(p => p.Id == categoryProductDto.ProductId))
                {
                    continue;
                }

                CategoryProduct categoryProduct = new CategoryProduct()
                {
                    CategoryId = categoryProductDto.CategoryId,
                    ProductId = categoryProductDto.ProductId
                };

                validCategoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(validCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoryProducts.Count}";
        }

        // Problem 05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                                  .Where(p => p.Price >= 500 && p.Price <= 1000)
                                  .OrderBy(p => p.Price)
                                  .Select(p => new ExportProductInRangeDto()
                                  {
                                      Name = p.Name,
                                      Price = p.Price,
                                      Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                                  })
                                  .Take(10)
                                  .ToArray();

            string path = "/Users/danielnikolov/Desktop/productsDto.xml";

            return Serializer(products, "Products", path);
        }

        // Problem 06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var userWithSoldProducts = context.Users
                                              .Where(u => u.ProductsSold.Count > 0)
                                              .OrderBy(u => u.LastName)
                                              .ThenBy(u => u.FirstName)
                                              .Select(u => new ExportUserDto()
                                              {
                                                  FirstName = u.FirstName,
                                                  LastName = u.LastName,
                                                  SoldProducts = u.ProductsSold
                                                  .Select(sp => new ExportSoldProductDto()
                                                  {
                                                      Name = sp.Name,
                                                      Price = sp.Price
                                                  })
                                                  .ToArray()
                                              })
                                              .Take(5)
                                              .ToArray();

            string path = "/Users/danielnikolov/Desktop/usersWithSoldProducts.xml";

            return Serializer(userWithSoldProducts, "Users", path);
        }

        // Problem 07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                                    .AsEnumerable()
                                    .Select(c => new ExportCategoryDto()
                                    {
                                        Name = c.Name,
                                        Count = c.CategoryProducts.Count,
                                        AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                                        TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                                    })
                                    .OrderByDescending(c => c.Count)
                                    .ThenBy(c => c.TotalRevenue)
                                    .ToArray();

            string path = "/Users/danielnikolov/Desktop/categoriesByProductsCount.xml";

            return Serializer(categories, "Categories", path);
        }

        // Problem 08. Export Users And Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                               .Where(u => u.ProductsSold.Count > 0)
                               .Select(u => new ExportUserWithSoldProductsDto()
                               {
                                   FirstName = u.FirstName,
                                   LastName = u.LastName,
                                   Age = (int)u.Age,
                                   SoldProducts = new ExportSoldProductsCountAndProducts()
                                   {
                                       Count = u.ProductsSold.Count,
                                       Products = u.ProductsSold
                                                   .Select(ps => new ExportSoldProductDto()
                                                   {
                                                       Name = ps.Name,
                                                       Price = ps.Price
                                                   })
                                                   .OrderByDescending(ps => ps.Price)
                                                   .ToArray()
                                   }
                               })
                               .OrderByDescending(u => u.SoldProducts.Count)
                               .ToArray();

            ExportUserCountAndUsersDto obj = new ExportUserCountAndUsersDto()
            {
                Count = users.Count(),
                Users = users.Take(10).ToArray()
            };

            string path = "/Users/danielnikolov/Desktop/usersAndProducts.xml";

            return Serializer(obj, "Users", path);
        }

        private static T Deserializer<T>(string rootAtt, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootAtt);

            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            using StringReader reader = new StringReader(inputXml);

            var deserializedDtos = (T)serializer.Deserialize(reader);

            return deserializedDtos;
        }

        private static string Serializer<T>(T elements, string rootAtt, string path)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootAtt);

            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StreamWriter writer = new StreamWriter(path);

            serializer.Serialize(writer, elements, namespaces);

            writer.Close();

            string result = File.ReadAllText(path);

            return result;
        }
    }
}
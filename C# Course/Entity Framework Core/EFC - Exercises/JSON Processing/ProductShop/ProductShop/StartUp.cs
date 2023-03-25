using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            string inputJson = File.ReadAllText("/Users/danielnikolov/Desktop/08/ProductShop/Datasets/products.json");

            string result = ImportProducts(context, inputJson);

            Console.WriteLine(result);
        }

        // Problem 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportUserDto[] users = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> validUsers = new HashSet<User>();

            foreach (var userDto in users)
            {
                User user = mapper.Map<User>(userDto);

                validUsers.Add(user);
            }

            context.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        // Problem 02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportProductDto[] products = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

            Product[] validProducts = mapper.Map<Product[]>(products);

            context.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Length}";
        }

        // Problem 03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoryDto[] categories = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

            ICollection<Category> validCategories = new HashSet<Category>();

            foreach (var categoryDto in categories)
            {
                Category category = mapper.Map<Category>(categoryDto);

                if (category.Name == null)
                {
                    continue;
                }

                validCategories.Add(category);
            }

            context.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        private static IMapper CreateMapper()
        {
            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            return mapper;
        }
    }
}
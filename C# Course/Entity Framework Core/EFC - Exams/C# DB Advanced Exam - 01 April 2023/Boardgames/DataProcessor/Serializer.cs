namespace Boardgames.DataProcessor
{
    using System.Xml.Serialization;
    using Boardgames.Data;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ExportDto;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            XmlRootAttribute root = new XmlRootAttribute("Creators");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCreatorDto[]), root);

            var creatorsDtos = context.Creators
                                      .AsEnumerable()
                                      .Where(c => c.Boardgames.Count > 0)
                                      .Select(c => new ExportCreatorDto()
                                      {
                                          Count = c.Boardgames.Count,
                                          CreatorName = $"{c.FirstName} {c.LastName}",
                                          Boardgames = c.Boardgames.Select(b => new ExportBoardgame()
                                          {
                                              BoardgameName = b.Name,
                                              YearPublished = b.YearPublished
                                          })
                                          .OrderBy(b => b.BoardgameName)
                                          .ToArray()
                                      })
                                      .OrderByDescending(b => b.Count)
                                      .ThenBy(b => b.CreatorName)
                                      .ToArray();

            using StreamWriter writer = new StreamWriter(@"Users\danielnikolov\Desktop\file.xml");

            serializer.Serialize(writer, creatorsDtos, namespaces);

            writer.Close();

            return File.ReadAllText(@"Users\danielnikolov\Desktop\file.xml");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellersWithBoardgames = context.Sellers
                                       .Where(s => s.BoardgamesSellers.Count > 0
                                                && s.BoardgamesSellers.Where(b => b.Boardgame.YearPublished >= year && b.Boardgame.Rating <= rating).Count() > 0)
                                       .Select(s => new
                                       {
                                           Name = s.Name,
                                           Website = s.Website,
                                           Boardgames = s.BoardgamesSellers
                                           .Where(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating)
                                           .Select(bs => new
                                           {
                                               Name = bs.Boardgame.Name,
                                               Rating = bs.Boardgame.Rating,
                                               Mechanics = bs.Boardgame.Mechanics,
                                               Category = ((CategoryType)(bs.Boardgame.CategoryType)).ToString()
                                           })
                                           .OrderByDescending(b => b.Rating)
                                           .ThenBy(b => b.Name)
                                           .ToArray()
                                       })
                                       .OrderByDescending(s => s.Boardgames.Count())
                                       .ThenBy(s => s.Name)
                                       .Take(5)
                                       .ToArray();

            return JsonConvert.SerializeObject(sellersWithBoardgames, Formatting.Indented);
        }
    }
}
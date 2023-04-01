namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml.Serialization;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Creators");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCreatorDto[]), root);

            using StringReader reader = new StringReader(xmlString);

            var creatorsDtos = (ImportCreatorDto[])serializer.Deserialize(reader);

            reader.Close();

            List<Creator> validCreators = new List<Creator>();

            StringBuilder sb = new StringBuilder();

            foreach (var creatorDto in creatorsDtos)
            {
                try
                {
                    if (creatorDto.FirstName.Length < 2
                        || creatorDto.FirstName.Length > 7
                        || creatorDto.LastName.Length < 2
                        || creatorDto.LastName.Length > 7
                        || string.IsNullOrEmpty(creatorDto.FirstName)
                        || string.IsNullOrEmpty(creatorDto.LastName))
                    {
                        throw new Exception();
                    }

                    List<Boardgame> validBoardgames = new List<Boardgame>();

                    foreach (var boardgameDto in creatorDto.Boardgames)
                    {
                        if (boardgameDto.Name.Length < 10
                            || boardgameDto.Name.Length > 20
                            || boardgameDto.Rating < 1.00
                            || boardgameDto.Rating > 10.00
                            || boardgameDto.YearPublished < 2018
                            || boardgameDto.YearPublished > 2023
                            || boardgameDto.CategoryType < 0
                            || boardgameDto.CategoryType > 4
                            || string.IsNullOrEmpty(boardgameDto.Mechanics))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        Boardgame boardgame = new Boardgame()
                        {
                            Name = boardgameDto.Name,
                            Rating = boardgameDto.Rating,
                            YearPublished = boardgameDto.YearPublished,
                            CategoryType = (CategoryType)boardgameDto.CategoryType,
                            Mechanics = boardgameDto.Mechanics
                        };

                        validBoardgames.Add(boardgame);
                    }

                    Creator creator = new Creator()
                    {
                        FirstName = creatorDto.FirstName,
                        LastName = creatorDto.LastName,
                        Boardgames = validBoardgames
                    };

                    validCreators.Add(creator);
                    sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count));
                }
                catch (Exception xs)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
            }

            context.Creators.AddRange(validCreators);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            var sellersDtos = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Seller> validSellers = new List<Seller>();

            foreach (var sellerDto in sellersDtos)
            {
                try
                {
                    string pattern = @"^([www.]+)([a-zA-Z0-9-]+)\.[com]+";
                    Regex regex = new Regex(pattern);
                    Match match = regex.Match(sellerDto.Website);

                    if (sellerDto.Name.Length < 5
                        || sellerDto.Name.Length > 20
                        || string.IsNullOrEmpty(sellerDto.Name)
                        || sellerDto.Address.Length < 5
                        || sellerDto.Address.Length > 30
                        || string.IsNullOrEmpty(sellerDto.Address)
                        || string.IsNullOrEmpty(sellerDto.Country)
                        || !match.Success
                        || sellerDto.Website.Contains(" "))
                    {
                        throw new Exception();
                    }

                    Seller seller = new Seller()
                    {
                        Name = sellerDto.Name,
                        Address = sellerDto.Address,
                        Country = sellerDto.Country,
                        Website = sellerDto.Website
                    };

                    foreach (var boardgameId in sellerDto.BoardgamesIds.DistinctBy(id => id))
                    {
                        if (!context.Boardgames.Any(b => b.Id == boardgameId))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        BoardgameSeller boardgameSeller = new BoardgameSeller()
                        {
                            BoardgameId = boardgameId
                        };

                        seller.BoardgamesSellers.Add(boardgameSeller);
                    }

                    validSellers.Add(seller);
                    sb.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
                }
                catch (Exception ex)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
            }

            context.Sellers.AddRange(validSellers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}

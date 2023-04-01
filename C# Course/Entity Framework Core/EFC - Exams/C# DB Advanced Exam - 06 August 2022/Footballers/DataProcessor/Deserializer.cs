namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Coaches");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCoachDto[]), root);

            using StringReader reader = new StringReader(xmlString);

            var coachesDtos = (ImportCoachDto[])serializer.Deserialize(reader);

            reader.Close();

            List<Coach> validCoaches = new List<Coach>();

            StringBuilder sb = new StringBuilder();

            foreach (var coachDto in coachesDtos)
            {
                try
                {
                    if (coachDto.Name.Length < 2
                        || coachDto.Name.Length > 40
                        || string.IsNullOrEmpty(coachDto.Name)
                        || string.IsNullOrEmpty(coachDto.Nationality))
                    {
                        throw new Exception();
                    }

                    List<Footballer> validFootballers = new List<Footballer>();

                    foreach (var footballerDto in coachDto.Footballers)
                    {
                        DateTime startDate = new DateTime();
                        DateTime endDate = new DateTime();

                        bool csd = DateTime.TryParseExact(footballerDto.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
                        bool ced = DateTime.TryParseExact(footballerDto.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);

                        if (footballerDto.Name.Length < 2
                            || footballerDto.Name.Length > 40
                            || !csd
                            || !ced
                            || startDate > endDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        Footballer footballer = new Footballer()
                        {
                            Name = footballerDto.Name,
                            ContractStartDate = startDate,
                            ContractEndDate = endDate,
                            BestSkillType = (BestSkillType)footballerDto.BestSkillType,
                            PositionType = (PositionType)footballerDto.PositionType
                        };

                        validFootballers.Add(footballer);
                    }

                    if (string.IsNullOrEmpty(coachDto.Name) || string.IsNullOrEmpty(coachDto.Nationality))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Coach coach = new Coach()
                    {
                        Name = coachDto.Name,
                        Nationality = coachDto.Nationality,
                        Footballers = validFootballers
                    };

                    validCoaches.Add(coach);

                    sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
                }
                catch (Exception xs)
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Coaches.AddRange(validCoaches);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var teamsDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Team> validTeams = new List<Team>();

            foreach (var teamDto in teamsDtos)
            {
                try
                {
                    string pattern = @"^[a-zA-Z0-9\s\.\-]+$";

                    Regex regex = new Regex(pattern);

                    Match match = regex.Match(teamDto.Name);

                    if (teamDto.Name.Length < 3
                        || teamDto.Name.Length > 40
                        || string.IsNullOrEmpty(teamDto.Name)
                        || teamDto.Nationality.Length < 2
                        || teamDto.Nationality.Length > 40
                        || string.IsNullOrEmpty(teamDto.Nationality)
                        || teamDto.Trophies <= 0
                        || !match.Success)
                    {
                        throw new Exception();
                    }

                    Team team = new Team()
                    {
                        Name = teamDto.Name,
                        Nationality = teamDto.Nationality,
                        Trophies = teamDto.Trophies
                    };

                    foreach (var footballerId in teamDto.FootballersIds.DistinctBy(f => f))
                    {
                        if (!context.Footballers.Any(f => f.Id == footballerId))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        TeamFootballer teamFootballer = new TeamFootballer()
                        {
                            FootballerId = footballerId
                        };

                        team.TeamsFootballers.Add(teamFootballer);
                    }

                    validTeams.Add(team);

                    sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
                }
                catch (Exception ex)
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Teams.AddRange(validTeams);
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

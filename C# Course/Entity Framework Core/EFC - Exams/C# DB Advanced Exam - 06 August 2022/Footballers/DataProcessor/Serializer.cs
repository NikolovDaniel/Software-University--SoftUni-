namespace Footballers.DataProcessor
{
    using System.Globalization;
    using Data;
    using Footballers.Data.Models;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            return string.Join(' ', context.Footballers.ToList());
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                               .AsEnumerable()
                               .Where(t => t.TeamsFootballers.Where(tf => DateTime.Compare(tf.Footballer.ContractStartDate, date) >= 0).Count() > 0)
                               .Select(t => new
                               {
                                   Name = t.Name,
                                   Footballers = t.TeamsFootballers
                                                  .Where(tf => DateTime.Compare(tf.Footballer.ContractStartDate, date) >= 0)
                                                  .Select(tf => new
                                                  {
                                                      FootballerName = tf.Footballer.Name,
                                                      ContractStartDate = tf.Footballer.ContractStartDate.ToString("MM/dd/yyyy"),
                                                      ContractEndDate = tf.Footballer.ContractEndDate.ToString("MM/dd/yyyy"),
                                                      BestSkillType = ((BestSkillType)tf.Footballer.BestSkillType).ToString(),
                                                      PositionType = ((PositionType)tf.Footballer.PositionType).ToString()
                                                  })
                                                  .OrderByDescending(f => f.ContractEndDate)
                                                  .ThenBy(f => f.FootballerName)
                                                  .ToArray()
                               })
                               .OrderByDescending(t => t.Footballers.Count())
                               .ThenBy(t => t.Name)
                               .Take(5)
                               .ToArray();

            return JsonConvert.SerializeObject(teams, Formatting.Indented);
        }
    }
}

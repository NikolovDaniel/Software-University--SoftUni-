using Newtonsoft.Json;

namespace Trucks.DataProcessor.ExportDto
{
    public class ExportClientWithMostTrucksDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [JsonProperty("Trucks")]
        public IEnumerable<ExportTruckDto> Trucks { get; set; } = null!;
    }
}

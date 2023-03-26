namespace CarDealer.DTOs.Export
{
    public class ExportCarDto
    {
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public long TraveledDistance { get; set; }
    }
}

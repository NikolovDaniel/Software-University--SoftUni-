using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Despatcher")]
    public class ExportDespatcherDto
    {
        [XmlAttribute("TrucksCount")]
        public int Count { get; set; }

        [XmlElement("DespatcherName")]
        public string DespatcherName { get; set; } = null!;

        [XmlArray("Trucks")]
        public ExportDespatcherTruck[] Trucks { get; set; } = null!;
    }
}

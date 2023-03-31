using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Sale")]
    public class ImportSaleDto
    {
        [XmlElement("sale")]
        public string Sale { get; set; } = null!;

        [XmlElement("carId")]
        public int CarId { get; set; }

        [XmlElement("customerId")]
        public int CustomerId { get; set; }
        [XmlElement("discount")]
        public double Discount { get; set; }
    }
}

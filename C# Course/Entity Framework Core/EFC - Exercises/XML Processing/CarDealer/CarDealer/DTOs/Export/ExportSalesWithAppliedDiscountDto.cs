using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("sale")]
    public class ExportSalesWithAppliedDiscountDto
    {
        [XmlElement("car")]
        public ExportCarDto Car { get; set; } = null!;

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; } = null!;

        [XmlElement("price")]
        public string Price { get; set; } = null!;

        [XmlElement("price-with-discount")]
        public string PriceWithDiscount { get; set; } = null!;
    }
}

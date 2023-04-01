using System;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("SoldProducts")]
    public class ExportSoldProductsCountAndProducts
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ExportSoldProductDto[] Products { get; set; } = null!;
    }
}


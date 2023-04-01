using System;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    public class ExportUserCountAndUsersDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public ExportUserWithSoldProductsDto[] Users { get; set; } = null!;
    }
}


namespace ProductShop.Data
{
    public static class Configuration
    {
        public const string ConnectionString =
            //Server=KOlombus;Database=KnightsAndDragons;TrustServerCertificate=True;Trusted_Connection=True;Integrated Security=true
            //Server=localhost;Database=ProductShop;User Id=SA;Password=MyPass@word;Integrated Security=false;TrustServerCertificate=True
            @"Server=KOlombus;Database=ProductShop;TrustServerCertificate=True;Trusted_Connection=True;Integrated Security=true";
    }
}

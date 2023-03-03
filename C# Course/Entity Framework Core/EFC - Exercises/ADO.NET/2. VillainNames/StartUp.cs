using System.Text;
using Microsoft.Data.SqlClient;

SqlConnection connection = new SqlConnection("Server=localhost;Database=MinionsDB;User Id=SA;Password=MyPass@word;Integrated Security=false;TrustServerCertificate=True");
using (connection)
{
    SqlCommand sqlCommand =
        new SqlCommand("SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount" +
        "\nFROM Villains AS v" +
        "\nJOIN MinionsVillains AS mv ON v.Id = mv.VillainId" +
        "\nGROUP BY v.Id, v.Name" +
        "\nHAVING COUNT(mv.VillainId) > 3" +
        "\nORDER BY COUNT(mv.VillainId)", connection);

    connection.Open();

    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

    while (reader.Read())
    {
        Console.WriteLine($"{reader.GetString(0)} - {reader.GetInt32(1)}");
    }

    connection.Close();
}





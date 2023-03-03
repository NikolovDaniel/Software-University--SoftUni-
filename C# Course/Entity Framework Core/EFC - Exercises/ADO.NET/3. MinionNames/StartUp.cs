using System.Text;
using Microsoft.Data.SqlClient;

SqlConnection connection = new SqlConnection("Server=localhost;Database=MinionsDB;User Id=SA;Password=MyPass@word;Integrated Security=false;TrustServerCertificate=True");

using (connection)
{
    StringBuilder sb = new StringBuilder();

    SqlCommand getVillainName =
        new SqlCommand("SELECT Name FROM Villains WHERE Id = @Id", connection);

    SqlCommand getMinionNameAndAge =
            new SqlCommand("SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum," +
            "\nm.Name," +
            "\nm.Age" +
            "\nFROM MinionsVillains AS mv" +
            "\nJOIN Minions As m ON mv.MinionId = m.Id" +
            "\nWHERE mv.VillainId = @Id" +
            "\nORDER BY m.Name", connection);

    int id = int.Parse(Console.ReadLine());

    getMinionNameAndAge.Parameters.AddWithValue("@Id", id);
    getVillainName.Parameters.AddWithValue("@Id", id);

    connection.Open();

    SqlDataReader villainData = await getVillainName.ExecuteReaderAsync();

    if (villainData.HasRows)
    {
        villainData.Read();
        sb.AppendLine($"Villain: {villainData.GetString(0)}");
        villainData.Close();

        SqlDataReader minionsData = await getMinionNameAndAge.ExecuteReaderAsync();

        if (minionsData.HasRows)
        {
            while (minionsData.Read())
            {
                sb.AppendLine($"{minionsData.GetInt64(0)}. {minionsData.GetString(1)} {minionsData.GetInt32(2)}");
            }
        }
        else
        {
            Console.WriteLine("(no minions)");
        }

        Console.WriteLine(sb.ToString());

    }
    else
    {
        Console.WriteLine($"No villain with ID {id} exists in the database.");
    }


    connection.Close();
}

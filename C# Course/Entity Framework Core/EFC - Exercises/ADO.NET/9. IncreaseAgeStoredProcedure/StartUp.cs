using Microsoft.Data.SqlClient;

SqlConnection connection = new SqlConnection("Server=localhost;Database=MinionsDB;User Id=SA;Password=MyPass@word;Integrated Security=false;TrustServerCertificate=True");

using (connection)
{
    connection.Open();

    int id = int.Parse(Console.ReadLine());

    SqlCommand execProcedure = new SqlCommand("EXEC usp_GetOlder @id", connection);

    execProcedure.Parameters.AddWithValue("@id", id);

    await execProcedure.ExecuteNonQueryAsync();

    SqlCommand getMinion = new SqlCommand("SELECT Name, Age FROM Minions WHERE Id = @Id\n", connection);

    getMinion.Parameters.AddWithValue("@Id", id);

    SqlDataReader reader = await getMinion.ExecuteReaderAsync();

    if (reader.HasRows)
    {
        while (reader.Read())
        {
            Console.WriteLine($"{reader.GetString(0)} - {reader.GetInt32(1)} years old");
        }
    }
}


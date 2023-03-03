using Microsoft.Data.SqlClient;
class Program
{
    static async Task Main(string[] args)
    {
        SqlConnection connection = new SqlConnection("Server=localhost;Database=MinionsDB;User Id=SA;Password=MyPass@word;Integrated Security=false;TrustServerCertificate=True");

        using (connection)
        {
            connection.Open();

            SqlCommand updateMinion = new SqlCommand("UPDATE Minions\n   SET Name = CONCAT(LOWER(SUBSTRING(Name, 1, 1)), SUBSTRING(Name, 2, LEN(Name) - 1)), Age += 1\n WHERE Id = @Id", connection);


            int[] ids = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < ids.Length; i++)
            {
                updateMinion.Parameters.AddWithValue("@Id", ids[i]);
                await updateMinion.ExecuteNonQueryAsync();
                updateMinion.Parameters.Clear();
            }

            SqlCommand getMinions = new SqlCommand("SELECT Name, Age FROM Minions", connection);

            SqlDataReader reader = await getMinions.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while(reader.Read())
                {
                    Console.WriteLine($"{reader.GetString(0)} {reader.GetInt32(1)}");
                }
            }

        }
    }
}


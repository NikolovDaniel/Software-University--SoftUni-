using Microsoft.Data.SqlClient;

SqlConnection connection = new SqlConnection("Server=localhost;Database=MinionsDB;User Id=SA;Password=MyPass@word;Integrated Security=false;TrustServerCertificate=True");

using (connection)
{
    connection.Open();


    SqlCommand getMinions = new SqlCommand("SELECT Name FROM Minions", connection);

    SqlDataReader reader = await getMinions.ExecuteReaderAsync();

    if (reader.HasRows)
    {
        List<string> names = new List<string>();

        while (reader.Read())
        {
            names.Add(reader.GetString(0));
        }

        for (int i = 0; i < names.Count / 2; i++)
        {
                Console.WriteLine(names[i]);
            Console.WriteLine(names[(names.Count - i) - 1]);
        }
    }

    connection.Close();
}


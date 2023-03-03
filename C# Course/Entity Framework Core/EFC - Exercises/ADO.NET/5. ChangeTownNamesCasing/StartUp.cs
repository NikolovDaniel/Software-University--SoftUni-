using Microsoft.Data.SqlClient;

SqlConnection connection = new SqlConnection("Server=localhost;Database=MinionsDB;User Id=SA;Password=MyPass@word;Integrated Security=false;TrustServerCertificate=True");

using (connection)
{
    connection.Open();

    SqlCommand updateTownNames = new SqlCommand("UPDATE Towns\n   SET Name = UPPER(Name)\n WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)", connection);

    string countryName = Console.ReadLine();

    updateTownNames.Parameters.AddWithValue("@countryName", countryName);

    int affectedRows = await updateTownNames.ExecuteNonQueryAsync();

    if (affectedRows > 0)
    {
        Console.WriteLine($"{affectedRows} town names were affected.");

        SqlCommand getTowns = new SqlCommand(" SELECT t.Name \n   FROM Towns as t\n   JOIN Countries AS c ON c.Id = t.CountryCode\n  WHERE c.Name = @countryName", connection);

        getTowns.Parameters.AddWithValue("@countryName", countryName);

        SqlDataReader reader = await getTowns.ExecuteReaderAsync();

        List<string> changedTownNames = new List<string>();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                changedTownNames.Add(reader.GetString(0));
            }
        }

        Console.WriteLine($"[{string.Join(", ", changedTownNames)}]");
    }
    else
    {
        Console.WriteLine("No town names were affected.");
    }

    connection.Close();
}
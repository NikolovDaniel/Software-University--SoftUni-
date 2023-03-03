using Microsoft.Data.SqlClient;
using System.Text;


SqlConnection connection = new SqlConnection("Server=localhost;Database=MinionsDB;User Id=SA;Password=MyPass@word;Integrated Security=false;TrustServerCertificate=True");

using (connection)
{
    connection.Open();

    int villainId = int.Parse(Console.ReadLine());

    StringBuilder sb = new StringBuilder();

    SqlCommand getVillain = new SqlCommand("SELECT Name FROM Villains WHERE Id = @villainId", connection);

    getVillain.Parameters.AddWithValue("@villainId", villainId);

    string? villain = (string?) await getVillain.ExecuteScalarAsync();

    if (villain != null)
    {
        sb.AppendLine($"{villain} was deleted.");

        SqlCommand getMinions = new SqlCommand("DELETE FROM MinionsVillains WHERE VillainId = @villainId", connection);

        getMinions.Parameters.AddWithValue("@villainId", villainId);

        int affectedRows = await getMinions.ExecuteNonQueryAsync();

        sb.AppendLine($"{affectedRows} minions were released.");

        SqlCommand deleteVillain = new SqlCommand("DELETE FROM Villains WHERE Id = @villainId", connection);

        deleteVillain.Parameters.AddWithValue("@villainId", villainId);

        await deleteVillain.ExecuteNonQueryAsync();
    }
    else
    {
        sb.AppendLine("No such villain was found.");
    }

    Console.WriteLine(sb.ToString());
    connection.Close();
}



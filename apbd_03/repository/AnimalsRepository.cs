using System.Data.SqlClient;

namespace apbd_03;

public class AnimalsRepository : IAnimalsRepository
{
    private IConfiguration _configuration;
    
    public AnimalsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        using var con = new SqlConnection(provideConnectionString());
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = $"SELECT * FROM Animal ORDER BY [{orderBy}] ASC";
        
        var dr = cmd.ExecuteReader();
        var animals = new List<Animal>();
        while (dr.Read())
        {
            var animal = new Animal
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString()
            };
            animals.Add(animal);
        }
        
        return animals;
    }

    public int CreateAnimal(AnimalModel animal)
    {
        using var con = new SqlConnection(provideConnectionString());
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO Animal VALUES(@name, @description, @category, @area); SELECT CAST(scope_identity() AS int)";
        cmd.Parameters.AddWithValue("@name", animal.Name);
        cmd.Parameters.AddWithValue("@description", animal.Description);
        cmd.Parameters.AddWithValue("@category", animal.Category);
        cmd.Parameters.AddWithValue("@area", animal.Area);
        var id = cmd.ExecuteScalar();
        return (int) id;
    }

    public int UpdateAnimal(int idAnimal, AnimalModel animalModel)
    {
        using var con = new SqlConnection(provideConnectionString());
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE Animal SET Name=@Name, Description=@Description, Category=@Category, Area=@Area WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);
        cmd.Parameters.AddWithValue("@Name", animalModel.Name);
        cmd.Parameters.AddWithValue("@Description", animalModel.Description);
        cmd.Parameters.AddWithValue("@Category", animalModel.Category);
        cmd.Parameters.AddWithValue("@Area", animalModel.Area);
        
        var updatedObjects = cmd.ExecuteNonQuery();
        return updatedObjects;
    }

    public int DeleteAnimal(int idAnimal)
    {
        using var con = new SqlConnection(provideConnectionString());
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Animal WHERE IdAnimal=@IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);

        var updatedObjects = cmd.ExecuteNonQuery();
        return updatedObjects;
    }

    private string provideConnectionString()
    {
        var connectionString = new SqlConnectionStringBuilder(_configuration["ConnectionStrings:localhostMSSQLServer"]);
        connectionString.UserID = _configuration["DbUserId"];
        connectionString.Password = _configuration["DbPassword"];
        return connectionString.ConnectionString;
    }
}
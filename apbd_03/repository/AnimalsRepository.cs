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
        var connectionString = new SqlConnectionStringBuilder(_configuration["ConnectionStrings:DefaultConnection"]);
        connectionString.UserID = _configuration["DbUserId"];
        connectionString.Password = _configuration["DbPassword"];
        using var con = new SqlConnection(connectionString.ConnectionString);
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
}
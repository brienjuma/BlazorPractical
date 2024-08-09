using System.Data;
using MySql.Data.MySqlClient;

namespace BlazorPractical.Services.DbContext;

public class DatabaseContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DatabaseContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection")!;
    }

    public IDbConnection DatabaseConnection() => new MySqlConnection(_connectionString);
}

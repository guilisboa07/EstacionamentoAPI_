using System.Data;
using System.Data.SqlClient;

public class DbContext
{
    private readonly string _connectionString;

    public DbContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Estacionamento");
    }
    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
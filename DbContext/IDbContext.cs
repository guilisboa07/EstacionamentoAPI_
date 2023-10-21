using System.Data;

namespace EstacionamentoAPI.DbContext
{
    public interface IDbContext
    {
        IDbConnection CreateConnection();
    }
}
using Dapper;
using EstacionamentoAPI.DbContext;
using Microsoft.AspNetCore.SignalR;

namespace EstacionamentoAPI.Repositories
{
 
     public class CarroRepository : ICarroRepository
    {
        private readonly IDbContext _dbContext;

        public CarroRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Carro> ObterTodosCarros()
        {
            using var connection = _dbContext.CreateConnection();
            var query = "SELECT * FROM Carro";
            return connection.Query<Carro>(query);
        }

        public Carro ObterCarroPorPlaca(string placa)
        {
            using var connection = _dbContext.CreateConnection();
            var query = "SELECT * FROM Carro WHERE Placa = @Placa";
            return connection.QueryFirstOrDefault<Carro>(query, new { Placa = placa });
        }

        public void AdicionarCarro(Carro carro)
        {
            using var connection = _dbContext.CreateConnection();
            var query = "INSERT INTO Carro (Placa, Marca, Modelo) VALUES (@Placa, @Marca, @Modelo)";
            connection.Execute(query, carro);
        }

        public void AtualizarCarro(Carro carro)
        {
            using var connection = _dbContext.CreateConnection();
            var query = "UPDATE Carro SET Marca = @Marca, Modelo = @Modelo WHERE Placa = @Placa";
            connection.Execute(query, carro);
        }

        public void DeletarCarro(string placa)
        {
            using var connection = _dbContext.CreateConnection();
            var query = "DELETE FROM Carro WHERE Placa = @Placa";
            connection.Execute(query, new { Placa = placa });
        }
    }
}

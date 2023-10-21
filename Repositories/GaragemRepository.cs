using Dapper;
using EstacionamentoAPI.DbContext;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repositories;
using System;
using System.Collections.Generic;

namespace EstacionamentoAPI.Repositories
{
    public class GaragemRepository : IGaragemRepository
    {
        private readonly IDbContext _dbContext;

        public GaragemRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AdicionarGaragem(Garagem garagem)
        {
            var query = "INSERT INTO Garagem(Codigo, Nome, PrecoPrimeiraHora, PrecoHorasExtra, PrecoMensalista) VALUES (@Codigo, @Nome, @PrecoPrimeiraHora, @PrecoHorasExtra, @PrecoMensalista)";
            var parameters = new DynamicParameters();
            parameters.Add("Codigo", garagem.Codigo, System.Data.DbType.String);
            parameters.Add("Nome", garagem.Nome, System.Data.DbType.String);
            parameters.Add("PrecoPrimeiraHora", garagem.PrecoPrimeiraHora, System.Data.DbType.Decimal);
            parameters.Add("PrecoHorasExtra", garagem.PrecoHorasExtra, System.Data.DbType.Decimal);
            parameters.Add("PrecoMensalista", garagem.PrecoMensalista, System.Data.DbType.Decimal);
            using var connection = _dbContext.CreateConnection();
            connection.Execute(query, parameters);
        }

        public void AtualizarGaragem(Garagem garagem)
        {
            using var connection = _dbContext.CreateConnection();

            var query = "UPDATE Garagem SET Nome = @Nome, PrecoPrimeiraHora = @PrecoPrimeiraHora, PrecoHorasExtra = @PrecoHorasExtra, PrecoMensalista = @PrecoMensalista WHERE Codigo = @Codigo";

            connection.Execute(query, new
            {
                garagem.Nome,
                garagem.PrecoPrimeiraHora,
                garagem.PrecoHorasExtra,
                garagem.PrecoMensalista,
                garagem.Codigo
            });
        }

        public void DeletarGaragem(string codigo)
        {
            using var connection = _dbContext.CreateConnection();

            var query = "DELETE FROM Garagem WHERE Codigo = @Codigo";
            connection.Execute(query, new { Codigo = codigo });
        }

        public Garagem ObterGaragemPorCodigo(string codigo)
        {
            using var connection = _dbContext.CreateConnection();

            var query = "SELECT * FROM Garagem WHERE Codigo = @Codigo";
            return connection.QueryFirstOrDefault<Garagem>(query, new { Codigo = codigo });
        }

        public IEnumerable<Garagem> ObterTodasGaragens()
        {
            using var connection = _dbContext.CreateConnection();

            var query = "SELECT * FROM Garagem";
            return connection.Query<Garagem>(query);
        }

        public IEnumerable<Passagem> ObterPassagensPorGaragem(string codigoGaragem)
        {
            using var connection = _dbContext.CreateConnection();

            var query = "SELECT * FROM Passagem WHERE Garagem = @CodigoGaragem";
            return connection.Query<Passagem>(query, new { CodigoGaragem = codigoGaragem });
        }
    }
}

using Dapper;
using EstacionamentoAPI.DbContext;
using EstacionamentoAPI.Models;
using System;
using System.Collections.Generic;

namespace EstacionamentoAPI.Repositories
{
    public class FormaPagamentoRepository : IFormaPagamentoRepository
    {
        private readonly IDbContext _dbContext;

        public FormaPagamentoRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<FormaPagamento> ObterTodasFormasPagamento()
        {
            using var connection = _dbContext.CreateConnection();
            var query = "SELECT * FROM FormaPagamento";
            return connection.Query<FormaPagamento>(query);
        }

        public FormaPagamento ObterFormaPagamentoPorCodigo(string codigo)
        {
            using var connection = _dbContext.CreateConnection();
            var query = "SELECT * FROM FormaPagamento WHERE Codigo = @Codigo";
            return connection.QueryFirstOrDefault<FormaPagamento>(query, new { Codigo = codigo });
        }

        public void AdicionarFormaPagamento(FormaPagamento formaPagamento)
        {
            using var connection = _dbContext.CreateConnection();
            var query = "INSERT INTO FormaPagamento (Codigo, Descricao) VALUES (@Codigo, @Descricao)";
            connection.Execute(query, formaPagamento);
        }

        public void AtualizarFormaPagamento(FormaPagamento formaPagamento)
        {
            using var connection = _dbContext.CreateConnection();
            var query = "UPDATE FormaPagamento SET Descricao = @Descricao WHERE Codigo = @Codigo";
            connection.Execute(query, formaPagamento);
        }

        public void DeletarFormaPagamento(string codigo)
        {
            using var connection = _dbContext.CreateConnection();
            var query = "DELETE FROM FormaPagamento WHERE Codigo = @Codigo";
            connection.Execute(query, new { Codigo = codigo });
        }
    }
}
using Dapper;
using EstacionamentoAPI.DbContext;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repositories;
using System;
using System.Collections.Generic;

namespace EstacionamentoAPI.Repositories
{
    public class PassagemRepository : IPassagemRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IGaragemRepository _garagemRepository;
       

        public void Adicionar(Passagem passagem)
        {
            using var connection = _dbContext.CreateConnection();

            var query = "INSERT INTO Passagem (Garagem, CarroPlaca, CarroMarca, CarroModelo, DataHoraEntrada, DataHoraSaida, FormaPagamento, PrecoTotal) " +
                        "VALUES (@Garagem, @CarroPlaca, @CarroMarca, @CarroModelo, @DataHoraEntrada, @DataHoraSaida, @FormaPagamento, @PrecoTotal)";

            connection.Execute(query, passagem);
        }

        public Passagem ObterPorPlaca(string placa)
        {
            using var connection = _dbContext.CreateConnection();

            var query = "SELECT * FROM Passagem WHERE CarroPlaca = @Placa";
            return connection.QueryFirstOrDefault<Passagem>(query, new { Placa = placa });
        }

        public IEnumerable<Passagem> ObterPorGaragem(string codigoGaragem)
        {
            using var connection = _dbContext.CreateConnection();

            var query = "SELECT * FROM Passagem WHERE Garagem = @CodigoGaragem";
            return connection.Query<Passagem>(query, new { CodigoGaragem = codigoGaragem });
        }

        public void Remover(string placa)
        {
            using var connection = _dbContext.CreateConnection();

            var query = "DELETE FROM Passagem WHERE CarroPlaca = @Placa";
            connection.Execute(query, new { Placa = placa });
        }

        public IEnumerable<Passagem> ObterPassagensSemSaida()
        {
            using var connection = _dbContext.CreateConnection();

            var query = "SELECT * FROM Passagem WHERE DataHoraSaida IS NULL";
            return connection.Query<Passagem>(query);
        }

        public object ObterTodasPassagens()
        {
            using var connection = _dbContext.CreateConnection();

            var query = "SELECT * FROM Passagem";
            return connection.Query(query);
        }
         public decimal CalcularPrecoEstadiaAvulsa(Passagem passagem)
    {
        // Verifique se a passagem tem uma garagem válida
        if (passagem == null || string.IsNullOrWhiteSpace(passagem.Garagem))
        {
            throw new ArgumentNullException("A passagem deve estar associada a uma garagem válida.");
        }

        // Obtem informações da garagem para calcular o preço da estadia avulsa
        var garagem = _garagemRepository.ObterGaragemPorCodigo(passagem.Garagem);

        if (garagem == null)
        {
            throw new Exception("Garagem não encontrada.");
        }

        // Lógica para calcular o preço da estadia avulsa
        decimal precoTotal = garagem.PrecoPrimeiraHora;

        // Verifique o tempo de estadia
        TimeSpan tempoDeEstadia = (TimeSpan)(passagem.DataHoraSaida - passagem.DataHoraEntrada);

        if (tempoDeEstadia.TotalMinutes > 30)
        {
            // Cobrança de horas extras após a primeira hora
            int horasExtras = (int)Math.Ceiling(tempoDeEstadia.TotalHours - 1);
            precoTotal += horasExtras * garagem.PrecoHorasExtra;
        }

        return precoTotal;
    }
     
    }

}

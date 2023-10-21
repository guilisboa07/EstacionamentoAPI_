using System;
using System.Collections.Generic;
using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Repositories
{
    public interface IPassagemRepository
    {
        void Adicionar(Passagem passagem);
        Passagem ObterPorPlaca(string placa);
        IEnumerable<Passagem> ObterPorGaragem(string codigoGaragem);
        void Remover(string placa);
        IEnumerable<Passagem> ObterPassagensSemSaida();
        object ObterTodasPassagens();
        decimal CalcularPrecoEstadiaAvulsa(Passagem passagem);

    }
}

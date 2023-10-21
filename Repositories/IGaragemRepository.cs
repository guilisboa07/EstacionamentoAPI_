using System;
using System.Collections.Generic;
using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Repositories
{
    public interface IGaragemRepository
    {
        IEnumerable<Garagem> ObterTodasGaragens();
        Garagem ObterGaragemPorCodigo(string codigo);
        void AdicionarGaragem(Garagem garagem);
        void AtualizarGaragem(Garagem garagem);
        void DeletarGaragem(string codigo);
        IEnumerable<Passagem> ObterPassagensPorGaragem(string codigoGaragem);
    }
}

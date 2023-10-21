using EstacionamentoAPI.Models;
using System.Collections.Generic;

namespace EstacionamentoAPI.Repositories
{
    public interface IFormaPagamentoRepository
    {
        IEnumerable<FormaPagamento> ObterTodasFormasPagamento();
        FormaPagamento ObterFormaPagamentoPorCodigo(string codigo);
        void AdicionarFormaPagamento(FormaPagamento formaPagamento);
        void AtualizarFormaPagamento(FormaPagamento formaPagamento);
        void DeletarFormaPagamento(string codigo);
    }
}

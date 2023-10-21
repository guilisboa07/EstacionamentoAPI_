using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EstacionamentoAPI.Controllers
{
    [Route("api/formaspagamento")]
    [ApiController]
    public class FormaPagamentoController : ControllerBase
    {
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;

        public FormaPagamentoController(IFormaPagamentoRepository formaPagamentoRepository)
        {
            _formaPagamentoRepository = formaPagamentoRepository;
        }

        [HttpGet]
        public IEnumerable<FormaPagamento> ObterTodasFormasPagamento()
        {
            return _formaPagamentoRepository.ObterTodasFormasPagamento();
        }

        [HttpGet("{codigo}")]
        public ActionResult<FormaPagamento> ObterFormaPagamentoPorCodigo(string codigo)
        {
            var formaPagamento = _formaPagamentoRepository.ObterFormaPagamentoPorCodigo(codigo);
            if (formaPagamento == null)
            {
                return NotFound(); // Retornar um código de resposta 404 Not Found se a forma de pagamento não for encontrada.
            }
            return formaPagamento;
        }

        [HttpPost]
        public IActionResult AdicionarFormaPagamento([FromBody] FormaPagamento formaPagamento)
        {
            _formaPagamentoRepository.AdicionarFormaPagamento(formaPagamento);
            return CreatedAtAction("ObterFormaPagamentoPorCodigo", new { codigo = formaPagamento.Codigo }, formaPagamento);
        }

        [HttpPut("{codigo}")]
        public IActionResult AtualizarFormaPagamento(string codigo, [FromBody] FormaPagamento formaPagamento)
        {
            var formaPagamentoExistente = _formaPagamentoRepository.ObterFormaPagamentoPorCodigo(codigo);
            if (formaPagamentoExistente == null)
            {
                return NotFound(); // Retornar 404 se a forma de pagamento não for encontrada.
            }
            _formaPagamentoRepository.AtualizarFormaPagamento(formaPagamento);
            return NoContent(); // Retornar 204 No Content.
        }

        [HttpDelete("{codigo}")]
        public IActionResult DeletarFormaPagamento(string codigo)
        {
            var formaPagamentoExistente = _formaPagamentoRepository.ObterFormaPagamentoPorCodigo(codigo);
            if (formaPagamentoExistente == null)
            {
                return NotFound(); // Retornar 404 se a forma de pagamento não for encontrada.
            }
            _formaPagamentoRepository.DeletarFormaPagamento(codigo);
            return NoContent(); // Retornar 204 No Content.
        }
    }
}

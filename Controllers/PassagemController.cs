using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EstacionamentoAPI.Controllers
{
    [Route("api/passagem")]
    [ApiController]
    public class PassagemController : ControllerBase
    {
        private readonly IPassagemRepository _passagemRepository;
        private readonly IGaragemRepository _garagemRepository;
        private readonly ICarroRepository _carroRepository;

        public PassagemController(IPassagemRepository passagemRepository, IGaragemRepository garagemRepository, ICarroRepository carroRepository)
        {
            _passagemRepository = passagemRepository;
            _garagemRepository = garagemRepository;
            _carroRepository = carroRepository;
        }

        [HttpPost]
        public IActionResult AdicionarPassagem(Passagem passagem)
        {
            // Certifique-se de calcular o PrecoTotal e definir a FormaPagamento conforme os requisitos.
            passagem.PrecoTotal = _passagemRepository.CalcularPrecoEstadiaAvulsa(_garagemRepository.ObterGaragemPorCodigo(passagem.Garagem));
            passagem.FormaPagamento = "Avulsa";

            _passagemRepository.Adicionar(passagem);

            return CreatedAtRoute("ObterPassagemPorPlaca", new { placa = passagem.CarroPlaca }, passagem);
        }

        [HttpGet("{placa}", Name = "ObterPassagemPorPlaca")]
        public IActionResult ObterPassagemPorPlaca(string placa)
        {
            var passagem = _passagemRepository.ObterPorPlaca(placa);
            if (passagem == null)
            {
                return NotFound();
            }

            return Ok(passagem);
        }

        [HttpGet("garagem/{codigoGaragem}")]
        public IActionResult ObterPassagensPorGaragem(string codigoGaragem)
        {
            var passagens = _passagemRepository.ObterPorGaragem(codigoGaragem);
            return Ok(passagens);
        }

        [HttpDelete("{placa}")]
        public IActionResult RemoverPassagem(string placa)
        {
            var passagemExistente = _passagemRepository.ObterPorPlaca(placa);
            if (passagemExistente == null)
            {
                return NotFound();
            }

            _passagemRepository.Remover(placa);
            return NoContent();
        }

        [HttpGet("sem-saida")]
        public IActionResult ObterPassagensSemSaida()
        {
            var passagens = _passagemRepository.ObterPassagensSemSaida();
            return Ok(passagens);
        }

        [HttpGet("todas")]
        public IActionResult ObterTodasPassagens()
        {
            var passagens = _passagemRepository.ObterTodasPassagens();
            return Ok(passagens);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using EstacionamentoAPI.Repositories;
using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Controllers
{
    [Route("api/garagens")]
    [ApiController]
    public class GaragemController : ControllerBase
    {
        private readonly IGaragemRepository _garagemRepository;

        public GaragemController(IGaragemRepository garagemRepository)
        {
            _garagemRepository = garagemRepository;
        }

        [HttpGet]
        public IActionResult ObterTodasGaragens()
        {
            // Lógica para obter todas as garagens
            var garagens = _garagemRepository.ObterTodasGaragens();
            return Ok(garagens);
        }

        [HttpGet("{codigo}")]
        public IActionResult ObterGaragemPorCodigo(string codigo)
        {
            // Lógica para obter uma garagem por código
            var garagem = _garagemRepository.ObterGaragemPorCodigo(codigo);
            if (garagem == null)
            {
                return NotFound();
            }
            return Ok(garagem);
        }

        [HttpPost]
        public IActionResult AdicionarGaragem(Garagem garagem)
        {
            // Lógica para adicionar uma nova garagem
            _garagemRepository.AdicionarGaragem(garagem);
            return Ok();
        }

        [HttpPut]
        public IActionResult AtualizarGaragem(Garagem garagem)
        {
            // Lógica para atualizar uma garagem
            _garagemRepository.AtualizarGaragem(garagem);
            return Ok();
        }

        [HttpDelete("{codigo}")]
        public IActionResult DeletarGaragem(string codigo)
        {
            // Lógica para deletar uma garagem por código
            _garagemRepository.DeletarGaragem(codigo);
            return NoContent();
        }

        [HttpGet("{codigo}/passagens")]
        public IActionResult ObterPassagensPorGaragem(string codigo)
        {
            // Lógica para obter passagens por código de garagem
            var passagens = _garagemRepository.ObterPassagensPorGaragem(codigo);
            return Ok(passagens);
        }
    }
}

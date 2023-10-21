using EstacionamentoAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoAPI.Controllers
{
    [Route("api/carros")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly ICarroRepository _carroRepository;

        public CarroController(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        [HttpGet]
        public IActionResult ObterTodosCarros()
        {
            var carros = _carroRepository.ObterTodosCarros();
            return Ok(carros);
        }

        [HttpGet("{placa}")]
        public IActionResult ObterCarroPorPlaca(string placa)
        {
            var carro = _carroRepository.ObterCarroPorPlaca(placa);
            if (carro == null)
            {
                return NotFound();
            }
            return Ok(carro);
        }

        [HttpPost]
        public IActionResult AdicionarCarro(Carro carro)
        {
            _carroRepository.AdicionarCarro(carro);
            return CreatedAtAction(nameof(ObterCarroPorPlaca), new { placa = carro.Placa }, carro);
        }

        [HttpPut("{placa}")]
        public IActionResult AtualizarCarro(string placa, Carro carro)
        {
            if (placa != carro.Placa)
            {
                return BadRequest();
            }

            var existingCarro = _carroRepository.ObterCarroPorPlaca(placa);
            if (existingCarro == null)
            {
                return NotFound();
            }

            _carroRepository.AtualizarCarro(carro);
            return NoContent();
        }

        [HttpDelete("{placa}")]
        public IActionResult DeletarCarro(string placa)
        {
            var existingCarro = _carroRepository.ObterCarroPorPlaca(placa);
            if (existingCarro == null)
            {
                return NotFound();
            }

            _carroRepository.DeletarCarro(placa);
            return NoContent();
        }
    }
}

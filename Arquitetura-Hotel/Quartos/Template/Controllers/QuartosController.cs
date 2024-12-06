using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MicroserviceQuartos.DTO;
using MicroserviceQuartos.Infra;
using MicroserviceQuartos.Services;

namespace MicroserviceQuartos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuartosController : ControllerBase
    {
        private readonly QuartosService _quartosService;

        public QuartosController(QuartosService quartosService)
        {
            _quartosService = quartosService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosQuartos()
        {
            var quartos = await _quartosService.ObterTodosQuartos();
            return Ok(quartos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterQuarto(int id)
        {
            var quarto = await _quartosService.ObterQuartoPorId(id);
            return quarto == null ? NotFound() : Ok(quarto);
        }

        [HttpGet("{id}/disponibilidade")]
        public async Task<IActionResult> VerificarDisponibilidade(int id)
        {
            var disponivel = await _quartosService.VerificarDisponibilidade(id);
            return Ok(new { Disponivel = disponivel });
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> AtualizarStatus(int id, [FromBody] AtualizarStatusDTO dto)
        {
            if (id != dto.QuartoId)
                return BadRequest();

            var resultado = await _quartosService.AtualizarStatus(dto);
            return resultado ? Ok() : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarQuarto([FromBody] QuartoDTO quartoDto)
        {
            var quarto = await _quartosService.AdicionarQuarto(quartoDto);
            return CreatedAtAction(nameof(ObterQuarto), new { id = quarto.Id }, quarto);
        }
    }
}

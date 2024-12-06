using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MicroserviceReservas.DTO;
using MicroserviceReservas.Services;

namespace MicroserviceReservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly ReservaService _reservaService;

        public ReservasController(ReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        // Endpoint para obter a reserva de um cliente específico
        [HttpGet("{clienteId}")]
        public async Task<IActionResult> ObterReserva(int clienteId)
        {
            var reserva = await _reservaService.ObterReservaPorCliente(clienteId);
            return reserva == null ? NotFound() : Ok(reserva);
        }

        // Endpoint para criar uma nova reserva
        [HttpPost("{clienteId}")]
        public async Task<IActionResult> CriarReserva(int clienteId, [FromBody] ReservasDTO reservasDto)
        {
            if (clienteId != reservasDto.ClienteId)
                return BadRequest("ID do cliente não corresponde.");

            var reservaCriada = await _reservaService.CriarReserva(reservasDto);
            return CreatedAtAction(nameof(ObterReserva), new { clienteId = reservaCriada.ClienteId }, reservaCriada);
        }

        // Endpoint para atualizar os detalhes de uma reserva existente
        [HttpPut("{clienteId}")]
        public async Task<IActionResult> AtualizarReserva(int clienteId, [FromBody] ReservasDTO reservasDto)
        {
            if (clienteId != reservasDto.ClienteId)
                return BadRequest();

            var reservaAtualizada = await _reservaService.AtualizarReserva(reservasDto);
            return reservaAtualizada == null ? NotFound() : Ok(reservaAtualizada);
        }

        // Endpoint para cancelar uma reserva
        [HttpDelete("{clienteId}")]
        public async Task<IActionResult> CancelarReserva(int clienteId)
        {
            var reservaCancelada = await _reservaService.CancelarReserva(clienteId);
            return reservaCancelada ? NoContent() : NotFound();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MicroserviceHospedes.DTO;
using MicroserviceHospedes.Servicos;
using System.Threading.Tasks;

namespace MicroserviceHospedes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospedesController : ControllerBase
    {
        private readonly HospedesService _hospedesService;

        public HospedesController(HospedesService hospedesService)
        {
            _hospedesService = hospedesService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarHospede([FromBody] HospedesDTO hospedesDto)
        {
            var hospede = await _hospedesService.CriarHospede(hospedesDto);
            return CreatedAtAction(nameof(ObterHospede), new { id = hospede.Id }, hospede);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterHospede(int id)
        {
            var hospede = await _hospedesService.ObterHospede(id);
            return hospede == null ? NotFound() : Ok(hospede);
        }
    }
}

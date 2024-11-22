[ApiController]
[Route("api/reservas")]
public class ReservasController : ControllerBase
{
    private static List<Reserva> reservas = new List<Reserva>();
    
    [HttpPost]
    public async Task<ActionResult> CriarReserva([FromBody] Reserva novaReserva)
    {
        // Verificar disponibilidade do quarto
        var quartoResponse = await HttpClient.GetFromJsonAsync<Quarto>($"http://servico-quartos/api/quartos/{novaReserva.QuartoId}");
        if (quartoResponse == null || !quartoResponse.Disponivel)
        {
            return BadRequest("Quarto não disponível.");
        }

        // Verificar status do hóspede
        var hospedeResponse = await HttpClient.GetFromJsonAsync<Hospede>($"http://servico-hospedes/api/hospedes/{novaReserva.HospedeId}");
        if (hospedeResponse == null)
        {
            return BadRequest("Hóspede não encontrado.");
        }

        reservas.Add(novaReserva);

        // Atualizar disponibilidade do quarto
        quartoResponse.Disponivel = false;
        await HttpClient.PutAsJsonAsync($"http://servico-quartos/api/quartos/{novaReserva.QuartoId}", quartoResponse);

        return CreatedAtAction(nameof(GetReserva), new { id = novaReserva.Id }, novaReserva);
    }
}

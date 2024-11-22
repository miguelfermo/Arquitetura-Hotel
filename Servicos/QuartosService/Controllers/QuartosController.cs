[ApiController]
[Route("api/quartos")]
public class QuartosController : ControllerBase
{
    private static List<Quarto> quartos = new List<Quarto>
    {
        new Quarto { Id = 1, Tipo = "Standard", Preco = 100, Disponivel = true },
        new Quarto { Id = 2, Tipo = "Deluxe", Preco = 200, Disponivel = true }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Quarto>> GetQuartos()
    {
        return Ok(quartos);
    }

    [HttpGet("{id}")]
    public ActionResult<Quarto> GetQuarto(int id)
    {
        var quarto = quartos.FirstOrDefault(q => q.Id == id);
        if (quarto == null) return NotFound();
        return Ok(quarto);
    }

    [HttpPost]
    public ActionResult AddQuarto([FromBody] Quarto novoQuarto)
    {
        quartos.Add(novoQuarto);
        return CreatedAtAction(nameof(GetQuarto), new { id = novoQuarto.Id }, novoQuarto);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateQuarto(int id, [FromBody] Quarto quartoAtualizado)
    {
        var quarto = quartos.FirstOrDefault(q => q.Id == id);
        if (quarto == null) return NotFound();

        quarto.Tipo = quartoAtualizado.Tipo;
        quarto.Preco = quartoAtualizado.Preco;
        quarto.Disponivel = quartoAtualizado.Disponivel;

        return NoContent();
    }
}

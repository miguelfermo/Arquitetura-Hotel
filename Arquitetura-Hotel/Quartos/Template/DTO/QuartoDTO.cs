namespace MicroserviceQuartos.DTO
{
    public class QuartoDTO
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; } // Exemplo: "Luxo", "Simples"
        public string Status { get; set; } // Exemplo: "Disponível", "Ocupado"
        public string Descricao { get; set; }
    }

    public class AtualizarStatusDTO
    {
        public int QuartoId { get; set; }
        public string Status { get; set; } // Exemplo: "Disponível", "Manutenção"
    }
}

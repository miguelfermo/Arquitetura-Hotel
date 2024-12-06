using System.ComponentModel.DataAnnotations;

namespace MicroserviceQuartos.Infra
{
    public class Quarto
    {
        [Key]
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; } // Exemplo: "Luxo", "Simples"
        public string? Descricao { get; set; }
        public string Status { get; set; } = "Disponível";
    }
}

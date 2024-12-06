using System;
using System.ComponentModel.DataAnnotations;

namespace MicroserviceReservas.Infra
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataReserva { get; set; } = DateTime.UtcNow;
        public DateTime? DataCheckIn { get; set; } // Pode ser nulo
        public DateTime? DataCheckOut { get; set; } // Pode ser nulo
        public string Status { get; set; } = "Pendente"; // Status pode ser "Pendente", "Confirmada", "Finalizada", "Cancelada"
        public decimal PrecoTotal { get; set; } // Preço total da reserva
    }
}

namespace MicroserviceReservas.DTO
{
    public class ReservasDTO
    {
        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataReserva { get; set; }
        public DateTime? DataCheckIn { get; set; } // Data do check-in, pode ser nulo
        public DateTime? DataCheckOut { get; set; } // Data do check-out, pode ser nulo
        public string Status { get; set; } = "Pendente"; // Pode ser "Confirmada", "Cancelada", "Finalizada"
        public decimal PrecoTotal { get; set; } // Preço total da reserva
    }
}

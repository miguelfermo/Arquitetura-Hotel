using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MicroserviceReservas.DTO;
using MicroserviceReservas.Infra;
using MicroserviceReservas.Infra.Contexto;

namespace MicroserviceReservas.Services
{
    public class ReservaService
    {
        private readonly ReservasContext _context;

        public ReservaService(ReservasContext context)
        {
            _context = context;
        }

        // Obtém a reserva de um cliente específico
        public async Task<Reserva> ObterReservaPorCliente(int clienteId)
        {
            return await _context.Reservas
                .Where(r => r.ClienteId == clienteId && r.Status != "Cancelada")
                .OrderByDescending(r => r.DataReserva)
                .FirstOrDefaultAsync();
        }

        // Cria uma nova reserva
        public async Task<Reserva> CriarReserva(ReservasDTO reservasDto)
        {
            var novaReserva = new Reserva
            {
                ClienteId = reservasDto.ClienteId,
                NomeCliente = reservasDto.NomeCliente,
                DataReserva = reservasDto.DataReserva,
                PrecoTotal = reservasDto.PrecoTotal,
                Status = "Pendente",
            };

            _context.Reservas.Add(novaReserva);
            await _context.SaveChangesAsync();
            return novaReserva;
        }

        // Atualiza os detalhes de uma reserva existente
        public async Task<Reserva> AtualizarReserva(ReservasDTO reservasDto)
        {
            var reservaExistente = await _context.Reservas
                .Where(r => r.ClienteId == reservasDto.ClienteId)
                .FirstOrDefaultAsync();

            if (reservaExistente == null)
                return null;

            reservaExistente.DataCheckIn = reservasDto.DataCheckIn;
            reservaExistente.DataCheckOut = reservasDto.DataCheckOut;
            reservaExistente.Status = reservasDto.Status;
            reservaExistente.PrecoTotal = reservasDto.PrecoTotal;

            _context.Reservas.Update(reservaExistente);
            await _context.SaveChangesAsync();
            return reservaExistente;
        }

        // Cancela uma reserva
        public async Task<bool> CancelarReserva(int clienteId)
        {
            var reserva = await _context.Reservas
                .Where(r => r.ClienteId == clienteId && r.Status != "Cancelada")
                .FirstOrDefaultAsync();

            if (reserva == null)
                return false;

            reserva.Status = "Cancelada";
            _context.Reservas.Update(reserva);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

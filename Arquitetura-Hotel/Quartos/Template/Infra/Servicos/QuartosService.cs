using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MicroserviceQuartos.DTO;
using MicroserviceQuartos.Infra;
using MicroserviceQuartos.Infra.Contexto;

namespace MicroserviceQuartos.Services
{
    public class QuartosService
    {
        private readonly QuartosContext _context;

        public QuartosService(QuartosContext context)
        {
            _context = context;
        }

        public async Task<List<Quarto>> ObterTodosQuartos()
        {
            return await _context.Quartos.ToListAsync();
        }

        public async Task<Quarto> ObterQuartoPorId(int id)
        {
            return await _context.Quartos.FindAsync(id);
        }

        public async Task<bool> VerificarDisponibilidade(int quartoId)
        {
            var quarto = await _context.Quartos.FindAsync(quartoId);
            return quarto != null && quarto.Status == "Disponível";
        }

        public async Task<bool> AtualizarStatus(AtualizarStatusDTO dto)
        {
            var quarto = await _context.Quartos.FindAsync(dto.QuartoId);

            if (quarto == null)
                return false;

            quarto.Status = dto.Status;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Quarto> AdicionarQuarto(QuartoDTO quartoDto)
        {
            var quarto = new Quarto
            {
                Numero = quartoDto.Numero,
                Tipo = quartoDto.Tipo,
                Descricao = quartoDto.Descricao,
                Status = "Disponível"
            };

            _context.Quartos.Add(quarto);
            await _context.SaveChangesAsync();
            return quarto;
        }
    }
}

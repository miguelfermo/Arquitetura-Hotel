using System.Threading.Tasks;
using MicroserviceHospedes.DTO;
using MicroserviceHospedes.Infra;
using MicroserviceHospedes.Infra.Contexto;

namespace MicroserviceHospedes.Servicos
{
    public class HospedesService
    {
        private readonly HospedesContext _context;

        public HospedesService(HospedesContext context)
        {
            _context = context;
        }

        public async Task<Hospede> CriarHospede(HospedesDTO hospedesDto)
        {
            // Cria o hóspede
            var hospede = new Hospede
            {
                Nome = hospedesDto.Nome,
                DataEntrada = hospedesDto.DataEntrada,
                DataSaida = hospedesDto.DataSaida
            };

            _context.Hospedes.Add(hospede);
            await _context.SaveChangesAsync();

            return hospede;
        }

        public async Task<Hospede> ObterHospede(int id)
        {
            return await _context.Hospedes.FindAsync(id);
        }
    }
}

using MicroserviceReservas.Infra.Contexto;

namespace MicroserviceReservas.Infra
{
    public static class GeradorDeServicos
    {
        public static ServiceProvider ServiceProvider;

        // Método para carregar o contexto da base de dados
        public static ReservasContext CarregarContexto()
        {
            return ServiceProvider.GetService<ReservasContext>();
        }
    }
}

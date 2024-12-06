using MicroserviceQuartos.Infra.Contexto;

namespace MicroserviceQuartos.Infra
{
    public static class GeradorDeServicos
    {
        public static ServiceProvider ServiceProvider;

        public static QuartosContext CarregarContexto()
        {
            return ServiceProvider.GetService<QuartosContext>();
        }
    }
}

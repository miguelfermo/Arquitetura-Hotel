using MicroserviceHospedes;
using MicroserviceHospedes.Infra.Contexto;

namespace MicroserviceHospedes.Infra
{
    public static class GeradorDeServicos
    {
        public static ServiceProvider ServiceProvider;

        public static HospedesContext CarregarContexto()
        {
            return ServiceProvider.GetService<HospedesContext>();
        }
    }
}

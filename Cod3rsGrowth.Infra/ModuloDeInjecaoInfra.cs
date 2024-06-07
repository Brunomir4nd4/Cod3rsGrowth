using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Infra
{
    public class ModuloDeInjecaoInfra
    {
        public static void BindServices(ServiceCollection servicos)
        {
            servicos.AddScoped<MeuContextoDeDados>();
        }
    }
}

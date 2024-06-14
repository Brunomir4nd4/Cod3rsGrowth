using Cod3rsGrowth.Infra.ConexaoBD;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Infra.ModuloDeInjecao
{
    public class ModuloDeInjecaoInfra
    {
        public static void BindServices(ServiceCollection servicos)
        {
            servicos.AddScoped<MeuContextoDeDados>();
        }
    }
}

using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Teste.ConfiguracaoAmbienteTeste
{
    public class ModeloDeInjecao
    {
        public static void BindServices(ServiceCollection servicos)
        {
            servicos.AddScoped<IServicoPocao, ServicoPocao>();
            servicos.AddScoped<IServicoIngrediente, ServicoIngrediente>();
        }
    }
}

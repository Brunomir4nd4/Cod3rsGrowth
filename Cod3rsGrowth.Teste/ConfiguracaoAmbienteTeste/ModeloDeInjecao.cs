using Cod3rsGrowth.Servico.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Teste.Repositorios;
using Cod3rsGrowth.Servico.Validadores;

namespace Cod3rsGrowth.Teste.ConfiguracaoAmbienteTeste
{
    public class ModeloDeInjecao
    {
        public static void BindServices(ServiceCollection servicos)
        {
            servicos.AddScoped<IServicoPocao, ServicoPocao>();
            servicos.AddScoped<IServicoIngrediente, ServicoIngrediente>();

            servicos.AddScoped<IRepositorioPocao, RepositorioPocaoMock>();
            servicos.AddScoped<IRepositorioIngrediente, RepositorioIngredienteMock>();

            servicos.AddScoped<PocaoValidator>();
        }
    }
}

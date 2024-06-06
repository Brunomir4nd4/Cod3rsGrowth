using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Teste.Repositorios;
using Cod3rsGrowth.Servico.Validadores;

namespace Cod3rsGrowth.Teste.ConfiguracaoAmbienteTeste
{
    public class ModuloDeInjecao
    {
        public static void BindServices(ServiceCollection servicos)
        {
            servicos.AddScoped<ServicoPocao>();
            servicos.AddScoped<ServicoIngrediente>();
            servicos.AddScoped<ServicoReceita>();

            servicos.AddScoped<IRepositorioPocao, RepositorioPocaoMock>();
            servicos.AddScoped<IRepositorioIngrediente, RepositorioIngredienteMock>();
            servicos.AddScoped<IRepositorioReceita, RepositorioReceitaMock>();

            servicos.AddScoped<IngredienteValidator>();
            servicos.AddScoped<ReceitaValidator>();
        }
    }
}

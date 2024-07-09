using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Teste.Repositorios;
using Cod3rsGrowth.Servico.Validadores;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Teste.ConfiguracaoAmbienteTeste
{
    public class ModuloDeInjecao
    {
        public static void BindServices(IServiceCollection servicos)
        {
            servicos.AddScoped<ServicoPocao>();
            servicos.AddScoped<ServicoIngrediente>();
            servicos.AddScoped<ServicoReceita>();
            servicos.AddScoped<ServicoReceitaIngrediente>();

            servicos.AddScoped<IRepositorioPocao, RepositorioPocaoMock>();
            servicos.AddScoped<IRepositorioIngrediente, RepositorioIngredienteMock>();
            servicos.AddScoped<IRepositorioReceita, RepositorioReceitaMock>();
            servicos.AddScoped<IRepositorioReceitaIngrediente, RepositorioReceitaIngredienteMock>();

            servicos.AddScoped<IngredienteValidator>();
            servicos.AddScoped<ReceitaValidator>();
        }
    }
}

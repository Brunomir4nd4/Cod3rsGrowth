using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Servico.Validadores;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Servico
{
    public class ModuloInjetorServico
    {
        public static void BindServices(ServiceCollection servicos)
        {
            servicos.AddScoped<ServicoIngrediente>();
            servicos.AddScoped<ServicoReceita>();
            servicos.AddScoped<ServicoReceitaIngrediente>();
            servicos.AddScoped<ServicoPocao>();

            servicos.AddScoped<IngredienteValidator>();
            servicos.AddScoped<ReceitaValidator>();
        }
    }
}

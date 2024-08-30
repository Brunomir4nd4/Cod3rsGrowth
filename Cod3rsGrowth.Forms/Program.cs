using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Servico;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms
{
    public static class Program
    {
        private static ServiceProvider? _serviceProvider;
        private static string _conectionString = System.Configuration.ConfigurationManager.ConnectionStrings["contextoPadrao"].ConnectionString;
        [STAThread]

        static void Main()
        {
            var colecaoDeServicos = new ServiceCollection();
            ModuloInjetorInfra.BindServices(colecaoDeServicos);
            ModuloInjetorServico.BindServices(colecaoDeServicos);
            _serviceProvider = colecaoDeServicos.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            ModuloInjetorInfra.AtualizarTabelas(_serviceProvider);

            Application.Run(new FormListagem(
                _serviceProvider.GetRequiredService<ServicoIngrediente>(),
                _serviceProvider.GetRequiredService<ServicoReceita>(),
                _serviceProvider.GetRequiredService<ServicoPocao>())
            );
        }
    }
}
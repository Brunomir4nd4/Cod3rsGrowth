using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Servico;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    public class ControllerBase : Controller
    {
        protected static ServiceProvider _serviceProvider;
        public ControllerBase() {}
        public void DefinirColesaoDeServico(string conectionString)
        {
            var colecaoDeServicos = new ServiceCollection();
            ModuloInjetorServico.BindServices(colecaoDeServicos);
            ModuloInjetorInfra.BindServices(colecaoDeServicos, conectionString);
            _serviceProvider = colecaoDeServicos.BuildServiceProvider();
            ModuloInjetorInfra.AtualizarTabelas(_serviceProvider);
        }
    }
}

using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Servico;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    public class ControllerBase : Controller, IDisposable
    {
        protected ServiceProvider _serviceProvider;

        public ControllerBase() 
        {
            _serviceProvider = ObterServiceCollection().BuildServiceProvider();
        }
        private IServiceCollection ObterServiceCollection()
        {
            var colecaoDeServicos = new ServiceCollection();
            ModuloInjetorServico.BindServices(colecaoDeServicos);
            ModuloInjetorInfra.BindServices(colecaoDeServicos);
            return colecaoDeServicos;
        }

        public virtual void Dispose()
        {
            _serviceProvider.Dispose();
        }
    }
}

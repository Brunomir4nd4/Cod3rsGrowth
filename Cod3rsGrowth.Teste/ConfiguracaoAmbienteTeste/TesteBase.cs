using Cod3rsGrowth.Infra;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Teste.ConfiguracaoAmbienteTeste
{
    public abstract class TesteBase : IDisposable
    {
        protected ServiceProvider ServiceProvider;
        protected TesteBase()
        {
            ServiceProvider = ObterServiceCollection().BuildServiceProvider();
        }   

        private IServiceCollection ObterServiceCollection()
        {
            var servicos = new ServiceCollection();
            ModuloDeInjecao.BindServices(servicos);
            ModuloDeInjecaoInfra.BindServices(servicos);
            return servicos;
        }

        public virtual void Dispose()
        {
            ServiceProvider.Dispose();
        }
    }
}

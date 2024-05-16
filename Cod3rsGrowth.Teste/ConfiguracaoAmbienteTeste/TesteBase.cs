using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Teste.ConfiguracaoAmbienteTeste
{
    public abstract class TesteBase : IDisposable
    {
        protected ServiceProvider ServiceProvider;

        private IServiceCollection ObterServiceCollection()
        {
            var servicos = new ServiceCollection();
            ModeloDeInjecao.BindServices(servicos);
            return servicos;
        }

        protected TesteBase()
        {
            ServiceProvider = ObterServiceCollection().BuildServiceProvider();
        }   
        public virtual void Dispose()
        {
            ServiceProvider.Dispose();
        }
    }
}

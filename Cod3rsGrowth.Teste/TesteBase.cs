using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Teste
{
    internal class TesteBase : IDisposable
    {
        protected ServiceProvider ServiceProvider { get; set; }

        public TesteBase(ServiceProvider serviceProvider) {
            ServiceProvider = serviceProvider;
        }
        public void Dispose()
        {
            ServiceProvider?.Dispose();
        }
    }
}

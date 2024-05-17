using Xunit;
using Cod3rsGrowth.Teste.ConfiguracaoAmbienteTeste;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Servicos;
namespace Cod3rsGrowth.Teste
{
    public class TesteUnitario : TesteBase
    {
        private IServicoPocao servicoPocao;
        public TesteUnitario() 
        {
            servicoPocao = ServiceProvider.GetService<IServicoPocao>();
        }
        [Fact]
        public void RetornarNomeDaPocao()
        {

        }
    }
}

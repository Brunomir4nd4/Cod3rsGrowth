using Xunit;
using Cod3rsGrowth.Teste.ConfiguracaoAmbienteTeste;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Teste
{
    public class TesteUnitario : TesteBase
    {
        private IRepositorio _repositorioMok;
        public TesteUnitario() 
        {
            _repositorioMok = ServiceProvider.GetService<IRepositorio>();
        }
        [Fact]
        public void NetherFungusComPoteComAguaResultaStrangePotion()
        {
            //  arrange
            var listaSingleton = _repositorioMok.ObterTodos();
            //  act
            var listaIngrediente = listaSingleton.listaIngrediente;
            //  assert 
            var ingrediente = listaIngrediente[0];
            var ingrediente2 = listaIngrediente[1];
            var pocao = "pocao invalida";

            if (ingrediente.Nome == "Fungus Nether" & ingrediente2.Nome == "Pote com Agua")
            {
                pocao = "StrangePotion";
            } 
            Assert.Equal("StrangePotion", pocao);
        }
    }
}

using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Teste.ConfiguracaoAmbienteTeste;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
namespace Cod3rsGrowth.Teste
{
    public class TestePocao : TesteBase
    {
        private IServicoPocao _servicoPocao;
        public TestePocao()
        {
            _servicoPocao = ServiceProvider.GetService<IServicoPocao>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoPocao)}]");
        }

        [Fact]
        public void ObterTodosDeveRetornarUmaListaDoTipoPocao()
        {
            var listaPocao = _servicoPocao.ObterTodos();
            Assert.IsType<List<Pocao>>(listaPocao);
        }

        [Fact]
        public void ListaPocaoIndexZeroDeveRetornarPocaoDeCrura()
        {
            Pocao pocao = new Pocao()
            {
                Id = 0,
                Nome = "Pocao de Cura"
            };

            _servicoPocao.CriarPocao(pocao);
            var listaPocao = _servicoPocao.ObterTodos();

            var nomePocao = listaPocao[0].Nome;

            Assert.Equal("Pocao de Cura", nomePocao);
        }
    }
}

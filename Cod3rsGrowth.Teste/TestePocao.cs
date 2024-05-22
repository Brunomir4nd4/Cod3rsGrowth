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
            CarregarServico();
        }

        private void CarregarServico()
        {
            _servicoPocao = ServiceProvider.GetService<IServicoPocao>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoPocao)}]");
        }

        [Fact]
        public void ObterTodos_ComUmaListaValida_DeveRetornarUmaListaDoTipoPocao()
        {
            var listaPocao = _servicoPocao.ObterTodos();
            Assert.IsType<List<Pocao>>(listaPocao);
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveSerEquivalenteAUmaListaDePocao()
        {
            Pocao pocao = new Pocao()
            {
                Id = 0,
                Nome = "Pocao de Cura",
                DataDeVencimento = DateTime.Now,
                Descricao = "Deve curar",
                Imagem = "caminho da imagem",
                Quantidade = 2,
                Valor = 20,
                Vencido = true
            };

            List<Pocao> listaMock = new List<Pocao> { pocao };

            _servicoPocao.CriarPocao(pocao);
            var listaDoBanco = _servicoPocao.ObterTodos();

            Assert.Equivalent(listaMock, listaDoBanco);
        }
    }
}

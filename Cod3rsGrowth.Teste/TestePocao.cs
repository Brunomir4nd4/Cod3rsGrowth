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

        [Fact]
        public void ObterPorId_ComDadosExistentes_DeveRetornarUmObjetoPocaoProcurado()
        {
            //arrange
            int id1 = 0, id2 = 1;
            Pocao pocaoMock1 = new Pocao()
            {
                Id = 0,
                Nome = "Pocao de Invissibilidade",
                DataDeVencimento = DateTime.Now,
                Descricao = "te deixa invissível",
                Imagem = "caminho da imagem",
                Quantidade = 3,
                Valor = 13,
                Vencido = true
            }; 
            Pocao pocaoMock2 = new Pocao()
            {
                Id = 1,
                Nome = "Pocao de Queda Lenta",
                DataDeVencimento = DateTime.Now,
                Descricao = "Faz você cair sem levar dano",
                Imagem = "caminho da imagem",
                Quantidade = 4,
                Valor = 7,
                Vencido = true
            };

            //act
            _servicoPocao.CriarPocao(pocaoMock1);
            _servicoPocao.CriarPocao(pocaoMock2);
            var objetoDoBanco1 = _servicoPocao.ObterPorId(id1);
            var objetoDoBanco2 = _servicoPocao.ObterPorId(id2);

            //assert
            Assert.Equal(pocaoMock1, objetoDoBanco1);
            Assert.Equal(pocaoMock2, objetoDoBanco2);
        }
    }
}

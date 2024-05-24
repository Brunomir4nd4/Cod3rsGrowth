using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Teste.ConfiguracaoAmbienteTeste;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
namespace Cod3rsGrowth.Teste
{
    public class TestePocao : TesteBase
    {
        private IServicoPocao _servicoPocao;
        private List<Pocao> _listaMock;
        private List<Pocao> _listaDoBanco;
        public TestePocao()
        {
            CarregarServico();
            _listaMock = IniciarBancoMock();
        }

        private void CarregarServico()
        {
            _servicoPocao = ServiceProvider.GetService<IServicoPocao>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoPocao)}]");
        }

        public List<Pocao> IniciarBancoMock()
        {
            List<Pocao> bancoMock = new List<Pocao>()
            {
                new Pocao{Id = 0,
                Nome = "Pocao de Cura",
                DataDeVencimento = DateTime.Today,
                Descricao = "Deve curar",
                Imagem = "caminho da imagem",
                Quantidade = 2,
                Valor = 20,
                Vencido = true},

                new Pocao{Id = 1,
                Nome = "Pocao de Força",
                DataDeVencimento = DateTime.Today,
                Descricao = "Te da Força",
                Imagem = "caminho da imagem",
                Quantidade = 5,
                Valor = 15,
                Vencido = true}
            };

            foreach (var item in bancoMock)
            {
                _servicoPocao.CriarPocao(item);
            }
            return bancoMock;
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
            _listaDoBanco = _servicoPocao.ObterTodos();

            Assert.Equivalent(_listaMock, _listaDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarIngredienteEsperado()
        {
            //arrange
            int idDeBusca = 0;
            var pocaoMock = _listaMock.FirstOrDefault();

            //act
            var pocaoDoBanco = _servicoPocao.ObterPorId(idDeBusca);

            //assert
            Assert.Equivalent(pocaoMock, pocaoDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarObjetoTypePocao()
        {
            //arrange
            int idProcurado = 1;

            //act
            var pocaoDoBanco = _servicoPocao.ObterPorId(idProcurado);

            //assert
            Assert.IsType<Pocao>(pocaoDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdInexistente_DeveLancarExcecaoObjetoNaoEncontrado()
        {
            //arrange
            int idInexistente = 999;

            //act
            var excecao = Assert.Throws<Exception>(() => _servicoPocao.ObterPorId(idInexistente));

            //assert
            Assert.Equal($"O objeto com id {idInexistente} não foi encontrado", excecao.Message);
        }
    }
}

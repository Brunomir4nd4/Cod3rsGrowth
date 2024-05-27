using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Teste.ConfiguracaoAmbienteTeste;
using FluentValidation;
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
                Valor = 20.00m,
                Vencido = true},

                new Pocao{Id = 1,
                Nome = "Pocao de Força",
                DataDeVencimento = DateTime.Today,
                Descricao = "Te da Força",
                Imagem = "caminho da imagem",
                Quantidade = 5,
                Valor = 15.00m,
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

        [Fact]
        public void CriarPocao_ComNomeVazio_DeveRetornarMensagemDeErroEsperada()
        {
            Pocao pocao = new Pocao()
            {
                Nome = "",
                Descricao = "Decrição A",
                DataDeVencimento = DateTime.Today,
                Valor = 20.22m
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoPocao.CriarPocao(pocao));

            Assert.Equal("Campo Nome não preenchido!", excecao.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void CriarPocao_ComNomeContendoLetras_DeveRetornarMensagemDeErroEsperada()
        {
            Pocao pocao = new Pocao()
            {
                Nome = "Poção 1",
                Descricao = "Decrição A",
                DataDeVencimento = DateTime.Today,
                Valor = 20.22m
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoPocao.CriarPocao(pocao));

            Assert.Equal("Campo Nome Deve conter apenas letras!", excecao.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void CriarPocao_ComDescricaoComOverFlow_DeveRetornarMensagemDeErroEsperada()
        {
            Pocao pocao = new Pocao()
            {
                Nome = "Poção A",
                Descricao = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                DataDeVencimento = DateTime.Today,
                Valor = 20.22m
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoPocao.CriarPocao(pocao));

            Assert.Equal("Campo Descrição deve ter no máximo 30 caracters!", excecao.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void CriarPocao_ComValorInvalido_DeveRetornarMensagemDeErroEsperada()
        {
            Pocao pocao = new Pocao()
            {
                Nome = "Poção A",
                Descricao = "Descrição A",
                DataDeVencimento = DateTime.Today,
                Valor = 2000m
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoPocao.CriarPocao(pocao));

            Assert.Equal("Campo Valor não pode execeder 3 digitos inteiros e 2 decimais!", excecao.Errors.Single().ErrorMessage);
        }
    }
}

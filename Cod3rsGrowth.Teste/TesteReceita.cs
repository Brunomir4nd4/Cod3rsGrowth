using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Teste.ConfiguracaoAmbienteTeste;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
namespace Cod3rsGrowth.Teste
{
    public class TesteReceita : TesteBase
    {
        private IServicoReceita _servicoReceita;
        private List<Receita> _listaMock;
        private List<Receita> _listaDoBanco;
        private Receita _receitaParaTeste;
        public TesteReceita()
        {
            CarregarServico();
            _listaMock = IniciarBancoMock();
        }

        private void CarregarServico()
        {
            _servicoReceita = ServiceProvider.GetService<IServicoReceita>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoReceita)}]");
        }

        public List<Receita> IniciarBancoMock()
        {
            List<Receita> bancoMock = new List<Receita>()
            {
                new Receita{
                Nome = "receita de Cura",
                Descricao = "Deve curar",
                Imagem = "caminho da imagem",
                Valor = 20.00m,
                ValidadeEmMeses = 4},

                new Receita{
                Nome = "receita de Força",
                Descricao = "Te da Força",
                Imagem = "caminho da imagem", 
                Valor = 15.00m,
                ValidadeEmMeses = 4}
            };

            foreach (var item in bancoMock)
            {
                _servicoReceita.CriarReceita(item);
            }
            return bancoMock;
        }

        [Fact]
        public void ObterTodos_ComUmaListaValida_DeveRetornarUmaListaDoTiporeceita()
        {
            var listareceita = _servicoReceita.ObterTodos();
            Assert.IsType<List<Receita>>(listareceita);
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveSerEquivalenteAUmaListaDereceita()
        {
            _listaDoBanco = _servicoReceita.ObterTodos();

            Assert.Equivalent(_listaMock, _listaDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarIngredienteEsperado()
        {
            //arrange
            int idDeBusca = 0;
            var receitaMock = _listaMock.FirstOrDefault();

            //act
            var receitaDoBanco = _servicoReceita.ObterPorId(idDeBusca);

            //assert
            Assert.Equivalent(receitaMock, receitaDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarObjetoTypereceita()
        {
            //arrange
            int idProcurado = 1;

            //act
            var receitaDoBanco = _servicoReceita.ObterPorId(idProcurado);

            //assert
            Assert.IsType<Receita>(receitaDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdInexistente_DeveLancarExcecaoObjetoNaoEncontrado()
        {
            //arrange
            int idInexistente = 999;

            //act
            var excecao = Assert.Throws<Exception>(() => _servicoReceita.ObterPorId(idInexistente));

            //assert
            Assert.Equal($"O objeto com id {idInexistente} não foi encontrado", excecao.Message);
        }

        [Theory]
        [InlineData("12324321")]
        [InlineData("@#$%&#5*")]
        public void CriarReceita_ComNomeInvalidado_DeveRetornarMensagemDeErroEsperada(string nome)
        {
            _receitaParaTeste = new Receita()
            {
                Nome = nome,
                Descricao = "Decrição A",
                ValidadeEmMeses = 4,
                Valor = 20.22m
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.CriarReceita(_receitaParaTeste));

            Assert.Equal("Campo Nome Deve conter apenas letras!", excecao.Message);
        }

        [Fact]
        public void CriarReceita_ComDescricaoComOverFlow_DeveRetornarMensagemDeErroEsperada()
        {
            _receitaParaTeste = new Receita()
            {
                Nome = "Receita A",
                Descricao = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ValidadeEmMeses = 4,
                Valor = 20.22m
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.CriarReceita(_receitaParaTeste));

            Assert.Equal("Campo Descrição deve ter no máximo 30 caracters!", excecao.Message);
        }

        [Fact]
        public void CriarReceita_ComValorInvalido_DeveRetornarMensagemDeErroEsperada()
        {
            _receitaParaTeste = new Receita()
            {
                Nome = "Receita A",
                Descricao = "Descrição A",
                ValidadeEmMeses = 4,
                Valor = 2000m
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.CriarReceita(_receitaParaTeste));

            Assert.Equal("Campo Valor não pode execeder 3 digitos inteiros e 2 decimais!", excecao.Message);
        }

        [Fact]
        public void CriarReceita_ComValorNegativo_DeveRetornarMensagemDeErroEsperada()
        {
            _receitaParaTeste = new Receita()
            {
                Nome = "Receita A",
                Descricao = "Descrição A",
                ValidadeEmMeses = 4,
                Valor = -99
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.CriarReceita(_receitaParaTeste));

            Assert.Equal("Campo Valor deve ser maior que 0", excecao.Message);
        }
    }
}

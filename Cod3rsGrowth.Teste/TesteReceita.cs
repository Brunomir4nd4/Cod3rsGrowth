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
                new Receita{Id = 0,
                Nome = "receita de Cura",
                Descricao = "Deve curar",
                Imagem = "caminho da imagem",
                Valor = 20.00m,
                ValidadeEmMeses = 4},

                new Receita{Id = 1,
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

        [Fact]
        public void CriarReceita_ComNomeVazio_DeveRetornarMensagemDeErroEsperada()
        {
            Receita receita = new Receita()
            {
                Descricao = "Decrição A",
                ValidadeEmMeses = 4,
                Valor = 20.22m
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.CriarReceita(receita));

            Assert.Contains("Campo Nome não preenchido!", excecao.Message);
        }

        [Fact]
        public void CriarReceita_ComNomeContendoLetras_DeveRetornarMensagemDeErroEsperada()
        {
            Receita receita = new Receita()
            {
                Nome = "Receita 1",
                Descricao = "Decrição A",
                ValidadeEmMeses = 4,
                Valor = 20.22m
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.CriarReceita(receita));

            Assert.Contains("Campo Nome Deve conter apenas letras!", excecao.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("12324321")]
        [InlineData("@#$%&#5*(")]
        public void teste(string nomeVazio)
        {
            Receita receita = new Receita()
            {
                Nome = "Receita 1",
                Descricao = "Decrição A",
                ValidadeEmMeses = 4,
                Valor = 20.22m
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.CriarReceita(receita));

            Assert.Equal("Campo Nome Deve conter apenas letras!", excecao.Message);
        }

        [Fact]
        public void CriarReceita_ComDescricaoComOverFlow_DeveRetornarMensagemDeErroEsperada()
        {
            Receita receita = new Receita()
            {
                Nome = "Receita A",
                Descricao = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ValidadeEmMeses = 4,
                Valor = 20.22m
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.CriarReceita(receita));

            Assert.Contains("Campo Descrição deve ter no máximo 30 caracters!", excecao.Message);
        }

        [Fact]
        public void CriarReceita_ComValorInvalido_DeveRetornarMensagemDeErroEsperada()
        {
            Receita receita = new Receita()
            {
                Nome = "Receita A",
                Descricao = "Descrição A",
                ValidadeEmMeses = 4,
                Valor = 2000m
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.CriarReceita(receita));

            Assert.Contains("Campo Valor não pode execeder 3 digitos inteiros e 2 decimais!", excecao.Message);
        }

        [Fact]
        public void CriarReceita_Com3DadosInvalidos_DeveRetornarMensagensDeErrosEsperadas()
        {
            Receita receita = new Receita()
            {
                Nome = "Receita 1",
                Descricao = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Valor = 2000m
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.CriarReceita(receita));

            Assert.Contains("Campo Nome Deve conter apenas letras!", excecao.Message);
        }
    }
}

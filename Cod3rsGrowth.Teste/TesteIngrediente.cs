using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Teste.ConfiguracaoAmbienteTeste;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Teste
{
    public class TesteIngrediente : TesteBase
    {
        private ServicoIngrediente _servicoIngrediente;
        private List<Ingrediente> _listaMock;
        private List<Ingrediente> _listaDoBanco;
        private Ingrediente _ingredienteParaTeste;

        public TesteIngrediente()
        {
            CarregarServico();
            _listaMock = IniciarBancoMock();
        }

        public List<Ingrediente> IniciarBancoMock()
        {
            List<Ingrediente> listaMock = new List<Ingrediente>
            {
                new Ingrediente
                {
                    Nome = "Olho de Aranha",
                    Naturalidade = Naturalidade.OverWorld,
                    Quantidade = 5
                },

                new Ingrediente
                {
                    Nome = "Polvora",
                    Naturalidade = Naturalidade.OverWorld,
                    Quantidade = 6
                }
            };

            foreach (var item in listaMock)
            {
                _servicoIngrediente.CriarIngrediente(item);
            }
            return listaMock;
        }

        private void CarregarServico()
        {
            _servicoIngrediente = ServiceProvider.GetService<ServicoIngrediente>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(ServicoIngrediente)}]");
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarUmalistaDoTipoIngrediente()
        {
            var listaIngrediente = _servicoIngrediente.ObterTodos();
            Assert.IsType<List<Ingrediente>>(listaIngrediente);
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveSerEquivalenteAUmaListaDeIngrediente()
        {
            _listaDoBanco = _servicoIngrediente.ObterTodos();

            Assert.Equivalent(_listaMock, _listaDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarIngredienteEsperado()
        {
            //arrange
            int idBuscado = 0;
            var ingredienteMock = _listaMock.FirstOrDefault();

            //act
            var objetoDoBanco = _servicoIngrediente.ObterPorId(idBuscado);

            //assert
            Assert.Equal(ingredienteMock, objetoDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarObjetoTypeIngrediente()
        {
            //arrange
            int idProcurado = 1;

            //act
            var ingredienteDoBanco = _servicoIngrediente.ObterPorId(idProcurado);

            //assert
            Assert.IsType<Ingrediente>(ingredienteDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdInexistente_DeveLancarExcecaoObjetoNaoEncontrado()
        {
            //arrange
            int idInexistente = 999;

            //act
            var excecao = Assert.Throws<Exception>(() => _servicoIngrediente.ObterPorId(idInexistente));

            //assert
            Assert.Equal($"O objeto com id {idInexistente} não foi encontrado", excecao.Message);
        }

        [Theory]
        [InlineData("12324321")]
        [InlineData("@#$%&#5*(")]
        public void CriarIngrediente_ComNomeInvalidado_DeveRetornarMensagemDeErroEsperada(string nome)
        {
            _ingredienteParaTeste = new Ingrediente()
            {
                Nome = nome,
                Naturalidade = Naturalidade.OverWorld,
                Quantidade = 4
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoIngrediente.CriarIngrediente(_ingredienteParaTeste));

            Assert.Equal("Campo Nome deve conter apenas letras!", excecao.Message);

        }

        [Theory]
        [InlineData(null)]
        [InlineData("      ")]
        [InlineData("")]
        public void CriarIngrediente_ComNomeVazio_DeveRetornarMensagemDeErroEsperado(string nome)
        {
            _ingredienteParaTeste = new Ingrediente()
            {
                Nome = nome,
                Naturalidade = Naturalidade.OverWorld,
                Quantidade = 4
            };

            var execao = Assert.Throws<ValidationException>(() => _servicoIngrediente.CriarIngrediente(_ingredienteParaTeste));

            Assert.Equal("Campo Nome não preenchido!", execao.Message);
        }

        [Fact]
        public void CriarIngrediente_ComQuantidadeNegativa_DeveRetornarErroEsperado()
        {
            _ingredienteParaTeste = new Ingrediente()
            {
                Nome = "Ingrediente A",
                Naturalidade = Naturalidade.Nether,
                Quantidade = -99
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoIngrediente.CriarIngrediente(_ingredienteParaTeste));

            Assert.Equal("Campo Quantidade deve ser maior que 0", excecao.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        public void CriarIngrediente_ComQuantidadeVazia_DeveRetornarErroEsperado(int quantidade)
        {
            _ingredienteParaTeste = new Ingrediente()
            {
                Nome = "Ingrediente A",
                Naturalidade = Naturalidade.Nether,
                Quantidade = quantidade
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoIngrediente.CriarIngrediente(_ingredienteParaTeste));

            Assert.Equal("Campo Quantidade não preenchido!", excecao.Message);
        }
    }
}

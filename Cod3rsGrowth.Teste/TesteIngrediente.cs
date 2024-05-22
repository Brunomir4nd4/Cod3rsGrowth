using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Teste.ConfiguracaoAmbienteTeste;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Teste
{
    public class TesteIngrediente : TesteBase
    {
        private IServicoIngrediente _servicoIngrediente;
        public TesteIngrediente()
        {
            CarregarServico();
        }

        private void CarregarServico()
        {
            _servicoIngrediente = ServiceProvider.GetService<IServicoIngrediente>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoIngrediente)}]");
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
            Ingrediente ingrediente = new Ingrediente()
            {
                Id = 0,
                Nome = "Olho de Aranha",
                Naturalidade = Naturalidade.OverWorld,
                Quantidade = 5
            };

            List<Ingrediente> listaMock = new List<Ingrediente>() { ingrediente };

            _servicoIngrediente.CriarIngrediente(ingrediente);
            var listaDoBanco = _servicoIngrediente.ObterTodos();

            Assert.Equivalent(listaMock, listaDoBanco);
        }

        [Fact]
        public void ObterPorId_ComDadosExistentes_DeveRetornarUmObjetoIngredienteProcurado()
        {
            //arrange
            int id1 = 1, id2 = 2;
            Ingrediente ingredienteMock1 = new Ingrediente()
            {
                Id = 1,
                Nome = "Polvora",
                Naturalidade = Naturalidade.OverWorld,
                Quantidade = 6
            };
            Ingrediente ingredienteMock2 = new Ingrediente()
            {
                Id = 2,
                Nome = "Bastão do Blaze",
                Naturalidade = Naturalidade.Nether,
                Quantidade = 2
            };

            //act
            _servicoIngrediente.CriarIngrediente(ingredienteMock1);
            _servicoIngrediente.CriarIngrediente(ingredienteMock2);
            var objetoDoBanco1 = _servicoIngrediente.ObterPorId(id1);
            var objetoDoBanco2 = _servicoIngrediente.ObterPorId(id2);

            //assert
            Assert.Equal(ingredienteMock1, objetoDoBanco1);
            Assert.Equal(ingredienteMock2, objetoDoBanco2);
        }

        [Fact]
        public void ObterPorId_ComDadosExistentes_DeveRetornarUmObjetoIngrediente()
        {
            //arrange
            int idProcurado = 3;

            Ingrediente ingrediente = new Ingrediente()
            {
                Id = 3,
                Nome = "Olho de Aranha Fermentado",
                Naturalidade = Naturalidade.OverWorld,
                Quantidade = 9
            };

            //act
            _servicoIngrediente.CriarIngrediente(ingrediente);
            var ingredienteDoBanco = _servicoIngrediente.ObterPorId(idProcurado);

            //assert
            Assert.IsType<Ingrediente>(ingredienteDoBanco);
        }

        [Fact]
        public void ObterPorId_ComDadosInesistentes_DeveRetornarIdNaoEncontrado()
        {
            //arrange
            int idInesistente = 999;

            //act
            var excecao = Assert.Throws<Exception>(() => _servicoIngrediente.ObterPorId(idInesistente));

            //assert
            Assert.Equal("Id não encontrado", excecao.Message);
        }
    }
}

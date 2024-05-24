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
        private List<Ingrediente> _listaMock;
        private List<Ingrediente> _listaDoBanco;

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
                    Id = 0,
                    Nome = "Olho de Aranha",
                    Naturalidade = Naturalidade.OverWorld,
                    Quantidade = 5
                },
                
                new Ingrediente
                {
                    Id = 1,
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
    }
}

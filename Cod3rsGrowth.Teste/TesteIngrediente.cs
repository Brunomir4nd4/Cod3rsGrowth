using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servico.Interfaces;
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
            _servicoIngrediente = ServiceProvider.GetService<IServicoIngrediente>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoIngrediente)}]");
        }

        [Fact]
        public void RetornaLitaIngredienteComTamanho0()
        {
            var listaIngrediente = _servicoIngrediente.ObterTodos();
            var tamanhoListaIngrediente = listaIngrediente.Count;
            Assert.Equal(0, tamanhoListaIngrediente);
        }

        [Fact]
        public void ListaIngredienteIgualTipoListaIngrediente()
        {
            var listaIngrediente = _servicoIngrediente.ObterTodos();
            Assert.IsType<List<Ingrediente>>(listaIngrediente);
        }

        [Fact]
        public void ListaIngredienteIndexZeroRetornaOlhaDeAranha()
        {
            Ingrediente ingrediente = new Ingrediente()
            {
                Id = 0,
                Nome = "Olho de Aranha",
                Naturalidade = Naturalidade.OverWorld,
                Quantidade = 5
            };

            _servicoIngrediente.CriarIngrediente(ingrediente);
            var listaIngrediente = _servicoIngrediente.ObterTodos();

            var nomeDoIngrediente = listaIngrediente[0].Nome;
            Assert.Equal("Olho de Aranha", nomeDoIngrediente);
        }
    }
}

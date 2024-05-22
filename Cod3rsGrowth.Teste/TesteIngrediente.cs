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
    }
}

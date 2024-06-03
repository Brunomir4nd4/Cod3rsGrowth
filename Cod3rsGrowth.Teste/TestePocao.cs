using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Teste.ConfiguracaoAmbienteTeste;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Teste
{
    public class TestePocao : TesteBase
    {
        private ServicoPocao _servicoPocao;
        private ServicoIngrediente _servicoIngrediente;
        private ServicoReceita _servicoReceita;
        private List<Pocao> _listaMock;
        private List<Pocao> _listaDoBanco;
        private Pocao _pocaoParaTeste;
        public TestePocao()
        {
            CarregarServico();
            _listaMock = IniciarBancoMock();
        }

        private void CarregarServico()
        {
            _servicoPocao = ServiceProvider.GetService<ServicoPocao>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(ServicoPocao)}]");
            _servicoReceita = ServiceProvider.GetService<ServicoReceita>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(ServicoReceita)}]");
            _servicoIngrediente = ServiceProvider.GetService<ServicoIngrediente>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(ServicoIngrediente)}]");
        }

        public List<Pocao> IniciarBancoMock()
        {
            List<int> listaDeIdIngredientes1 = new List<int> { 0, 1, 2, 3 };
            List<int> listaDeIdIngredientes2 = new List<int> { 0, 1, 2 };
            List<Receita> listaReceitaMock = new List<Receita>()
            {
                new Receita{
                Nome = "receita de Cura",
                Descricao = "Deve curar",
                Imagem = "caminho da imagem",
                Valor = 20.00m,
                ValidadeEmMeses = 4,
                ListaDeIdIngredientes = listaDeIdIngredientes1},

                new Receita{
                Nome = "receita de Força",
                Descricao = "Te da Força",
                Imagem = "caminho da imagem",
                Valor = 15.00m,
                ValidadeEmMeses = 4,
                ListaDeIdIngredientes = listaDeIdIngredientes2}
            };

            foreach (var item in listaReceitaMock)
            {
                _servicoReceita.CriarReceita(item);
            }

            List<Ingrediente> listaIngredientes = new List<Ingrediente>
            {
                new Ingrediente
                {
                    Nome = "Pote com água",
                    Naturalidade = Naturalidade.OverWorld,
                    Quantidade = 5
                },

                new Ingrediente
                {
                    Nome = "Fungo do Nether",
                    Naturalidade = Naturalidade.Nether,
                    Quantidade = 6
                },

                new Ingrediente
                {
                    Nome = "Pó de blase",
                    Naturalidade = Naturalidade.Nether,
                    Quantidade = 3
                },

                new Ingrediente
                {
                    Nome = "Melão dourado",
                    Naturalidade = Naturalidade.OverWorld,
                    Quantidade = 4
                }
            };
            foreach (var ingrediente in listaIngredientes)
            {
                _servicoIngrediente.CriarIngrediente(ingrediente);
            }

            var listaIngredientesParaCura = listaIngredientes.Take(4).ToList();
            var listaIngredientesParaForca = listaIngredientes.Take(3).ToList();

            _servicoPocao.CriarPocao(listaIngredientesParaCura);
            _servicoPocao.CriarPocao(listaIngredientesParaForca);

            List<Pocao> listaMock = _servicoPocao.ObterTodos();
            return listaMock;
        }

        //Obter todos
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

        //ObterPorID
        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarPocaoEsperada()
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
        public void ObterPorId_ComDadosValidos_DeveRetornarPocaoDesejada()
        {
            int idDaReceitaDeCura = 0;

            _pocaoParaTeste = new Pocao()
            {
                IdReceita = idDaReceitaDeCura,
                DataDeFabricação = DateTime.Today,
                Vencido = false
            };

            var pocaoDoBanco = _servicoPocao.ObterPorId(idDaReceitaDeCura);

            Assert.Equivalent(_pocaoParaTeste, pocaoDoBanco);
        }

        [Fact]
        public void CriarPocao_ComDadosInvalidos_DeveLancarExecaoEsperada()
        {
            List<Ingrediente> listaIngredientes = _servicoIngrediente.ObterTodos().Take(2).ToList();

            var excecao = Assert.Throws<Exception>(() => _servicoPocao.CriarPocao(listaIngredientes));

            Assert.Equal("Receita não encontrada", excecao.Message);
        }
    }
}

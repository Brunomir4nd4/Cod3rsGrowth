﻿using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Teste.ConfiguracaoAmbienteTeste;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Cod3rsGrowth.Dominio.Enums;
using LinqToDB;

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
        private Receita _receitaParaTeste;
        public TestePocao()
        {
            CarregarServico();
            _servicoIngrediente.ObterTodos().Clear();
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
            List<Ingrediente> listaIngredientes = new List<Ingrediente>
            {
                new()
                {
                    Nome = "Pote com água",
                    Naturalidade = Naturalidade.OverWorld,
                    Quantidade = 5
                },

                new()
                {
                    Nome = "Fungo do Nether",
                    Naturalidade = Naturalidade.Nether,
                    Quantidade = 6
                },

                new()
                {
                    Nome = "Pó de blase",
                    Naturalidade = Naturalidade.Nether,
                    Quantidade = 3
                },

                new()
                {
                    Nome = "Melão dourado",
                    Naturalidade = Naturalidade.OverWorld,
                    Quantidade = 4
                }
            };
            foreach (var ingrediente in listaIngredientes)
            {
                _servicoIngrediente.Criar(ingrediente);
            }

            int quantidadeDeIngredientes1 = 4, quantidadeDeIngredientes2 = 3;
            var listaIngredientesParaCura = listaIngredientes.Take(quantidadeDeIngredientes1).ToList();
            var listaIngredientesParaForca = listaIngredientes.Take(quantidadeDeIngredientes2).ToList();
            List<int> listaIdIngredientesParaCura = new List<int> { 0, 1, 2, 3 };
            List<int> listaIdIngredientesParaForca = new List<int> { 0, 1, 2 };

            List<Receita> listaReceitaMock = new List<Receita>()
            {
                new()
                {
                    Nome = "receita de Cura",
                    Descricao = "Deve curar",
                    Imagem = "caminho da imagem",
                    Valor = 20.00m,
                    ValidadeEmMeses = 4,
                    ListaIdIngrediente = listaIdIngredientesParaCura
                },

                new()
                {
                    Nome = "receita de Força",
                    Descricao = "Te da Força",
                    Imagem = "caminho da imagem",
                    Valor = 15.00m,
                    ValidadeEmMeses = 4,
                    ListaIdIngrediente = listaIdIngredientesParaForca
                }
            };

            foreach (var receita in listaReceitaMock)
            {
                _servicoReceita.Criar(receita);
            }

            _servicoPocao.Criar(listaIngredientesParaCura);
            _servicoPocao.Criar(listaIngredientesParaForca);

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
            var idDeBusca = _listaMock.FirstOrDefault().Id;
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
            Assert.Equal($"O objeto com id [{idInexistente}] não foi encontrado", excecao.Message);
        }

        [Fact]
        public void ObterPorId_ComDadosValidos_DeveRetornarPocaoDesejada()
        {
            int idDaPocaoDeCura = 0;

            _pocaoParaTeste = new Pocao()
            {
                Id = idDaPocaoDeCura,
                IdReceita = 0,
                DataDeFabricacao = DateTime.Today,
                Vencido = false
            };

            var pocaoDoBanco = _servicoPocao.ObterPorId(idDaPocaoDeCura);

            Assert.Equivalent(_pocaoParaTeste, pocaoDoBanco);
        }

        [Fact]
        public void CriarPocao_ComDadosInvalidos_DeveLancarExecaoEsperada()
        {
            int quantidadeDeIngredientes = 2;
            List<Ingrediente> listaIngredientes = _servicoIngrediente.ObterTodos().Take(quantidadeDeIngredientes).ToList();

            var excecao = Assert.Throws<Exception>(() => _servicoPocao.Criar(listaIngredientes));

            Assert.Equal("Impossível criar uma poção com os ingredientes selecionados!", excecao.Message);
        }

        [Fact]
        public void RemoverPocao_ComPocaoExistente_DeveRetornarResultadoEsperado()
        {
            _pocaoParaTeste = _listaMock.FirstOrDefault();

           _servicoPocao.Remover(_pocaoParaTeste.Id);

            var excecao = Assert.Throws<Exception>(() => _servicoPocao.Remover(_pocaoParaTeste.Id));

            Assert.Equal($"O objeto com id [{_pocaoParaTeste.Id}] não foi encontrado", excecao.Message);
        }
    }
}

using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Teste.ConfiguracaoAmbienteTeste;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
namespace Cod3rsGrowth.Teste
{
    public class TesteReceita : TesteBase
    {
        private ServicoReceita _servicoReceita;
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
            _servicoReceita = ServiceProvider.GetService<ServicoReceita>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(ServicoReceita)}]");
        }

        public List<Receita> IniciarBancoMock()
        {
            List<int> listaDeIdIngredientes1 = new List<int> { 0, 1, 2, 3 };
            List<int> listaDeIdIngredientes2 = new List<int> { 0, 1, 2 };
            List<Receita> bancoMock = new List<Receita>()
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

            foreach (var item in bancoMock)
            {
                _servicoReceita.CriarReceita(item);
            }
            return bancoMock;
        }

        //Obter todos
        [Fact]
        public void ObterTodos_ComUmaListaValida_DeveRetornarUmaListaDoTipoReceita()
        {
            var listaReceita = _servicoReceita.ObterTodos();
            Assert.IsType<List<Receita>>(listaReceita);
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveSerEquivalenteAUmaListaDeReceita()
        {
            _listaDoBanco = _servicoReceita.ObterTodos();

            Assert.Equivalent(_listaMock, _listaDoBanco);
        }

        //ObterPorID
        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarReceitaEsperada()
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
        public void ObterPorId_ComIdExistente_DeveRetornarObjetoTypeReceita()
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

        //Criar
        [Theory]
        [InlineData("12324321")]
        [InlineData("@#$%&#5*")]
        [InlineData("wdada!@!#!@1231")]
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

            Assert.Equal("Campo Nome deve conter apenas letras!", excecao.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("      ")]
        [InlineData("")]
        public void CriarReceita_ComNomeVazio_DeveRetornarMensagemDeErroEsperada(string nome)
        {
            _receitaParaTeste = new Receita()
            {
                Nome = nome,
                Descricao = "Decrição A",
                ValidadeEmMeses = 4,
                Valor = 20.22m
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.CriarReceita(_receitaParaTeste));

            Assert.Equal("Campo Nome não preenchido!", excecao.Message);
        }

        //Descrição
        [Theory]
        [InlineData(null)]
        [InlineData("      ")]
        [InlineData("")]
        public void CriarReceita_ComDescricaoVazia_DeveRetornarMensagemDeErroEsperada(string descricao)
        {
            _receitaParaTeste = new Receita()
            {
                Nome = "Pocao A",
                Descricao = descricao,
                ValidadeEmMeses = 4,
                Valor = 20.22m
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.CriarReceita(_receitaParaTeste));

            Assert.Equal("Campo Descrição não preenchido!", excecao.Message);
        }

        [Fact]
        public void CriarReceita_ComDescricaoComOverFlow_DeveRetornarMensagemDeErroEsperada()
        {
            _receitaParaTeste = new Receita()
            {
                Nome = "Receita A",
                Descricao = "Faz o modelo do jogador desaparecer. Os mobs agirão neutralmente em relação ao jogador, a menos que o jogador esteja usando uma armadura (Veja efeitos de estado para detalhes sobre armadura). Na forma arremessável é capaz de fazer mobs ou outros jogadores invisíveis. Armadura, itens na mão, flechas presas no jogador, uma sela de porco, um padrão de tapete de lhama, uma cabeça amareça de shulker e os olhos das aranhas e endermans não são afetados e ainda são visíveis.Faz o modelo do jogador desaparecer. Os mobs agirão neutralmente em relação ao jogador, a menos que o jogador esteja usando uma armadura (Veja efeitos de estado para detalhes sobre armadura). Na forma arremessável é capaz de fazer mobs ou outros jogadores invisíveis. Armadura, itens na mão, flechas presas no jogador, uma sela de porco, um padrão de tapete de lhama, uma cabeça amareça de shulker e os olhos das aranhas e endermans não são afetados e ainda são visíveis.",
                ValidadeEmMeses = 4,
                Valor = 20.22m
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.CriarReceita(_receitaParaTeste));

            Assert.Equal("Campo Descrição deve ter no máximo 500 caracters!", excecao.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        public void CriarReceita_ComValorVazia_DeveRetornarMensagemDeErroEsperada(decimal valor)
        {
            _receitaParaTeste = new Receita()
            {
                Nome = "Pocao A",
                Descricao = "Descrição A",
                ValidadeEmMeses = 4,
                Valor = valor
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.CriarReceita(_receitaParaTeste));

            Assert.Equal("Campo Valor não preenchido!", excecao.Message);
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

        //Editar

        [Fact]
        public void EditarReceita_ComDadosValidos_DeveRetornarIngredienteEditadoEsperado()
        {
            _receitaParaTeste = new Receita()
            {
                Id = 1,
                Nome = "Receita Editada",
                Descricao = "Descrição A",
                ValidadeEmMeses = 4,
                Valor = 99
            };

            var ingredienteEditado = _servicoReceita.EditarReceita(_receitaParaTeste);

            Assert.Equivalent(_receitaParaTeste, ingredienteEditado);
        }

        [Theory]
        [InlineData("37297")]
        [InlineData("@!*#&@!")]
        [InlineData("@D3scricao_3ditad0")]
        [InlineData("👌👌")]
        public void EditarReceita_ComNomeInvalido_DeveLancarExcecaoEsperada(string nome)
        {
            _receitaParaTeste = new Receita()
            {
                Id = 1,
                Nome = nome,
                Descricao = "Descrição A",
                ValidadeEmMeses = 4,
                Valor = 99
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.EditarReceita(_receitaParaTeste));

            Assert.Equal("Campo Nome deve conter apenas letras!", excecao.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("  ")]
        [InlineData("")]
        public void EditarReceita_ComNomeVazio_DeveLancarExcecaoEsperada(string nome)
        {
            _receitaParaTeste = new Receita()
            {
                Id = 1,
                Nome = nome,
                Descricao = "Descrição A",
                ValidadeEmMeses = 4,
                Valor = 99
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.EditarReceita(_receitaParaTeste));

            Assert.Equal("Campo Nome não preenchido!", excecao.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("  ")]
        [InlineData("")]
        public void EditarReceita_ComDescricaoVazia_DeveLancarExcecaoEsperada(string descricao)
        {
            _receitaParaTeste = new Receita()
            {
                Id = 1,
                Nome = "Receita Editada",
                Descricao = descricao,
                ValidadeEmMeses = 4,
                Valor = 99
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.EditarReceita(_receitaParaTeste));

            Assert.Equal("Campo Descrição não preenchido!", excecao.Message);
        }

        [Fact]
        public void EditarReceita_ComDescricaoComOverFlow_DeveRetornarMensagemDeErroEsperada()
        {
            _receitaParaTeste = new Receita()
            {
                Id = 1,
                Nome = "Receita A",
                Descricao = "Faz o modelo do jogador desaparecer. Os mobs agirão neutralmente em relação ao jogador, a menos que o jogador esteja usando uma armadura (Veja efeitos de estado para detalhes sobre armadura). Na forma arremessável é capaz de fazer mobs ou outros jogadores invisíveis. Armadura, itens na mão, flechas presas no jogador, uma sela de porco, um padrão de tapete de lhama, uma cabeça amareça de shulker e os olhos das aranhas e endermans não são afetados e ainda são visíveis.Faz o modelo do jogador desaparecer. Os mobs agirão neutralmente em relação ao jogador, a menos que o jogador esteja usando uma armadura (Veja efeitos de estado para detalhes sobre armadura). Na forma arremessável é capaz de fazer mobs ou outros jogadores invisíveis. Armadura, itens na mão, flechas presas no jogador, uma sela de porco, um padrão de tapete de lhama, uma cabeça amareça de shulker e os olhos das aranhas e endermans não são afetados e ainda são visíveis.",
                ValidadeEmMeses = 4,
                Valor = 20.22m
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.EditarReceita(_receitaParaTeste));

            Assert.Equal("Campo Descrição deve ter no máximo 500 caracters!", excecao.Message);
        }

        [Fact]
        public void EditarReceita_ComValidadeEmMesesNegativa_DeveLancarExcecaoEsperada()
        {
            _receitaParaTeste = new Receita()
            {
                Id = 1,
                Nome = "Receita Editada",
                Descricao = "Descrição A",
                ValidadeEmMeses = -4,
                Valor = 9,
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.EditarReceita(_receitaParaTeste));

            Assert.Equal("Campo Validade em meses deve ser maior ou igual a 1", excecao.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        public void EditarReceita_ComValorVazia_DeveRetornarMensagemDeErroEsperada(decimal valor)
        {
            _receitaParaTeste = new Receita()
            {
                Id = 1,
                Nome = "Pocao A",
                Descricao = "Descrição A",
                ValidadeEmMeses = 4,
                Valor = valor
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.EditarReceita(_receitaParaTeste));

            Assert.Equal("Campo Valor não preenchido!", excecao.Message);
        }

        [Fact]
        public void EditarReceita_ComValorNegativo_DeveRetornarMensagemDeErroEsperada()
        {
            _receitaParaTeste = new Receita()
            {
                Id = 1,
                Nome = "Receita A",
                Descricao = "Descrição A",
                ValidadeEmMeses = 4,
                Valor = -99
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoReceita.EditarReceita(_receitaParaTeste));

            Assert.Equal("Campo Valor deve ser maior que 0", excecao.Message);
        }
    }   
}

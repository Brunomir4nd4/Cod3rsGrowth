using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoPocao
    {
        private readonly IRepositorioPocao _repositorioPocao;
        private readonly IRepositorioReceita _repositorioReceita;
        private ServicoIngrediente _servicoIngrediente;
        public ServicoPocao(
            IRepositorioPocao repositorioPocao, 
            IRepositorioReceita repositorioReceita,
            ServicoIngrediente servicoIngrediente
            )
        {
            _repositorioPocao = repositorioPocao;
            _repositorioReceita = repositorioReceita;
            _servicoIngrediente = servicoIngrediente;
        }

        public List<FiltroPocao> ObterTodos(FiltroPocao? filtroPocao)
        {
            return _repositorioPocao.ObterTodos(filtroPocao);
        }

        public FiltroPocao ObterPorId(int? id)
        {
            return _repositorioPocao.ObterPorId(id);
        }

        public int Criar(List<Ingrediente> ingredientesSelecionados)
        {
            const int quantidadeMinimaDeIngrediente = 0;
            List<Ingrediente> ingredientesInvalidos = ingredientesSelecionados
                .Where(i => i.Quantidade == quantidadeMinimaDeIngrediente)
                .ToList();

            if (ingredientesInvalidos.Any())
            {
                var erros = string.Join(", ", ingredientesInvalidos.Select(i => $"Ingrediente {i.Nome} em falta!"));
                throw new Exception(erros);
            }

            List<Receita> receitasCadastradas = _repositorioReceita.ObterTodos(null);

            var listaIdIngrediente = ingredientesSelecionados.Select(i => i.Id).ToList();

            Receita receita = receitasCadastradas
                .Where(r => r.ListaIdIngrediente.SequenceEqual(listaIdIngrediente))
                .FirstOrDefault()
                ?? throw new Exception("Impossível criar uma poção com os ingredientes selecionados!");

            ingredientesSelecionados.ForEach(i => {
                i.Quantidade--;
                _servicoIngrediente.Editar(i);
            });

            return _repositorioPocao.Criar(receita);
        }

        public void Remover(int? intPocaoSelecionada)
        {
            _repositorioPocao.Remover(intPocaoSelecionada);
        }
    }
}

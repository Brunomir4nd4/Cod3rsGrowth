using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoPocao
    {
        private readonly IRepositorioPocao _repositorioPocao;
        private readonly IRepositorioReceita _repositorioReceita;
        private ServicoIngrediente _servicoIngrediente;
        private FiltroReceita _filtroReceita = new FiltroReceita();
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
        public List<FiltroPocao> ObterTodos(FiltroPocao filtroPocao)
        {
            return _repositorioPocao.ObterTodos(filtroPocao);
        }
        public FiltroPocao ObterPorId(int? id)
        {
            return _repositorioPocao.ObterPorId(id);
        }
        public void CriarPocao(List<Ingrediente> ingredientesSelecionados)
        {
            int quantidadeMinimaDeIngrediente = 0;
            List<Ingrediente> ingredientesInvalidos = ingredientesSelecionados.Where(ingrediente => ingrediente.Quantidade == quantidadeMinimaDeIngrediente).ToList();

            if (ingredientesInvalidos.Any())
            {
                var erros = string.Join(", ", ingredientesInvalidos.Select(i => $"Ingrediente {i.Nome} em falta!"));
                throw new Exception(erros);
            }

            List<Receita> receitasCadastradas = _repositorioReceita.ObterTodos(_filtroReceita);

            var listaIdIngrediente = ingredientesSelecionados.Select(r => r.Id).ToList();

            Receita receita = receitasCadastradas.Where(receita => receita.ListaIdIngrediente.SequenceEqual(listaIdIngrediente)).FirstOrDefault()
                ?? throw new Exception("Impossível criar uma poção com os ingredientes selecionados!");

            ingredientesSelecionados.ForEach(i => {
                i.Quantidade--;
                _servicoIngrediente.EditarIngrediente(i);
            });

            _repositorioPocao.Criar(receita);
        }
        public void RemoverPocao(int? intPocaoSelecionada)
        {
            _repositorioPocao.Remover(intPocaoSelecionada);
        }
    }
}

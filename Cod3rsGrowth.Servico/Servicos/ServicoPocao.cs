using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoPocao
    {
        private readonly IRepositorioPocao _repositorioPocao;
        private readonly IRepositorioReceita _repositorioReceita;
        public ServicoPocao(IRepositorioPocao repositorioPocao, IRepositorioReceita repositorioReceita)
        {
            _repositorioPocao = repositorioPocao;
            _repositorioReceita = repositorioReceita;
        }
        public List<Pocao> ObterTodos()
        {
            return _repositorioPocao.ObterTodos();
        }
        public Pocao ObterPorId(int id)
        {
            return _repositorioPocao.ObterPorId(id);
        }
        public void CriarPocao(List<Ingrediente> ingredientesSelecionados)
        {
            int quantidadeMinimaDeIngrediente = 0;
            List<Ingrediente> ingredientesInvalidos = ingredientesSelecionados.Where(ingrediente => ingrediente.Quantidade < quantidadeMinimaDeIngrediente).ToList();

            if (ingredientesInvalidos.Any())
            {
                var erros = string.Join(", ", ingredientesInvalidos.Select(i => $"Ingrediente {i.Nome} em falta!"));
                throw new Exception(erros);
            }

            List<Receita> receitasCadastradas = _repositorioReceita.ObterTodos(new FiltroReceita());

            Receita Receita = receitasCadastradas.FirstOrDefault(receita => receita.ListaDeIngredientes.SequenceEqual(ingredientesSelecionados))
                ?? throw new Exception("Impossível criar uma poção com os ingredientes selecionados!");

            _repositorioPocao.Criar(Receita);
        }
        public void RemoverPocao(int intPocaoSelecionada)
        {
            _repositorioPocao.Remover(intPocaoSelecionada);
        }
    }
}

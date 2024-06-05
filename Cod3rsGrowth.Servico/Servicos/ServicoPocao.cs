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
        public Pocao ObterPorId(int idDeBusca)
        {
            return _repositorioPocao.ObterPorId(idDeBusca);
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

            List<Receita> receitasCadastradas = _repositorioReceita.ObterTodos();
            List<int> listaIdIngrediente = ingredientesSelecionados.Select(item => item.Id).ToList();

            Receita novaReceita = receitasCadastradas.FirstOrDefault(receita => receita.ListaDeIdIngredientes.SequenceEqual(listaIdIngrediente))
                ?? throw new Exception("Impossível criar uma poção com os ingredientes selecionados!");

            _repositorioPocao.Criar(novaReceita);
        }
        public void RemoverPocao(Pocao pocaoSelecionada)
        {
            _repositorioPocao.Remover(pocaoSelecionada);
        }
    }
}

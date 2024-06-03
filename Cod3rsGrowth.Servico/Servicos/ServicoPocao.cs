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
            var ingredientesInvalidos = ingredientesSelecionados.Where(i => i.Quantidade < 0).ToList();
            if (ingredientesInvalidos.Count > 0)
            {
            //Fazer teste aqui
                var erros = string.Join(", ", ingredientesInvalidos.Select(i => $"Ingrediente {i.Nome} em falta!"));
                throw new Exception(erros);
            }
            List<Receita> receitasCadastradas = _repositorioReceita.ObterTodos();
            List<int> listaIdIngrediente = ingredientesSelecionados.Select(item => item.Id).ToList();
            var receita = receitasCadastradas.Where(receita => receita.ListaDeIdIngredientes == listaIdIngrediente).FirstOrDefault()
                ?? throw new Exception("Receita procurada não existe!");
            _repositorioPocao.Criar(receita);
        }
        public void RemoverPocao()
        {
        }
    }
}

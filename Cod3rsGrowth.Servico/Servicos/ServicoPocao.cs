using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using FluentValidation;

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
                var erros = string.Join(", ", ingredientesInvalidos.Select(i => $"Ingrediente {i.Nome} em falta!"));
                throw new Exception(erros);
            }
            var listaReceita = _repositorioReceita.ObterTodos();
            var listaIdIngrediente = ingredientesSelecionados.Select(item => item.Id);
            Receita receitaIdentificada = new Receita();
            foreach (var receitaDaLista in listaReceita)
            {
                if (receitaDaLista.ListaDeIdIngredientes == listaIdIngrediente)
                {
                    receitaIdentificada = receitaDaLista;
                }
            }
            _repositorioPocao.Criar(receitaIdentificada);
        }
        public void RemoverPocao()
        {
        }
    }
}

using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Teste.Repositorios
{
    internal class RepositorioIngredienteMock : IRepositorioIngrediente
    {
        private List<Ingrediente> _listaIngredientes = ListaSingleton.getInstance.listaIngrediente;
        private int _novoId = 0;
        public List<Ingrediente> ObterTodos(FiltroIngrediente ingrediente)
        {
            return _listaIngredientes;
        }

        public Ingrediente ObterPorId(int idProcurado)
        {
            return _listaIngredientes.Find(objeto => objeto.Id == idProcurado)
                ?? throw new Exception($"O objeto com id [{idProcurado}] não foi encontrado");
        }

        public void Criar(Ingrediente ingrediente)
        {
            ingrediente.Id = _novoId;
            _novoId++;
            _listaIngredientes.Add(ingrediente);
        }
        public Ingrediente Editar(Ingrediente ingredienteEditado)
        {
            var ingredienteDoBanco = ObterPorId(ingredienteEditado.Id);

            ingredienteDoBanco.Nome = ingredienteEditado.Nome;
            ingredienteDoBanco.Naturalidade = ingredienteEditado.Naturalidade;
            ingredienteDoBanco.Quantidade = ingredienteEditado.Quantidade;

            return ingredienteDoBanco;
        }
        public void Remover(int idIngrediente)
        {
            var ingredienteRemovidoDoBanco = ObterPorId(idIngrediente);

            _listaIngredientes.Remove(ingredienteRemovidoDoBanco);
        }
    }
}

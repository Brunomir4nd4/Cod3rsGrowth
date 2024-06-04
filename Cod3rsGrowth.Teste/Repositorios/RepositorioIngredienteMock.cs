using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Teste.Repositorios
{
    internal class RepositorioIngredienteMock : IRepositorioIngrediente
    {
        private List<Ingrediente> _listaIngredientes = ListaSingleton.getInstance.listaIngrediente;
        private int _novoId = 0;
        public List<Ingrediente> ObterTodos()
        {
            return _listaIngredientes;
        }

        public Ingrediente ObterPorId(int idProcurado)
        {
            return _listaIngredientes.Find(objeto => objeto.Id == idProcurado)
                ?? throw new Exception($"O objeto com id {idProcurado} não foi encontrado");
        }

        public void Criar(Ingrediente ingrediente)
        {
            ingrediente.Id = _novoId;
            _novoId++;
            _listaIngredientes.Add(ingrediente);
        }
        public Ingrediente Editar(Ingrediente ingredienteEditado)
        {
            int flagIndexNaoEncontrado = -1;
            var indexIngredienteEditado = ObterTodos().FindIndex(e => e.Id == ingredienteEditado.Id) != flagIndexNaoEncontrado
                ?
                ObterTodos().FindIndex(e => e.Id == ingredienteEditado.Id)
                :
                throw new Exception("Ingrediente informado não encontrado!");

            _listaIngredientes[indexIngredienteEditado] = ingredienteEditado;
            return _listaIngredientes[indexIngredienteEditado]; 
        }
    }
}

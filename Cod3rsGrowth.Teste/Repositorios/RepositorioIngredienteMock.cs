using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Teste.Repositorios
{
    internal class RepositorioIngredienteMock : IRepositorioIngrediente
    {
        public List<Ingrediente> listaIngredientes = ListaSingleton.getInstance.listaIngrediente;

        public List<Ingrediente> ObterTodos()
        {
            return listaIngredientes;
        }

        public Ingrediente ObterPorId(int idProcurado)
        {
            return listaIngredientes.Find(objeto => objeto.Id == idProcurado)
                ?? throw new Exception($"O objeto com id {idProcurado} não foi encontrado");
        }

        public void Criar(Ingrediente ingrediente)
        {
            listaIngredientes.Add(ingrediente);
        }
    }
}

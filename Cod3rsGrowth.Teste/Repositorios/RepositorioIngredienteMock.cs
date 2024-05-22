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

        public Ingrediente ObterPorId(int id)
        {
            int i;
            for (i = 0; i <  listaIngredientes.Count; i++)
            {
                if (listaIngredientes[i].Id == id)
                {
                    break;
                }
            }
            return listaIngredientes[i];
        }

        public void Criar(Ingrediente ingrediente)
        {
            listaIngredientes.Add(ingrediente);
        }
    }
}

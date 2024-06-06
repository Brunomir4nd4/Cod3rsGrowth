using Cod3rsGrowth.Dominio.Interface;
using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Repositorios
{
    internal class RepositorioIngrediente : IRepositorio<Ingrediente>
    {
        public List<Ingrediente> ObterTodos()
        {
            return ObterTodos();
        }

        public Ingrediente ObterPorId(int idProcurado)
        {
            return ObterPorId(idProcurado);
        }

        public void Criar(Ingrediente ingrediente)
        {
        }
        public Ingrediente Editar(Ingrediente ingredienteEditado)
        {
            return ingredienteEditado;
        }
        public void Remover(int idIngrediente)
        {

        }
    }
}

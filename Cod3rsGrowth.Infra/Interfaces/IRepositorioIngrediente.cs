using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interface;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioIngrediente : IRepositorio<Ingrediente>
    {
        List<Ingrediente> ObterTodos(Ingrediente ingrediente);
        Ingrediente ObterPorId(int id);
        void Criar(Ingrediente ingrediente);
        Ingrediente Editar(Ingrediente ingrediente);
        void Remover(int idIngrediente);
    }
}

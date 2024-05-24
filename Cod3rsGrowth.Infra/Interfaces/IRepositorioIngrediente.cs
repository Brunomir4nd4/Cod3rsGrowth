using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioIngrediente
    {
        List<Ingrediente> ObterTodos();
        Ingrediente ObterPorId(int id);
        void Criar(Ingrediente ingrediente);
    }
}

using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioIngrediente
    {
        List<Ingrediente> ObterTodos();
        void Criar(Ingrediente ingrediente);
    }
}

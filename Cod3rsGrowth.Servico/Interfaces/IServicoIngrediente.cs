using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Servico.Interfaces
{
    public interface IServicoIngrediente
    {
        List<Ingrediente> ObterTodos();
        void CriarIngrediente(Ingrediente ingrediente);
        void ObterPorldIngrediente();
        void EditarIngrediente();
        void RemoverIngredientes();
    }
}

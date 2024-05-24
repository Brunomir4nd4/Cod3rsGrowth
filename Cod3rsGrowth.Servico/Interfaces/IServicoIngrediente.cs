using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Servico.Interfaces
{
    public interface IServicoIngrediente
    {
        List<Ingrediente> ObterTodos();
        Ingrediente ObterPorId(int id);
        void CriarIngrediente(Ingrediente ingrediente);
        void EditarIngrediente();
        void RemoverIngredientes();
    }
}

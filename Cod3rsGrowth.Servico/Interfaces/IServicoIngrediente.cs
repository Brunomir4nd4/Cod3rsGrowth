using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Servico.Interfaces
{
    public interface IServicoIngrediente
    {
        public List<Ingrediente> ObterTodos();
        public void CriarIngrediente(Ingrediente ingrediente);
        public void ObterPorldIngrediente();
        public void EditarIngrediente();
        public void RemoverIngredientes();
    }
}

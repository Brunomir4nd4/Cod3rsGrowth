using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IRepositorioReceitaIngrediente
    {
        List<ReceitaIngrediente> ObterTodos();
        ReceitaIngrediente ObterPorId(int idProcurado);
        void Criar(List<int> listaDeIdIngrediente, int idReceita);
        void Remover(ReceitaIngrediente receitaIngrediente);
    }
}

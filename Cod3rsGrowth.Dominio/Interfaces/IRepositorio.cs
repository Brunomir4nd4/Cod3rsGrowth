using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IRepositorio<T, TFiltro> where TFiltro : IFiltro
    {
        List<T> ObterTodos(TFiltro objeto);
        T ObterPorId(int id);
        void Criar(T item);
        T Editar(T item);
        void Remover(int idItem);
    }
}

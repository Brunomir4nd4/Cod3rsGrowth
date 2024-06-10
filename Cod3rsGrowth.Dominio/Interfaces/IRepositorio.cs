using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Dominio.Interface
{
    public interface IRepositorio<T>
    {
        List<T> ObterTodos(T objeto);
        T ObterPorId(int id);
        void Criar(T item);
        T Editar(T item);
        void Remover(int idItem);
    }
}

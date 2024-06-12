using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interface;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioReceita : IRepositorio<Receita>

    {
        List<Receita> ObterTodos(Receita receita);
        Receita ObterPorId(int id);
        void Criar(Receita receita);
        Receita Editar(Receita receita);
        void Remover(int idReceita);
    }
}

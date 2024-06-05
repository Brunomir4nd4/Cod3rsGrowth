using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioReceita
    {
        List<Receita> ObterTodos();
        Receita ObterPorId(int id);
        void Criar(Receita receita);
        Receita Editar(Receita receita);
        void Remover(Receita receita);
    }
}

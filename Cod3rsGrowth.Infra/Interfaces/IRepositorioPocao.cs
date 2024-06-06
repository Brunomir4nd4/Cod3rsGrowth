using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioPocao
    {
        List<Pocao> ObterTodos();
        Pocao ObterPorId(int id);
        void Criar(Receita receita);
        void Remover(int idPocao);
    }
}

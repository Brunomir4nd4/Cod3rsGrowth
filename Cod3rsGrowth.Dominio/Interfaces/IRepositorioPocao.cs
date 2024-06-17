using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IRepositorioPocao
    {
        List<Pocao> ObterTodos(FiltroPocao filtroPocao);
        Pocao ObterPorId(int id);
        void Criar(Receita receita);
        void Remover(int idPocao);
    }
}

using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IRepositorioPocao
    {
        List<Pocao> ObterTodos(FiltroPocao? Pocao);
        List<Pocao> ObterTodos();
        Pocao ObterPorId(int? id);
        int Criar(Receita receita);
        void Remover(int? idPocao);
    }
}

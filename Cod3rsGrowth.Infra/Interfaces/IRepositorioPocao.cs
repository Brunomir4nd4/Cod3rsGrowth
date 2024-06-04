using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioPocao
    {
        List<Pocao> ObterTodos();
        Pocao ObterPorId(int id);
        void Criar(Receita receita);
    }
}

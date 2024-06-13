using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioReceita : IRepositorio<Receita, FiltroReceita>
    {
    }
}

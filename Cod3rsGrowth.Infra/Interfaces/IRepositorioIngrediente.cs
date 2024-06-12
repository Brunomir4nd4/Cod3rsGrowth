using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interface;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioIngrediente : IRepositorio<Ingrediente, FiltroIngrediente>
    {
    }
}

using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Dominio.Entidades
{
    public class FiltroIngrediente : IFiltro
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public int? Quantidade { get; set; }
        public Naturalidade? Naturalidade { get; set; }
    }
}

using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Dominio.Entidades
{
    public class FiltroPocao : IFiltro
    {
        public int? Id { get; set; }
        public int? IdReceita { get; set; }
        public DateTime? DataDeFabricação { get; set; }
        public bool? Vencido { get; set; }
    }
}

using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Dominio.Entidades
{
    public class FiltroPocao : IFiltro
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataDeFabricacao { get; set; }
        public bool? Vencido { get; set; }
    }
}

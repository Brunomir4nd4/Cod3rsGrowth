namespace Cod3rsGrowth.Dominio.Entidades
{
    public class Pocao
    {
        public int Id {  get; set; }
        public int IdReceita { get; set; }
        public DateTime DataDeFabricação { get; set; }
        public bool Vencido { get; set; }
    }
}

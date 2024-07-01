using LinqToDB.Mapping;

namespace Cod3rsGrowth.Dominio.Entidades
{
    [Table("Pocao")]
    public class Pocao
    {
        [PrimaryKey, Identity]
        public int Id {  get; set; }
        [Column("IdReceita")]
        public int IdReceita { get; set; }
        [Column("DataDeFabricacao")]
        public DateTime DataDeFabricacao { get; set; }
        [Column("Vencido")]
        public bool Vencido { get; set; }
    }
}

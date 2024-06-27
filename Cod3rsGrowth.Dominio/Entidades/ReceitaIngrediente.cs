using LinqToDB.Mapping;

namespace Cod3rsGrowth.Dominio.Entidades
{
    [Table("ReceitaIngrediente")]
    public class ReceitaIngrediente
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column("IdReceita")]
        public int IdReceita { get; set; }
        [Column("IdIngrediente")]
        public int IdIngrediente { get; set; }
    }
}

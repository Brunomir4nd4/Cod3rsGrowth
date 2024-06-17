using Cod3rsGrowth.Dominio.Enums;
using LinqToDB.Mapping;

namespace Cod3rsGrowth.Dominio.Entidades
{
    [Table("Ingrediente")]
   public class Ingrediente
    {
        [PrimaryKey, Identity]
        public int Id {  get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Quantidade")]
        public int Quantidade { get; set; }
        [Column("Naturalidade")]
        public Naturalidade Naturalidade { get; set; }
    }
}

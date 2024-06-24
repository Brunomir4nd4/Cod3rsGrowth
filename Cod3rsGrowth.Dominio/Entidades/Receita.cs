using LinqToDB.Mapping;

namespace Cod3rsGrowth.Dominio.Entidades
{
    [Table("Receita")]
    public class Receita
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Descricao")]
        public string Descricao { get; set; }
        [Column("Valor")]
        public decimal Valor { get; set; }
        [Column("Imagem")]
        public string? Imagem { get; set; }
        [Column("ValidadeEmMeses")]
        public int ValidadeEmMeses { get; set; }
        public List<int> ListaIdIngrediente { get; set; }
    }
}

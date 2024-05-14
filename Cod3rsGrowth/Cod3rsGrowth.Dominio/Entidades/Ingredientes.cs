using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio.Entidades
{
    public class Ingredientes
    {
        public static int Id { get; set; }
        public string Nome { get; set; }
        public int Qtd { get; set; }
        public Naturalidade Naturalidade;
    }
}

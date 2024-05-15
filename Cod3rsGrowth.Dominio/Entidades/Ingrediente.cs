using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio.Entidades
{
   public class Ingrediente
    {
        public int Id {  get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public Naturalidade Naturalidade { get; set; }
    }
}

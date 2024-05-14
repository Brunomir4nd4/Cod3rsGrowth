using Cod3rsGrowth.dominio.Enums;

namespace Cod3rsGrowth.dominio.Entidades
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Qtd { get; set; }
        public Naturalidade Naturalidade;

        public Ingrediente(int id, string nome, int qtd, Naturalidade naturalidade)
        {
            Id = id;
            Nome = nome;
            Qtd = qtd;
            Naturalidade = naturalidade;
        }
    }
}

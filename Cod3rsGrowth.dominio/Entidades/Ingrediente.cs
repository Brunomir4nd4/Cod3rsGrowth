using Cod3rsGrowth.dominio.Enums;

namespace Cod3rsGrowth.dominio.Entidades
{
    public class Ingrediente
    {
        public static int Id { get; set; }
        public string Nome { get; set; }
        public int Qtd { get; set; }
        public Naturalidade Naturalidade;
        public string Imagem { get; set; }

        public Ingrediente(int id, string nome, int qtd, Naturalidade naturalidade, string imagem)
        {
            Id = id;
            Nome = nome;
            Qtd = qtd;
            Naturalidade = naturalidade;
            Imagem = imagem;
        }
    }
}

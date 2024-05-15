namespace Cod3rsGrowth.Dominio.Entidades
{
    public class Pocao
    {
        public int Id {  get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set;}
        public decimal Valor { get; set; }
        public string Imagem { get; set; }
        public DateTime DataDeVencimento { get; set; }
        public bool Vencido { get; set; }
        public int Quantidade { get; set; }

    }
}

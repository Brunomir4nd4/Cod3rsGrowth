namespace Cod3rsGrowth.Dominio.Elementos
{
    internal class Pocao
    {
        public static int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDeVencimento { get; set; }
        public bool Vencido { get; set; }
        public decimal Valor { get; set; }
        public int Qtd { get; set; }
        public string Imagem { get; set; }
    }
}

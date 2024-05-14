﻿namespace Cod3rsGrowth.Dominio.Entidades
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

        public Pocao(int id, string nome, string descricao,
            DateTime dataDeVencimento, bool vencimento, decimal valor, int qtd, string imagem)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            DataDeVencimento = dataDeVencimento;
            Vencido = vencimento;
            Valor = valor;
            Qtd = qtd;
            Imagem = imagem;
        }
    }
}

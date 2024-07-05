using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migradores
{
    [Migration(20240703083000)]
    public class _20240703083000_PopulaDB : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Ingrediente").Row(new { Nome = "Pó do Blaze", Quantidade = 10, Naturalidade = 1 });
            Insert.IntoTable("Ingrediente").Row(new { Nome = "Olho de Aranha", Quantidade = 5, Naturalidade = 0 });
            Insert.IntoTable("Ingrediente").Row(new { Nome = "Lágrima de Ghast", Quantidade = 3, Naturalidade = 1 });
            Insert.IntoTable("Ingrediente").Row(new { Nome = "Pérola do End", Quantidade = 2, Naturalidade = 2 });
            Insert.IntoTable("Ingrediente").Row(new { Nome = "Pólvora", Quantidade = 15, Naturalidade = 0 });
            Insert.IntoTable("Ingrediente").Row(new { Nome = "Cenoura Dourada", Quantidade = 7, Naturalidade = 0 });
            Insert.IntoTable("Ingrediente").Row(new { Nome = "Melancia Reluzente", Quantidade = 4, Naturalidade = 0 });
            Insert.IntoTable("Ingrediente").Row(new { Nome = "Açúcar", Quantidade = 20, Naturalidade = 0 });
            Insert.IntoTable("Ingrediente").Row(new { Nome = "Peixe-globo", Quantidade = 6, Naturalidade = 0 });
            Insert.IntoTable("Ingrediente").Row(new { Nome = "Olho de Aranha Fermentado", Quantidade = 5, Naturalidade = 0 });

            Insert.IntoTable("Receita").Row(new { Nome = "Poção de Regeneração", Descricao = "+1 coração a cada 2s", Valor = 15.0m, ValidadeEmMeses = 6 });
            Insert.IntoTable("Receita").Row(new { Nome = "Poção de Cura", Descricao = "+2 corações", Valor = 10.0m, ValidadeEmMeses = 12 });
            Insert.IntoTable("Receita").Row(new { Nome = "Poção de Respirar embaixo d’água", Descricao = "Permite respirar dentro da água", Valor = 8.0m, ValidadeEmMeses = 3 });
            Insert.IntoTable("Receita").Row(new { Nome = "Poção de Visão noturna", Descricao = "Enxergar no escuro", Valor = 7.0m, ValidadeEmMeses = 3 });
            Insert.IntoTable("Receita").Row(new { Nome = "Poção de Força", Descricao = "+30% dano", Valor = 12.0m, ValidadeEmMeses = 4 });
            Insert.IntoTable("Receita").Row(new { Nome = "Poção de Resistência ao Fogo", Descricao = "Imunidade ao fogo e lava", Valor = 14.0m, ValidadeEmMeses = 5 });
            Insert.IntoTable("Receita").Row(new { Nome = "Poção de Agilidade", Descricao = "+20% velocidade", Valor = 9.5m, ValidadeEmMeses = 3 });
            Insert.IntoTable("Receita").Row(new { Nome = "Poção de Salto", Descricao = "+½ bloco de salto", Valor = 11.0m, ValidadeEmMeses = 4 });
            Insert.IntoTable("Receita").Row(new { Nome = "Poção de Queda Lenta", Descricao = "Elimina dano de queda", Valor = 13.0m, ValidadeEmMeses = 2 });

            Insert.IntoTable("Pocao").Row(new { IdReceita = 1, DataDeFabricacao = DateTime.Parse("21/01/2022"), Vencido = 1 });
            Insert.IntoTable("Pocao").Row(new { IdReceita = 2, DataDeFabricacao = DateTime.Parse("27/08/2023"), Vencido = 1 });
            Insert.IntoTable("Pocao").Row(new { IdReceita = 3, DataDeFabricacao = DateTime.Parse("02/05/2024"), Vencido = 0 });
            Insert.IntoTable("Pocao").Row(new { IdReceita = 4, DataDeFabricacao = DateTime.Parse("24/05/2020"), Vencido = 1 });
            Insert.IntoTable("Pocao").Row(new { IdReceita = 5, DataDeFabricacao = DateTime.Parse("29/04/2024"), Vencido = 0 });
            Insert.IntoTable("Pocao").Row(new { IdReceita = 6, DataDeFabricacao = DateTime.Parse("11/04/2022"), Vencido = 1 });
            Insert.IntoTable("Pocao").Row(new { IdReceita = 7, DataDeFabricacao = DateTime.Parse("02/06/2024"), Vencido = 0 });
            Insert.IntoTable("Pocao").Row(new { IdReceita = 8, DataDeFabricacao = DateTime.Parse("29/06/2024"), Vencido = 0 });
            Insert.IntoTable("Pocao").Row(new { IdReceita = 9, DataDeFabricacao = DateTime.Parse("10/05/2024"), Vencido = 0 });

            Insert.IntoTable("ReceitaIngrediente").Row(new { IdReceita = 1, IdIngrediente = 1 });
            Insert.IntoTable("ReceitaIngrediente").Row(new { IdReceita = 1, IdIngrediente = 2 });
            Insert.IntoTable("ReceitaIngrediente").Row(new { IdReceita = 1, IdIngrediente = 3 });
            Insert.IntoTable("ReceitaIngrediente").Row(new { IdReceita = 2, IdIngrediente = 2 });
            Insert.IntoTable("ReceitaIngrediente").Row(new { IdReceita = 2, IdIngrediente = 4 });
            Insert.IntoTable("ReceitaIngrediente").Row(new { IdReceita = 2, IdIngrediente = 5 });
            Insert.IntoTable("ReceitaIngrediente").Row(new { IdReceita = 3, IdIngrediente = 3 });
            Insert.IntoTable("ReceitaIngrediente").Row(new { IdReceita = 3, IdIngrediente = 1 });
            Insert.IntoTable("ReceitaIngrediente").Row(new { IdReceita = 5, IdIngrediente = 2 });
            Insert.IntoTable("ReceitaIngrediente").Row(new { IdReceita = 5, IdIngrediente = 5 });
            Insert.IntoTable("ReceitaIngrediente").Row(new { IdReceita = 6, IdIngrediente = 2 });
            Insert.IntoTable("ReceitaIngrediente").Row(new { IdReceita = 6, IdIngrediente = 3 });
            Insert.IntoTable("ReceitaIngrediente").Row(new { IdReceita = 6, IdIngrediente = 5 });
        }

        public override void Down()
        {
        }
    }
}

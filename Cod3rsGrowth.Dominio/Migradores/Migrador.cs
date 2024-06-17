using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migradores
{
    [Migration(20240611131000)]
    public class Migrador : Migration
    {
        public override void Up()
        {
            Create.Table("Ingrediente")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Quantidade").AsInt32().NotNullable()
                .WithColumn("Naturalidade").AsInt32().NotNullable();

            Create.Table("Receita")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Descricao").AsString().NotNullable()
                .WithColumn("Valor").AsDecimal().NotNullable()
                .WithColumn("ValidadeEmMeses").AsString().NotNullable()
                .WithColumn("Imagem").AsString().NotNullable()
                .WithColumn("ListaDeIngredientes").AsString().NotNullable();

            Create.Table("Pocao")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("IdReceita").AsInt32().NotNullable()
                .WithColumn("Vencido").AsBoolean().NotNullable()
                .WithColumn("DataDeFabricacao").AsDateTime().NotNullable();

        }

        public override void Down()
        {
            Delete.Table("Ingrediente");
            Delete.Table("Receita");
            Delete.Table("Pocao");
        }
    }
}


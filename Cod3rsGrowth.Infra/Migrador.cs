using FluentMigrator;

namespace Cod3rsGrowth.Infra
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
                .WithColumn("Imagem").AsString().NotNullable();

            Create.Table("Pocao")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("IdReceita").AsInt32().NotNullable()
                .WithColumn("Vencido").AsBoolean().NotNullable()
                .WithColumn("DataDeFabricacao").AsDateTime().NotNullable();

            Create.Table("ReceitaIngrediente")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("ReceitaId").AsInt32().NotNullable().ForeignKey("Receita", "Id")
                .WithColumn("IngredienteId").AsInt32().NotNullable().ForeignKey("Ingrediente", "Id");

            Create.ForeignKey("fk_Receita")
                .FromTable("ReceitaIngrediente").ForeignColumn("ReceitaId")
                .ToTable("Receita").PrimaryColumn("Id");

            Create.ForeignKey("fk_Ingrediente")
                .FromTable("ReceitaIngrediente").ForeignColumn("IngredienteId")
                .ToTable("Ingrediente").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.Table("Ingrediente");
            Delete.Table("Receita");
            Delete.Table("Pocao");
            Delete.Table("Receita_Ingrediente");
        }
    }
}


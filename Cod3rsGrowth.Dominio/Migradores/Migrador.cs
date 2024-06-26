using FluentMigrator;
using System.Data;

namespace Cod3rsGrowth.Dominio.Migradores
{
    [Migration(20240624091100)]
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
                .WithColumn("Imagem").AsString().NotNullable();

            Create.Table("Pocao")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("IdReceita").AsInt32().ForeignKey().Nullable()
                .WithColumn("Vencido").AsBoolean().NotNullable()
                .WithColumn("DataDeFabricacao").AsDateTime().NotNullable();

            Create.Table("ReceitaIngrediente")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("IdReceita").AsInt32().ForeignKey().NotNullable()
                .WithColumn("IdIngrediente").AsInt32().ForeignKey().NotNullable();

            Create.ForeignKey("fk_IdReceita_Para_Pocao")
            .FromTable("Pocao").ForeignColumn("IdReceita")
            .ToTable("Receita").PrimaryColumn("Id")
            .OnDelete(Rule.SetNull)
            .OnUpdate(Rule.Cascade);
            
            Create.ForeignKey("fk_IdReceita_Para_ReceitaIngrediente")
            .FromTable("ReceitaIngrediente").ForeignColumn("IdReceita")
            .ToTable("Receita").PrimaryColumn("Id")
            .OnDeleteOrUpdate(Rule.Cascade);

            Create.ForeignKey("fk_IdIngrediente_Para_ReceitaIngrediente")
            .FromTable("ReceitaIngrediente").ForeignColumn("IdIngrediente")
            .ToTable("Ingrediente").PrimaryColumn("Id")
            .OnDeleteOrUpdate(Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("Ingrediente");
            Delete.Table("Receita");
            Delete.Table("Pocao");
        }
    }
}


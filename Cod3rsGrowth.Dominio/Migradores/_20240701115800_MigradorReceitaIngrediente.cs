using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migradores
{
    [Migration(20240701115800)]
    public class _20240701115800_MigradorReceitaIngrediente : Migration
    {
        public override void Up()
        {
            Create.Table("ReceitaIngrediente")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("IdReceita").AsInt32().ForeignKey().NotNullable()
                .WithColumn("IdIngrediente").AsInt32().ForeignKey().NotNullable();
            
            Create.ForeignKey("fk_IdReceita_Para_ReceitaIngrediente")
                .FromTable("ReceitaIngrediente").ForeignColumn("IdReceita")
                .ToTable("Receita").PrimaryColumn("Id")
                .OnDeleteOrUpdate(System.Data.Rule.Cascade);

            Create.ForeignKey("fk_IdIngrediente_Para_ReceitaIngrediente")
                .FromTable("ReceitaIngrediente").ForeignColumn("IdIngrediente")
                .ToTable("Ingrediente").PrimaryColumn("Id")
                .OnDeleteOrUpdate(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("ReceitaIngrediente");
        }
    }
}

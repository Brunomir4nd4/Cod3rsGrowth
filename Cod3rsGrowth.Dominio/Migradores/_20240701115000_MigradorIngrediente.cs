using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migradores
{
    [Migration(20240701115000)]
    public class _20240701115000_MigradorIngrediente : Migration
    {
        public override void Up()
        {
            Create.Table("Ingrediente")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Quantidade").AsInt32().NotNullable()
                .WithColumn("Naturalidade").AsInt32().NotNullable();
        }
        public override void Down()
        {
            Delete.Table("Ingrediente");
        }
    }
}

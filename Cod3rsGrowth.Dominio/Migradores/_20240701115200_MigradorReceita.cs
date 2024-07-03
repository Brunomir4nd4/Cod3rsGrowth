using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migradores
{
    [Migration(20240701115200)]
    public class _20240701115200_MigradorReceita : Migration
    {
        public override void Up()
        {
            Create.Table("Receita")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Descricao").AsString().NotNullable()
                .WithColumn("Valor").AsDecimal().NotNullable()
                .WithColumn("ValidadeEmMeses").AsString().NotNullable()
                .WithColumn("Imagem").AsString().NotNullable();
        }
        public override void Down()
        {
            Delete.Table("Receita");
        }
    }
}

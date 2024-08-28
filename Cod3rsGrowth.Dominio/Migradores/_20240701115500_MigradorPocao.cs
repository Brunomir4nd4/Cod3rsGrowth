using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migradores
{
    [Migration(20240701115500)]
    public class _20240701115500_MigradorPocao : Migration
    {
        public override void Up()
        {
            Create.Table("Pocao")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("IdReceita").AsInt32().ForeignKey().Nullable()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Vencido").AsBoolean().NotNullable()
                .WithColumn("DataDeFabricacao").AsDateTime().NotNullable();
            
            Create.ForeignKey("fk_IdReceita_Para_Pocao")
                .FromTable("Pocao").ForeignColumn("IdReceita")
                .ToTable("Receita").PrimaryColumn("Id")
                .OnDeleteOrUpdate(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("Pocao");
        }
    }
}

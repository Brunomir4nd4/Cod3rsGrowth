using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migrators
{
    [Migration(20240612094700)]
    public class AddListaIdIngredienteTable : Migration
    {
        public override void Up()
        {
            Create.Table("ListaIdIngrediente")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("ReceitaId").AsInt32().NotNullable().ForeignKey("Receita", "Id")
                .WithColumn("IngredienteId").AsInt32().NotNullable().ForeignKey("Ingrediente", "Id");
        }

        public override void Down()
        {
            Delete.Table("ListaIdIngrediente");
        }
    }
}
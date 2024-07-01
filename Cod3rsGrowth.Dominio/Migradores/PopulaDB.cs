
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cod3rsGrowth.Dominio.Migradores
{
    public class PopulaDB : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Ingrediente (Nome,Quantidade,Naturalidade) VALUES ('Pó Do Blaze',20,0)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Ingrediente");
        }
    }
}

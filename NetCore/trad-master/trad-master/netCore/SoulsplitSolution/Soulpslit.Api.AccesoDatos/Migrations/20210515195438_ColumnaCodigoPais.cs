using Microsoft.EntityFrameworkCore.Migrations;

namespace Soulsplit.Api.AccesoDatos.Migrations
{
    public partial class ColumnaCodigoPais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoPais",
                table: "Pais",
                type: "varchar",
                maxLength: 7,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoPais",
                table: "Pais");
        }
    }
}

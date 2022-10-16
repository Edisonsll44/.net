using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Soulsplit.Api.AccesoDatos.Migrations
{
    public partial class RelacionReferidoBanderaVerificaCelular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "VerificoCelular",
                table: "Usuario",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ReferidoId",
                table: "ReferidosPersona",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerificoCelular",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ReferidoId",
                table: "ReferidosPersona");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Soulsplit.Api.AccesoDatos.Migrations
{
    public partial class DireccionPersonaFotoString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FotoUsuario",
                table: "Usuario",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Persona",
                type: "varchar",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Persona");

            migrationBuilder.AlterColumn<byte[]>(
                name: "FotoUsuario",
                table: "Usuario",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true);
        }
    }
}

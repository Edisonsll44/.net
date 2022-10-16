using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Soulsplit.Api.AccesoDatos.Migrations
{
    public partial class TablaCuentas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NumeroCuenta = table.Column<string>(type: "varchar", maxLength: 30, nullable: true),
                    Nombres = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    Identificacion = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    TipoIdentificacion = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar", maxLength: 80, nullable: true),
                    BancoId = table.Column<Guid>(type: "uuid", nullable: false),
                    TipoCuentaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuenta_Banco_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Banco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cuenta_TipoCuenta_TipoCuentaId",
                        column: x => x.TipoCuentaId,
                        principalTable: "TipoCuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_BancoId",
                table: "Cuenta",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_TipoCuentaId",
                table: "Cuenta",
                column: "TipoCuentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuenta");
        }
    }
}

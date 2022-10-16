using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Soulsplit.Api.AccesoDatos.Migrations
{
    public partial class CambioColumnasPagos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pago_Banco_BancoId",
                table: "Pago");

            migrationBuilder.DropForeignKey(
                name: "FK_Pago_TipoCuenta_TipoCuentaId",
                table: "Pago");

            migrationBuilder.DropIndex(
                name: "IX_Pago_BancoId",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "BancoId",
                table: "Pago");

            migrationBuilder.RenameColumn(
                name: "TipoCuentaId",
                table: "Pago",
                newName: "CuentaId");

            migrationBuilder.RenameIndex(
                name: "IX_Pago_TipoCuentaId",
                table: "Pago",
                newName: "IX_Pago_CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_CodigoTipoCuenta",
                table: "TipoCuenta",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CodigoformaPago",
                table: "FormaPago",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CuentaBancoTipoCuenta",
                table: "Cuenta",
                columns: new[] { "NumeroCuenta", "BancoId", "TipoCuentaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CodigoBanco",
                table: "Banco",
                column: "Codigo",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_Cuenta_CuentaId",
                table: "Pago",
                column: "CuentaId",
                principalTable: "Cuenta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pago_Cuenta_CuentaId",
                table: "Pago");

            migrationBuilder.DropIndex(
                name: "IX_CodigoTipoCuenta",
                table: "TipoCuenta");

            migrationBuilder.DropIndex(
                name: "IX_CodigoformaPago",
                table: "FormaPago");

            migrationBuilder.DropIndex(
                name: "IX_CuentaBancoTipoCuenta",
                table: "Cuenta");

            migrationBuilder.DropIndex(
                name: "IX_CodigoBanco",
                table: "Banco");

            migrationBuilder.RenameColumn(
                name: "CuentaId",
                table: "Pago",
                newName: "TipoCuentaId");

            migrationBuilder.RenameIndex(
                name: "IX_Pago_CuentaId",
                table: "Pago",
                newName: "IX_Pago_TipoCuentaId");

            migrationBuilder.AddColumn<Guid>(
                name: "BancoId",
                table: "Pago",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Pago_BancoId",
                table: "Pago",
                column: "BancoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_Banco_BancoId",
                table: "Pago",
                column: "BancoId",
                principalTable: "Banco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_TipoCuenta_TipoCuentaId",
                table: "Pago",
                column: "TipoCuentaId",
                principalTable: "TipoCuenta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

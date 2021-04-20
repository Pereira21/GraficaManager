using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Data.Migrations
{
    public partial class v002AddInsertInTablesAndRemoveDataSolicitacaoPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataSolicitacao",
                table: "Pedido");

            migrationBuilder.AddColumn<DateTime>(
                name: "_Insert",
                table: "PedidoMateriaPrimaEstoque",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_Insert",
                table: "Pedido",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_Insert",
                table: "MateriaPrimaEstoque",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_Insert",
                table: "CompraMateriaPrima",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_Insert",
                table: "Cliente",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_Insert",
                table: "PedidoMateriaPrimaEstoque");

            migrationBuilder.DropColumn(
                name: "_Insert",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "_Insert",
                table: "MateriaPrimaEstoque");

            migrationBuilder.DropColumn(
                name: "_Insert",
                table: "CompraMateriaPrima");

            migrationBuilder.DropColumn(
                name: "_Insert",
                table: "Cliente");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataSolicitacao",
                table: "Pedido",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

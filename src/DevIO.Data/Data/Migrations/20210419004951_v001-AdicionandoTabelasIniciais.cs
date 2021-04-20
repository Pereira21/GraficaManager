using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Data.Migrations
{
    public partial class v001AdicionandoTabelasIniciais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TipoPessoa = table.Column<int>(nullable: false),
                    CpfCnpj = table.Column<string>(type: "varchar(100)", nullable: false),
                    NomeCompleto = table.Column<string>(type: "varchar(100)", nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    RazaoSocial = table.Column<string>(type: "varchar(100)", nullable: true),
                    NomeFantasia = table.Column<string>(type: "varchar(100)", nullable: true),
                    TelefoneContato = table.Column<string>(type: "varchar(100)", nullable: false),
                    EmailContato = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MateriaPrimaEstoque",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaPrimaEstoque", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    NumeroPedido = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataSolicitacao = table.Column<DateTime>(nullable: false),
                    DataEntrega = table.Column<DateTime>(nullable: true),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompraMateriaPrima",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MateriaPrimaEstoqueId = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    DataCompra = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraMateriaPrima", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompraMateriaPrima_MateriaPrimaEstoque_MateriaPrimaEstoqueId",
                        column: x => x.MateriaPrimaEstoqueId,
                        principalTable: "MateriaPrimaEstoque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidoMateriaPrimaEstoque",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PedidoId = table.Column<Guid>(nullable: false),
                    MateriaPrimaEstoqueId = table.Column<Guid>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoMateriaPrimaEstoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoMateriaPrimaEstoque_MateriaPrimaEstoque_MateriaPrimaEstoqueId",
                        column: x => x.MateriaPrimaEstoqueId,
                        principalTable: "MateriaPrimaEstoque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoMateriaPrimaEstoque_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompraMateriaPrima_MateriaPrimaEstoqueId",
                table: "CompraMateriaPrima",
                column: "MateriaPrimaEstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoMateriaPrimaEstoque_MateriaPrimaEstoqueId",
                table: "PedidoMateriaPrimaEstoque",
                column: "MateriaPrimaEstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoMateriaPrimaEstoque_PedidoId",
                table: "PedidoMateriaPrimaEstoque",
                column: "PedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraMateriaPrima");

            migrationBuilder.DropTable(
                name: "PedidoMateriaPrimaEstoque");

            migrationBuilder.DropTable(
                name: "MateriaPrimaEstoque");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}

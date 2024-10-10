using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Oficina.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoIniial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CadastropecasId",
                columns: table => new
                {
                    CadastropecasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomepeca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipopeca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valorpeca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastropecasId", x => x.CadastropecasId);
                });

            migrationBuilder.CreateTable(
                name: "CadastrovendedorId",
                columns: table => new
                {
                    CadastrovendedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomevendedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpfvendedor = table.Column<int>(type: "int", nullable: false),
                    Emailvendedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datanascimentovendedor = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastrovendedorId", x => x.CadastrovendedorId);
                });

            migrationBuilder.CreateTable(
                name: "Premium",
                columns: table => new
                {
                    PremiumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipodepremium = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descontodopremium = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premium", x => x.PremiumId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomecliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CpfCliente = table.Column<int>(type: "int", nullable: false),
                    EmailCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datadenacimentocliente = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TelefoneCliente = table.Column<int>(type: "int", nullable: false),
                    PremiumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Cliente_Premium_PremiumId",
                        column: x => x.PremiumId,
                        principalTable: "Premium",
                        principalColumn: "PremiumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadastrovendedorId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Dadosdopedido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datadopedido = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedido_CadastrovendedorId_CadastrovendedorId",
                        column: x => x.CadastrovendedorId,
                        principalTable: "CadastrovendedorId",
                        principalColumn: "CadastrovendedorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidopeca",
                columns: table => new
                {
                    PedidopecaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    CadastropecasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidopeca", x => x.PedidopecaId);
                    table.ForeignKey(
                        name: "FK_Pedidopeca_CadastropecasId_CadastropecasId",
                        column: x => x.CadastropecasId,
                        principalTable: "CadastropecasId",
                        principalColumn: "CadastropecasId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidopeca_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PremiumId",
                table: "Cliente",
                column: "PremiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_CadastrovendedorId",
                table: "Pedido",
                column: "CadastrovendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidopeca_CadastropecasId",
                table: "Pedidopeca",
                column: "CadastropecasId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidopeca_PedidoId",
                table: "Pedidopeca",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidopeca");

            migrationBuilder.DropTable(
                name: "CadastropecasId");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "CadastrovendedorId");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Premium");
        }
    }
}

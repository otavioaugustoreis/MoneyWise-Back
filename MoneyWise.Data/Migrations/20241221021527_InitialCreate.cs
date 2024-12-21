using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyWise.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ds_nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ds_cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nr_idade = table.Column<int>(type: "int", nullable: false),
                    ds_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fk_pedido = table.Column<int>(type: "int", nullable: false),
                    dh_inclusao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.pk_id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PEDIDO",
                columns: table => new
                {
                    pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_usuario = table.Column<int>(type: "int", nullable: false),
                    dh_inclusao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PEDIDO", x => x.pk_id);
                    table.ForeignKey(
                        name: "FK_TB_PEDIDO_TB_USUARIO_fk_usuario",
                        column: x => x.fk_usuario,
                        principalTable: "TB_USUARIO",
                        principalColumn: "pk_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PEDIDO_fk_usuario",
                table: "TB_PEDIDO",
                column: "fk_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PEDIDO");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");
        }
    }
}

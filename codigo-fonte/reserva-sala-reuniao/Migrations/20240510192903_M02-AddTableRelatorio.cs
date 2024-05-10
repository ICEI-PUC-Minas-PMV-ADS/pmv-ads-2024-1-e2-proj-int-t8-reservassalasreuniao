using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reserva_sala_reuniao.Migrations
{
    /// <inheritdoc />
    public partial class M02AddTableRelatorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RelatorioTipo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatorioTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relatorio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoRelatorioId = table.Column<long>(type: "bigint", nullable: false),
                    RelatorioTipoId = table.Column<long>(type: "bigint", nullable: true),
                    Arquivo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relatorio_RelatorioTipo_RelatorioTipoId",
                        column: x => x.RelatorioTipoId,
                        principalTable: "RelatorioTipo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relatorio_RelatorioTipoId",
                table: "Relatorio",
                column: "RelatorioTipoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relatorio");

            migrationBuilder.DropTable(
                name: "RelatorioTipo");
        }
    }
}

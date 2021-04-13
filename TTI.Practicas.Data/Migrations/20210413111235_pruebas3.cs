using Microsoft.EntityFrameworkCore.Migrations;

namespace TTI.Practicas.Data.Migrations
{
    public partial class pruebas3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TablasRelId",
                table: "PruebaTabla",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "pruebasTablasPruebasId",
                table: "PruebaTabla",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PruebasRelacionadas",
                columns: table => new
                {
                    PruebasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Edad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PruebasRelacionadas", x => x.PruebasId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PruebaTabla_pruebasTablasPruebasId",
                table: "PruebaTabla",
                column: "pruebasTablasPruebasId");

            migrationBuilder.AddForeignKey(
                name: "FK_PruebaTabla_PruebasRelacionadas_pruebasTablasPruebasId",
                table: "PruebaTabla",
                column: "pruebasTablasPruebasId",
                principalTable: "PruebasRelacionadas",
                principalColumn: "PruebasId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PruebaTabla_PruebasRelacionadas_pruebasTablasPruebasId",
                table: "PruebaTabla");

            migrationBuilder.DropTable(
                name: "PruebasRelacionadas");

            migrationBuilder.DropIndex(
                name: "IX_PruebaTabla_pruebasTablasPruebasId",
                table: "PruebaTabla");

            migrationBuilder.DropColumn(
                name: "TablasRelId",
                table: "PruebaTabla");

            migrationBuilder.DropColumn(
                name: "pruebasTablasPruebasId",
                table: "PruebaTabla");
        }
    }
}

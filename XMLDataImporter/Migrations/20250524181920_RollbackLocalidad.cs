using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XMLDataImporter.Migrations
{
    /// <inheritdoc />
    public partial class RollbackLocalidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localidades_Paises_PaisId",
                table: "Localidades");

            migrationBuilder.DropIndex(
                name: "IX_Localidades_PaisId",
                table: "Localidades");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Localidades");

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Localidades",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Localidades");

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "Localidades",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_PaisId",
                table: "Localidades",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidades_Paises_PaisId",
                table: "Localidades",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

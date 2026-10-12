using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Programacion2ClientesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgregarIndicesUnicosClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_clientes_CUI",
                table: "clientes",
                column: "CUI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clientes_NIT",
                table: "clientes",
                column: "NIT",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_clientes_CUI",
                table: "clientes");

            migrationBuilder.DropIndex(
                name: "IX_clientes_NIT",
                table: "clientes");
        }
    }
}

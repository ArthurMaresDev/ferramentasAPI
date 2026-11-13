using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ferramentasAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenomearNameParaNome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                 name: "Name",
                 table: "Funcionarios",
                 newName: "Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
            name: "Nome",
            table: "Funcionarios",
            newName: "Name");
        }
    }
}

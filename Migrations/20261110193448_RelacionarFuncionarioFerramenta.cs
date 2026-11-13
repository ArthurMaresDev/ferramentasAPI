using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ferramentasAPI.Migrations
{
    /// <inheritdoc />
    public partial class RelacionarFuncionarioFerramenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Ferramentas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ferramentas_FuncionarioId",
                table: "Ferramentas",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ferramentas_Funcionarios_FuncionarioId",
                table: "Ferramentas",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ferramentas_Funcionarios_FuncionarioId",
                table: "Ferramentas");

            migrationBuilder.DropIndex(
                name: "IX_Ferramentas_FuncionarioId",
                table: "Ferramentas");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Ferramentas");
        }
    }
}

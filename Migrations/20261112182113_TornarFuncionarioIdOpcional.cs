using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ferramentasAPI.Migrations
{
    /// <inheritdoc />
    public partial class TornarFuncionarioIdOpcional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ferramentas_Funcionarios_FuncionarioId",
                table: "Ferramentas");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "Ferramentas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Ferramentas_Funcionarios_FuncionarioId",
                table: "Ferramentas",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ferramentas_Funcionarios_FuncionarioId",
                table: "Ferramentas");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "Ferramentas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ferramentas_Funcionarios_FuncionarioId",
                table: "Ferramentas",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

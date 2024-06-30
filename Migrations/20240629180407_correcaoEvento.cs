using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaInteligente.Migrations
{
    /// <inheritdoc />
    public partial class correcaoEvento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Telefone",
                table: "Usuarios",
                type: "NUMBER(11)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "NUMBER(11)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Telefone",
                table: "Usuarios",
                type: "NUMBER(11)",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "NUMBER(11)",
                oldNullable: true);
        }
    }
}

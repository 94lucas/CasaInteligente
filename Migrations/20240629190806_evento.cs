using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaInteligente.Migrations
{
    /// <inheritdoc />
    public partial class evento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispositivos_Eventos_EventoDeEmergenciaModelEventoId",
                table: "Dispositivos");

            migrationBuilder.DropForeignKey(
                name: "FK_Dispositivos_Eventos_EventoId",
                table: "Dispositivos");

            migrationBuilder.DropIndex(
                name: "IX_Dispositivos_EventoDeEmergenciaModelEventoId",
                table: "Dispositivos");

            migrationBuilder.DropIndex(
                name: "IX_Dispositivos_EventoId",
                table: "Dispositivos");

            migrationBuilder.DropColumn(
                name: "EventoDeEmergenciaModelEventoId",
                table: "Dispositivos");

            migrationBuilder.AlterColumn<int>(
                name: "EventoId",
                table: "Eventos",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Dispositivos_EventoId",
                table: "Eventos",
                column: "EventoId",
                principalTable: "Dispositivos",
                principalColumn: "DispositivoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Dispositivos_EventoId",
                table: "Eventos");

            migrationBuilder.AlterColumn<int>(
                name: "EventoId",
                table: "Eventos",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddColumn<int>(
                name: "EventoDeEmergenciaModelEventoId",
                table: "Dispositivos",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivos_EventoDeEmergenciaModelEventoId",
                table: "Dispositivos",
                column: "EventoDeEmergenciaModelEventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivos_EventoId",
                table: "Dispositivos",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dispositivos_Eventos_EventoDeEmergenciaModelEventoId",
                table: "Dispositivos",
                column: "EventoDeEmergenciaModelEventoId",
                principalTable: "Eventos",
                principalColumn: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dispositivos_Eventos_EventoId",
                table: "Dispositivos",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "EventoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

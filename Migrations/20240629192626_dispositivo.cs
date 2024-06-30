using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaInteligente.Migrations
{
    /// <inheritdoc />
    public partial class dispositivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispositivos_Casas_CasaId",
                table: "Dispositivos");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Dispositivos_EventoId",
                table: "Eventos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dispositivos",
                table: "Dispositivos");

            migrationBuilder.RenameTable(
                name: "Dispositivos",
                newName: "DispositivosSeg");

            migrationBuilder.RenameIndex(
                name: "IX_Dispositivos_CasaId",
                table: "DispositivosSeg",
                newName: "IX_DispositivosSeg_CasaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DispositivosSeg",
                table: "DispositivosSeg",
                column: "DispositivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DispositivosSeg_Casas_CasaId",
                table: "DispositivosSeg",
                column: "CasaId",
                principalTable: "Casas",
                principalColumn: "CasaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_DispositivosSeg_EventoId",
                table: "Eventos",
                column: "EventoId",
                principalTable: "DispositivosSeg",
                principalColumn: "DispositivoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DispositivosSeg_Casas_CasaId",
                table: "DispositivosSeg");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_DispositivosSeg_EventoId",
                table: "Eventos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DispositivosSeg",
                table: "DispositivosSeg");

            migrationBuilder.RenameTable(
                name: "DispositivosSeg",
                newName: "Dispositivos");

            migrationBuilder.RenameIndex(
                name: "IX_DispositivosSeg_CasaId",
                table: "Dispositivos",
                newName: "IX_Dispositivos_CasaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dispositivos",
                table: "Dispositivos",
                column: "DispositivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dispositivos_Casas_CasaId",
                table: "Dispositivos",
                column: "CasaId",
                principalTable: "Casas",
                principalColumn: "CasaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Dispositivos_EventoId",
                table: "Eventos",
                column: "EventoId",
                principalTable: "Dispositivos",
                principalColumn: "DispositivoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

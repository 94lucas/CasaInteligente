using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaInteligente.Migrations
{
    /// <inheritdoc />
    public partial class sec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Tipo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    DataEvento = table.Column<DateTime>(type: "DATE", nullable: false),
                    Mensagem = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DispositivoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Telefone = table.Column<long>(type: "NUMBER(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Casas",
                columns: table => new
                {
                    CasaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Cep = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casas", x => x.CasaId);
                    table.ForeignKey(
                        name: "FK_Casas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dispositivos",
                columns: table => new
                {
                    DispositivoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Tipo = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    LocalInstalacao = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    CasaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EventoDeEmergenciaModelEventoId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositivos", x => x.DispositivoId);
                    table.ForeignKey(
                        name: "FK_Dispositivos_Casas_CasaId",
                        column: x => x.CasaId,
                        principalTable: "Casas",
                        principalColumn: "CasaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dispositivos_Eventos_EventoDeEmergenciaModelEventoId",
                        column: x => x.EventoDeEmergenciaModelEventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId");
                    table.ForeignKey(
                        name: "FK_Dispositivos_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Casas_UsuarioId",
                table: "Casas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivos_CasaId",
                table: "Dispositivos",
                column: "CasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivos_EventoDeEmergenciaModelEventoId",
                table: "Dispositivos",
                column: "EventoDeEmergenciaModelEventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivos_EventoId",
                table: "Dispositivos",
                column: "EventoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dispositivos");

            migrationBuilder.DropTable(
                name: "Casas");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}

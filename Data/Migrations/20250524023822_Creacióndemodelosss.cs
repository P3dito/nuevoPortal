using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practica3.Data.Migrations
{
    /// <inheritdoc />
    public partial class Creacióndemodelosss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_autor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Correo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_autor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PublicacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Sentimiento = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_feedback", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_publicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Cuerpo = table.Column<string>(type: "TEXT", nullable: false),
                    AutorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_publicacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_publicacion_t_autor_AutorId",
                        column: x => x.AutorId,
                        principalTable: "t_autor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_comentario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Correo = table.Column<string>(type: "TEXT", nullable: false),
                    Cuerpo = table.Column<string>(type: "TEXT", nullable: false),
                    PublicacionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_comentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_comentario_t_publicacion_PublicacionId",
                        column: x => x.PublicacionId,
                        principalTable: "t_publicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_comentario_PublicacionId",
                table: "t_comentario",
                column: "PublicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_t_publicacion_AutorId",
                table: "t_publicacion",
                column: "AutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_comentario");

            migrationBuilder.DropTable(
                name: "t_feedback");

            migrationBuilder.DropTable(
                name: "t_publicacion");

            migrationBuilder.DropTable(
                name: "t_autor");
        }
    }
}

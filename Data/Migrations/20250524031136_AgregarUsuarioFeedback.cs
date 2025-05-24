using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practica3.Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarUsuarioFeedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "t_feedback",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "t_feedback");
        }
    }
}

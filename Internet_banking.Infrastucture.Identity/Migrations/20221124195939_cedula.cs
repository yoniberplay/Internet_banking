using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internetbanking.Infrastucture.Identity.Migrations
{
    /// <inheritdoc />
    public partial class cedula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cedula",
                schema: "Identity",
                table: "Users");
        }
    }
}

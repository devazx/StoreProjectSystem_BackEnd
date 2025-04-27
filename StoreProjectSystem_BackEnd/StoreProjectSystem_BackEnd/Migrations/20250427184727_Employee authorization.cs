using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreProjectSystem_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Employeeauthorization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Hired",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hired",
                table: "AspNetUsers");
        }
    }
}

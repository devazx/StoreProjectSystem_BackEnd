using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreProjectSystem_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipBetweenUserAndProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StoredProductsId",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoredProductsId",
                table: "AspNetUsers");
        }
    }
}

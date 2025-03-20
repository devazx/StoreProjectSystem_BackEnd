using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreProjectSystem_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class ConnectionProductswithUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "endProduct",
                keyColumn: "UserInputStoreID",
                keyValue: null,
                column: "UserInputStoreID",
                value: "");
        }
    }
}

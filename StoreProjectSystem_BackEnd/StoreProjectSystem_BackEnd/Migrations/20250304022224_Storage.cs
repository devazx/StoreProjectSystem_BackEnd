using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreProjectSystem_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Storage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "endProduct",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameProduct = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeProduct = table.Column<int>(type: "int", nullable: false),
                    CostProduct = table.Column<double>(type: "double", nullable: false),
                    EnterInStore = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserInputStoreID = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_endProduct_AspNetUsers_UserInputStoreID",
                        column: x => x.UserInputStoreID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_endProduct_UserInputStoreID",
                table: "endProduct",
                column: "UserInputStoreID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "endProduct");
        }
    }
}

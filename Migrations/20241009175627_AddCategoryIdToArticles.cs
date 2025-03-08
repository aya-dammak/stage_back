using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace foodyApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryIdToArticles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Categories_CategoryId",
                table: "Articles",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Categories_CategoryId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Articles");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Articles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}

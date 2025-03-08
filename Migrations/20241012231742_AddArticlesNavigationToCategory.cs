using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace foodyApi.Migrations
{
    /// <inheritdoc />
    public partial class AddArticlesNavigationToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId1",
                table: "Articles",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Categories_CategoryId1",
                table: "Articles",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Categories_CategoryId1",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CategoryId1",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "Id");
        }
    }
}

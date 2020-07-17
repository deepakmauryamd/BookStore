using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class addedbook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGalary_Books_BooksId",
                table: "BookGalary");

            migrationBuilder.DropIndex(
                name: "IX_BookGalary_BooksId",
                table: "BookGalary");

            migrationBuilder.DropColumn(
                name: "BooksId",
                table: "BookGalary");

            migrationBuilder.CreateIndex(
                name: "IX_BookGalary_BookId",
                table: "BookGalary",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGalary_Books_BookId",
                table: "BookGalary",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGalary_Books_BookId",
                table: "BookGalary");

            migrationBuilder.DropIndex(
                name: "IX_BookGalary_BookId",
                table: "BookGalary");

            migrationBuilder.AddColumn<int>(
                name: "BooksId",
                table: "BookGalary",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookGalary_BooksId",
                table: "BookGalary",
                column: "BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGalary_Books_BooksId",
                table: "BookGalary",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

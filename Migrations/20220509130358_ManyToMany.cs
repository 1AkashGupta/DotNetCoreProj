using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreLearnProj.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publisher_publisherId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publisher",
                table: "Publisher");

            migrationBuilder.RenameTable(
                name: "Publisher",
                newName: "publishers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_publishers",
                table: "publishers",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Book_Authors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookId = table.Column<int>(type: "int", nullable: false),
                    authorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Authors", x => x.id);
                    table.ForeignKey(
                        name: "FK_Book_Authors_Authors_authorId",
                        column: x => x.authorId,
                        principalTable: "Authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Authors_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_Authors_authorId",
                table: "Book_Authors",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Authors_bookId",
                table: "Book_Authors",
                column: "bookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_publishers_publisherId",
                table: "Books",
                column: "publisherId",
                principalTable: "publishers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_publishers_publisherId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Book_Authors");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_publishers",
                table: "publishers");

            migrationBuilder.RenameTable(
                name: "publishers",
                newName: "Publisher");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publisher",
                table: "Publisher",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publisher_publisherId",
                table: "Books",
                column: "publisherId",
                principalTable: "Publisher",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

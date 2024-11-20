using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_System.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookModelTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookModelPuplishedYear = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookModelId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreModelTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreModelId);
                });

            migrationBuilder.CreateTable(
                name: "IdentityCard",
                columns: table => new
                {
                    IdentityCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpiaryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityCard", x => x.IdentityCardId);
                });

            migrationBuilder.CreateTable(
                name: "BookModelGenreModel",
                columns: table => new
                {
                    booksBookModelId = table.Column<int>(type: "int", nullable: false),
                    genresGenreModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookModelGenreModel", x => new { x.booksBookModelId, x.genresGenreModelId });
                    table.ForeignKey(
                        name: "FK_BookModelGenreModel_Book_booksBookModelId",
                        column: x => x.booksBookModelId,
                        principalTable: "Book",
                        principalColumn: "BookModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookModelGenreModel_Genre_genresGenreModelId",
                        column: x => x.genresGenreModelId,
                        principalTable: "Genre",
                        principalColumn: "GenreModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorModelEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorModelPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityCardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorModelId);
                    table.ForeignKey(
                        name: "FK_Author_IdentityCard_IdentityCardId",
                        column: x => x.IdentityCardId,
                        principalTable: "IdentityCard",
                        principalColumn: "IdentityCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorModelBookModel",
                columns: table => new
                {
                    BooksBookModelId = table.Column<int>(type: "int", nullable: false),
                    authorsAuthorModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorModelBookModel", x => new { x.BooksBookModelId, x.authorsAuthorModelId });
                    table.ForeignKey(
                        name: "FK_AuthorModelBookModel_Author_authorsAuthorModelId",
                        column: x => x.authorsAuthorModelId,
                        principalTable: "Author",
                        principalColumn: "AuthorModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorModelBookModel_Book_BooksBookModelId",
                        column: x => x.BooksBookModelId,
                        principalTable: "Book",
                        principalColumn: "BookModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    CreditCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditCardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditCardType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.CreditCardId);
                    table.ForeignKey(
                        name: "FK_CreditCard_Author_AuthorModelId",
                        column: x => x.AuthorModelId,
                        principalTable: "Author",
                        principalColumn: "AuthorModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Author_IdentityCardId",
                table: "Author",
                column: "IdentityCardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorModelBookModel_authorsAuthorModelId",
                table: "AuthorModelBookModel",
                column: "authorsAuthorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BookModelGenreModel_genresGenreModelId",
                table: "BookModelGenreModel",
                column: "genresGenreModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCard_AuthorModelId",
                table: "CreditCard",
                column: "AuthorModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorModelBookModel");

            migrationBuilder.DropTable(
                name: "BookModelGenreModel");

            migrationBuilder.DropTable(
                name: "CreditCard");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "IdentityCard");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace spellingwords.Migrations
{
    public partial class ine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Correct = table.Column<bool>(type: "INTEGER", nullable: false),
                    SpellingTestID = table.Column<int>(type: "INTEGER", nullable: false),
                    SpellingWordID = table.Column<int>(type: "INTEGER", nullable: false),
                    Word = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerID);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "SpellingLists",
                columns: table => new
                {
                    SpellingListID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellingLists", x => x.SpellingListID);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BlogId = table.Column<int>(type: "INTEGER", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpellingTests",
                columns: table => new
                {
                    SpellingTestID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Grade = table.Column<int>(type: "INTEGER", nullable: false),
                    SpellingListID = table.Column<int>(type: "INTEGER", nullable: false),
                    User = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellingTests", x => x.SpellingTestID);
                    table.ForeignKey(
                        name: "FK_SpellingTests_SpellingLists_SpellingListID",
                        column: x => x.SpellingListID,
                        principalTable: "SpellingLists",
                        principalColumn: "SpellingListID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpellingWords",
                columns: table => new
                {
                    SpellingWordID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpellingListID = table.Column<int>(type: "INTEGER", nullable: false),
                    Word = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellingWords", x => x.SpellingWordID);
                    table.ForeignKey(
                        name: "FK_SpellingWords_SpellingLists_SpellingListID",
                        column: x => x.SpellingListID,
                        principalTable: "SpellingLists",
                        principalColumn: "SpellingListID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogId",
                table: "Posts",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellingTests_SpellingListID",
                table: "SpellingTests",
                column: "SpellingListID");

            migrationBuilder.CreateIndex(
                name: "IX_SpellingWords_SpellingListID",
                table: "SpellingWords",
                column: "SpellingListID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "SpellingTests");

            migrationBuilder.DropTable(
                name: "SpellingWords");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "SpellingLists");
        }
    }
}

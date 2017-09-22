using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BiblioWebServicesCore.Migrations
{
    public partial class InitDataBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Key = table.Column<long>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Author = table.Column<string>(nullable: true),
                    CoverSrc = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(),
                    Format = table.Column<int>(),
                    IsRead = table.Column<bool>(),
                    Note = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Key = table.Column<long>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "BookType",
                columns: table => new
                {
                    Key = table.Column<long>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BookID = table.Column<long>(),
                    TypeID = table.Column<long>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookType", x => x.Key);
                    table.ForeignKey(
                        name: "FK_BookType_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookType_Type_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Type",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookType_BookID",
                table: "BookType",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BookType_TypeID",
                table: "BookType",
                column: "TypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookType");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Type");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class entityChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReadersAndPenaltys",
                table: "ReadersAndPenaltys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorAndComposition",
                table: "AuthorAndComposition");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ReadersAndPenaltys",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AuthorAndComposition",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReadersAndPenaltys",
                table: "ReadersAndPenaltys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorAndComposition",
                table: "AuthorAndComposition",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ReadersAndPenaltys_ReaderId",
                table: "ReadersAndPenaltys",
                column: "ReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorAndComposition_AuthorId",
                table: "AuthorAndComposition",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReadersAndPenaltys",
                table: "ReadersAndPenaltys");

            migrationBuilder.DropIndex(
                name: "IX_ReadersAndPenaltys_ReaderId",
                table: "ReadersAndPenaltys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorAndComposition",
                table: "AuthorAndComposition");

            migrationBuilder.DropIndex(
                name: "IX_AuthorAndComposition_AuthorId",
                table: "AuthorAndComposition");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReadersAndPenaltys");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AuthorAndComposition");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReadersAndPenaltys",
                table: "ReadersAndPenaltys",
                columns: new[] { "ReaderId", "PenaltyId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorAndComposition",
                table: "AuthorAndComposition",
                columns: new[] { "AuthorId", "CompositionId" });
        }
    }
}

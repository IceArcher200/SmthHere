using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class composAndPublishChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CompositionsAndPublishers",
                table: "CompositionsAndPublishers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CompositionsAndPublishers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompositionsAndPublishers",
                table: "CompositionsAndPublishers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CompositionsAndPublishers_PlaceOfPublicationId",
                table: "CompositionsAndPublishers",
                column: "PlaceOfPublicationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CompositionsAndPublishers",
                table: "CompositionsAndPublishers");

            migrationBuilder.DropIndex(
                name: "IX_CompositionsAndPublishers_PlaceOfPublicationId",
                table: "CompositionsAndPublishers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CompositionsAndPublishers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompositionsAndPublishers",
                table: "CompositionsAndPublishers",
                columns: new[] { "PlaceOfPublicationId", "CompostionId" });
        }
    }
}

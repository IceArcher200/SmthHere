using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class givenExamplersChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GivenExamplers",
                table: "GivenExamplers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GivenExamplers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GivenExamplers",
                table: "GivenExamplers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GivenExamplers_ReaderId",
                table: "GivenExamplers",
                column: "ReaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GivenExamplers",
                table: "GivenExamplers");

            migrationBuilder.DropIndex(
                name: "IX_GivenExamplers_ReaderId",
                table: "GivenExamplers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GivenExamplers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GivenExamplers",
                table: "GivenExamplers",
                columns: new[] { "ReaderId", "ExamplerId" });
        }
    }
}

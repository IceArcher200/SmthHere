using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class dbsetTest5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompositionsAndPublishers_PlaceOfPublication_PlaceOfPublicationId",
                table: "CompositionsAndPublishers");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceOfPublication_PublishingHouses_PublishingHouseId",
                table: "PlaceOfPublication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaceOfPublication",
                table: "PlaceOfPublication");

            migrationBuilder.RenameTable(
                name: "PlaceOfPublication",
                newName: "PlacesOfPublications");

            migrationBuilder.RenameIndex(
                name: "IX_PlaceOfPublication_PublishingHouseId",
                table: "PlacesOfPublications",
                newName: "IX_PlacesOfPublications_PublishingHouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlacesOfPublications",
                table: "PlacesOfPublications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompositionsAndPublishers_PlacesOfPublications_PlaceOfPublicationId",
                table: "CompositionsAndPublishers",
                column: "PlaceOfPublicationId",
                principalTable: "PlacesOfPublications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlacesOfPublications_PublishingHouses_PublishingHouseId",
                table: "PlacesOfPublications",
                column: "PublishingHouseId",
                principalTable: "PublishingHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompositionsAndPublishers_PlacesOfPublications_PlaceOfPublicationId",
                table: "CompositionsAndPublishers");

            migrationBuilder.DropForeignKey(
                name: "FK_PlacesOfPublications_PublishingHouses_PublishingHouseId",
                table: "PlacesOfPublications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlacesOfPublications",
                table: "PlacesOfPublications");

            migrationBuilder.RenameTable(
                name: "PlacesOfPublications",
                newName: "PlaceOfPublication");

            migrationBuilder.RenameIndex(
                name: "IX_PlacesOfPublications_PublishingHouseId",
                table: "PlaceOfPublication",
                newName: "IX_PlaceOfPublication_PublishingHouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaceOfPublication",
                table: "PlaceOfPublication",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompositionsAndPublishers_PlaceOfPublication_PlaceOfPublicationId",
                table: "CompositionsAndPublishers",
                column: "PlaceOfPublicationId",
                principalTable: "PlaceOfPublication",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceOfPublication_PublishingHouses_PublishingHouseId",
                table: "PlaceOfPublication",
                column: "PublishingHouseId",
                principalTable: "PublishingHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

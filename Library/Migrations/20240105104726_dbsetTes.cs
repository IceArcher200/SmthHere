using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class dbsetTes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorAndComposition_Author_AuthorId",
                table: "AuthorAndComposition");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorAndComposition_Composition_CompositionId",
                table: "AuthorAndComposition");

            migrationBuilder.DropForeignKey(
                name: "FK_Composition_TypeOfComposition_TypeId",
                table: "Composition");

            migrationBuilder.DropForeignKey(
                name: "FK_CompositionsAndPublishers_Composition_CompostionId",
                table: "CompositionsAndPublishers");

            migrationBuilder.DropForeignKey(
                name: "FK_CompositionsAndPublishers_PublishingHouse_PublishingHouseId",
                table: "CompositionsAndPublishers");

            migrationBuilder.DropForeignKey(
                name: "FK_Exampler_Composition_CompositionId",
                table: "Exampler");

            migrationBuilder.DropForeignKey(
                name: "FK_Exampler_Storage_StorageId",
                table: "Exampler");

            migrationBuilder.DropForeignKey(
                name: "FK_GivenExamplers_Exampler_ExamplerId",
                table: "GivenExamplers");

            migrationBuilder.DropForeignKey(
                name: "FK_InterlibrarySubscription_Readers_ReaderId",
                table: "InterlibrarySubscription");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceOfPublication_PublishingHouse_PublishingHouseId",
                table: "PlaceOfPublication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Storage",
                table: "Storage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublishingHouse",
                table: "PublishingHouse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterlibrarySubscription",
                table: "InterlibrarySubscription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exampler",
                table: "Exampler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Composition",
                table: "Composition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "Storage",
                newName: "Storages");

            migrationBuilder.RenameTable(
                name: "PublishingHouse",
                newName: "PublishingHouses");

            migrationBuilder.RenameTable(
                name: "InterlibrarySubscription",
                newName: "InterlibrarySubscriptions");

            migrationBuilder.RenameTable(
                name: "Exampler",
                newName: "Examplers");

            migrationBuilder.RenameTable(
                name: "Composition",
                newName: "Compositions");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.RenameIndex(
                name: "IX_InterlibrarySubscription_ReaderId",
                table: "InterlibrarySubscriptions",
                newName: "IX_InterlibrarySubscriptions_ReaderId");

            migrationBuilder.RenameIndex(
                name: "IX_Exampler_StorageId",
                table: "Examplers",
                newName: "IX_Examplers_StorageId");

            migrationBuilder.RenameIndex(
                name: "IX_Exampler_CompositionId",
                table: "Examplers",
                newName: "IX_Examplers_CompositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Composition_TypeId",
                table: "Compositions",
                newName: "IX_Compositions_TypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Storages",
                table: "Storages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublishingHouses",
                table: "PublishingHouses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterlibrarySubscriptions",
                table: "InterlibrarySubscriptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Examplers",
                table: "Examplers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compositions",
                table: "Compositions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorAndComposition_Authors_AuthorId",
                table: "AuthorAndComposition",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorAndComposition_Compositions_CompositionId",
                table: "AuthorAndComposition",
                column: "CompositionId",
                principalTable: "Compositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compositions_TypeOfComposition_TypeId",
                table: "Compositions",
                column: "TypeId",
                principalTable: "TypeOfComposition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompositionsAndPublishers_Compositions_CompostionId",
                table: "CompositionsAndPublishers",
                column: "CompostionId",
                principalTable: "Compositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompositionsAndPublishers_PublishingHouses_PublishingHouseId",
                table: "CompositionsAndPublishers",
                column: "PublishingHouseId",
                principalTable: "PublishingHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Examplers_Compositions_CompositionId",
                table: "Examplers",
                column: "CompositionId",
                principalTable: "Compositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Examplers_Storages_StorageId",
                table: "Examplers",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GivenExamplers_Examplers_ExamplerId",
                table: "GivenExamplers",
                column: "ExamplerId",
                principalTable: "Examplers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterlibrarySubscriptions_Readers_ReaderId",
                table: "InterlibrarySubscriptions",
                column: "ReaderId",
                principalTable: "Readers",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorAndComposition_Authors_AuthorId",
                table: "AuthorAndComposition");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorAndComposition_Compositions_CompositionId",
                table: "AuthorAndComposition");

            migrationBuilder.DropForeignKey(
                name: "FK_Compositions_TypeOfComposition_TypeId",
                table: "Compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_CompositionsAndPublishers_Compositions_CompostionId",
                table: "CompositionsAndPublishers");

            migrationBuilder.DropForeignKey(
                name: "FK_CompositionsAndPublishers_PublishingHouses_PublishingHouseId",
                table: "CompositionsAndPublishers");

            migrationBuilder.DropForeignKey(
                name: "FK_Examplers_Compositions_CompositionId",
                table: "Examplers");

            migrationBuilder.DropForeignKey(
                name: "FK_Examplers_Storages_StorageId",
                table: "Examplers");

            migrationBuilder.DropForeignKey(
                name: "FK_GivenExamplers_Examplers_ExamplerId",
                table: "GivenExamplers");

            migrationBuilder.DropForeignKey(
                name: "FK_InterlibrarySubscriptions_Readers_ReaderId",
                table: "InterlibrarySubscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceOfPublication_PublishingHouses_PublishingHouseId",
                table: "PlaceOfPublication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Storages",
                table: "Storages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublishingHouses",
                table: "PublishingHouses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterlibrarySubscriptions",
                table: "InterlibrarySubscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Examplers",
                table: "Examplers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compositions",
                table: "Compositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Storages",
                newName: "Storage");

            migrationBuilder.RenameTable(
                name: "PublishingHouses",
                newName: "PublishingHouse");

            migrationBuilder.RenameTable(
                name: "InterlibrarySubscriptions",
                newName: "InterlibrarySubscription");

            migrationBuilder.RenameTable(
                name: "Examplers",
                newName: "Exampler");

            migrationBuilder.RenameTable(
                name: "Compositions",
                newName: "Composition");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_InterlibrarySubscriptions_ReaderId",
                table: "InterlibrarySubscription",
                newName: "IX_InterlibrarySubscription_ReaderId");

            migrationBuilder.RenameIndex(
                name: "IX_Examplers_StorageId",
                table: "Exampler",
                newName: "IX_Exampler_StorageId");

            migrationBuilder.RenameIndex(
                name: "IX_Examplers_CompositionId",
                table: "Exampler",
                newName: "IX_Exampler_CompositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Compositions_TypeId",
                table: "Composition",
                newName: "IX_Composition_TypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Storage",
                table: "Storage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublishingHouse",
                table: "PublishingHouse",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterlibrarySubscription",
                table: "InterlibrarySubscription",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exampler",
                table: "Exampler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Composition",
                table: "Composition",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorAndComposition_Author_AuthorId",
                table: "AuthorAndComposition",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorAndComposition_Composition_CompositionId",
                table: "AuthorAndComposition",
                column: "CompositionId",
                principalTable: "Composition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Composition_TypeOfComposition_TypeId",
                table: "Composition",
                column: "TypeId",
                principalTable: "TypeOfComposition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompositionsAndPublishers_Composition_CompostionId",
                table: "CompositionsAndPublishers",
                column: "CompostionId",
                principalTable: "Composition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompositionsAndPublishers_PublishingHouse_PublishingHouseId",
                table: "CompositionsAndPublishers",
                column: "PublishingHouseId",
                principalTable: "PublishingHouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exampler_Composition_CompositionId",
                table: "Exampler",
                column: "CompositionId",
                principalTable: "Composition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exampler_Storage_StorageId",
                table: "Exampler",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GivenExamplers_Exampler_ExamplerId",
                table: "GivenExamplers",
                column: "ExamplerId",
                principalTable: "Exampler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterlibrarySubscription_Readers_ReaderId",
                table: "InterlibrarySubscription",
                column: "ReaderId",
                principalTable: "Readers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceOfPublication_PublishingHouse_PublishingHouseId",
                table: "PlaceOfPublication",
                column: "PublishingHouseId",
                principalTable: "PublishingHouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

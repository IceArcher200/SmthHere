using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class readersTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DegreeId",
                table: "Readers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Readers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Readers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Readers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Readers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Readers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Professor_DepartmentId",
                table: "Readers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Professor_PositionId",
                table: "Readers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RankId",
                table: "Readers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Degree",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degree", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterlibrarySubscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArrivalDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DateOfOrder = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    NameOfLibrary = table.Column<string>(type: "TEXT", nullable: false),
                    ReaderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterlibrarySubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterlibrarySubscription_Readers_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Penalty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Sum = table.Column<int>(type: "INTEGER", nullable: false),
                    NumOfSuspensionDays = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublishingHouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DaysOfIssuance = table.Column<int>(type: "INTEGER", nullable: false),
                    PermissionOnIssuance = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishingHouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    FacultyId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReadersAndPenaltys",
                columns: table => new
                {
                    ReaderId = table.Column<int>(type: "INTEGER", nullable: false),
                    PenaltyId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfGetting = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DateOfEnding = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadersAndPenaltys", x => new { x.ReaderId, x.PenaltyId });
                    table.ForeignKey(
                        name: "FK_ReadersAndPenaltys_Penalty_PenaltyId",
                        column: x => x.PenaltyId,
                        principalTable: "Penalty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReadersAndPenaltys_Readers_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaceOfPublication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PublishingHouseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceOfPublication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceOfPublication_PublishingHouse_PublishingHouseId",
                        column: x => x.PublishingHouseId,
                        principalTable: "PublishingHouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompositionsAndPublishers",
                columns: table => new
                {
                    CompostionId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlaceOfPublicationId = table.Column<int>(type: "INTEGER", nullable: false),
                    PublishingHouseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompositionsAndPublishers", x => new { x.PlaceOfPublicationId, x.CompostionId });
                    table.ForeignKey(
                        name: "FK_CompositionsAndPublishers_Composition_CompostionId",
                        column: x => x.CompostionId,
                        principalTable: "Composition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompositionsAndPublishers_PlaceOfPublication_PlaceOfPublicationId",
                        column: x => x.PlaceOfPublicationId,
                        principalTable: "PlaceOfPublication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompositionsAndPublishers_PublishingHouse_PublishingHouseId",
                        column: x => x.PublishingHouseId,
                        principalTable: "PublishingHouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Readers_DegreeId",
                table: "Readers",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Readers_DepartmentId",
                table: "Readers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Readers_FacultyId",
                table: "Readers",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Readers_PositionId",
                table: "Readers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Readers_Professor_DepartmentId",
                table: "Readers",
                column: "Professor_DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Readers_Professor_PositionId",
                table: "Readers",
                column: "Professor_PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Readers_RankId",
                table: "Readers",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_CompositionsAndPublishers_CompostionId",
                table: "CompositionsAndPublishers",
                column: "CompostionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompositionsAndPublishers_PublishingHouseId",
                table: "CompositionsAndPublishers",
                column: "PublishingHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_FacultyId",
                table: "Department",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_InterlibrarySubscription_ReaderId",
                table: "InterlibrarySubscription",
                column: "ReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceOfPublication_PublishingHouseId",
                table: "PlaceOfPublication",
                column: "PublishingHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadersAndPenaltys_PenaltyId",
                table: "ReadersAndPenaltys",
                column: "PenaltyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Readers_Degree_DegreeId",
                table: "Readers",
                column: "DegreeId",
                principalTable: "Degree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readers_Department_DepartmentId",
                table: "Readers",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readers_Department_Professor_DepartmentId",
                table: "Readers",
                column: "Professor_DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readers_Faculty_FacultyId",
                table: "Readers",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readers_Position_PositionId",
                table: "Readers",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readers_Position_Professor_PositionId",
                table: "Readers",
                column: "Professor_PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readers_Rank_RankId",
                table: "Readers",
                column: "RankId",
                principalTable: "Rank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readers_Degree_DegreeId",
                table: "Readers");

            migrationBuilder.DropForeignKey(
                name: "FK_Readers_Department_DepartmentId",
                table: "Readers");

            migrationBuilder.DropForeignKey(
                name: "FK_Readers_Department_Professor_DepartmentId",
                table: "Readers");

            migrationBuilder.DropForeignKey(
                name: "FK_Readers_Faculty_FacultyId",
                table: "Readers");

            migrationBuilder.DropForeignKey(
                name: "FK_Readers_Position_PositionId",
                table: "Readers");

            migrationBuilder.DropForeignKey(
                name: "FK_Readers_Position_Professor_PositionId",
                table: "Readers");

            migrationBuilder.DropForeignKey(
                name: "FK_Readers_Rank_RankId",
                table: "Readers");

            migrationBuilder.DropTable(
                name: "CompositionsAndPublishers");

            migrationBuilder.DropTable(
                name: "Degree");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "InterlibrarySubscription");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Rank");

            migrationBuilder.DropTable(
                name: "ReadersAndPenaltys");

            migrationBuilder.DropTable(
                name: "PlaceOfPublication");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropTable(
                name: "Penalty");

            migrationBuilder.DropTable(
                name: "PublishingHouse");

            migrationBuilder.DropIndex(
                name: "IX_Readers_DegreeId",
                table: "Readers");

            migrationBuilder.DropIndex(
                name: "IX_Readers_DepartmentId",
                table: "Readers");

            migrationBuilder.DropIndex(
                name: "IX_Readers_FacultyId",
                table: "Readers");

            migrationBuilder.DropIndex(
                name: "IX_Readers_PositionId",
                table: "Readers");

            migrationBuilder.DropIndex(
                name: "IX_Readers_Professor_DepartmentId",
                table: "Readers");

            migrationBuilder.DropIndex(
                name: "IX_Readers_Professor_PositionId",
                table: "Readers");

            migrationBuilder.DropIndex(
                name: "IX_Readers_RankId",
                table: "Readers");

            migrationBuilder.DropColumn(
                name: "DegreeId",
                table: "Readers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Readers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Readers");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Readers");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "Readers");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Readers");

            migrationBuilder.DropColumn(
                name: "Professor_DepartmentId",
                table: "Readers");

            migrationBuilder.DropColumn(
                name: "Professor_PositionId",
                table: "Readers");

            migrationBuilder.DropColumn(
                name: "RankId",
                table: "Readers");
        }
    }
}

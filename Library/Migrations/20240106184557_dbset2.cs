using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class dbset2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compositions_TypeOfComposition_TypeId",
                table: "Compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Faculty_FacultyId",
                table: "Department");

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

            migrationBuilder.DropForeignKey(
                name: "FK_ReadersAndPenaltys_Penalty_PenaltyId",
                table: "ReadersAndPenaltys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfComposition",
                table: "TypeOfComposition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rank",
                table: "Rank");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Penalty",
                table: "Penalty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faculty",
                table: "Faculty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Degree",
                table: "Degree");

            migrationBuilder.RenameTable(
                name: "TypeOfComposition",
                newName: "TypesOfComposition");

            migrationBuilder.RenameTable(
                name: "Rank",
                newName: "Ranks");

            migrationBuilder.RenameTable(
                name: "Position",
                newName: "Positions");

            migrationBuilder.RenameTable(
                name: "Penalty",
                newName: "Penalties");

            migrationBuilder.RenameTable(
                name: "Faculty",
                newName: "Faculties");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "Degree",
                newName: "Degrees");

            migrationBuilder.RenameIndex(
                name: "IX_Department_FacultyId",
                table: "Departments",
                newName: "IX_Departments_FacultyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypesOfComposition",
                table: "TypesOfComposition",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ranks",
                table: "Ranks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Penalties",
                table: "Penalties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faculties",
                table: "Faculties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Degrees",
                table: "Degrees",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MenuInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    NameOfFunc = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    MenuInfoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Read = table.Column<bool>(type: "INTEGER", nullable: false),
                    Write = table.Column<bool>(type: "INTEGER", nullable: false),
                    Edit = table.Column<bool>(type: "INTEGER", nullable: false),
                    Delete = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => new { x.MenuInfoId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserInfo_MenuInfo_MenuInfoId",
                        column: x => x.MenuInfoId,
                        principalTable: "MenuInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInfo_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_UserId",
                table: "UserInfo",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compositions_TypesOfComposition_TypeId",
                table: "Compositions",
                column: "TypeId",
                principalTable: "TypesOfComposition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Faculties_FacultyId",
                table: "Departments",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readers_Degrees_DegreeId",
                table: "Readers",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readers_Departments_DepartmentId",
                table: "Readers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readers_Departments_Professor_DepartmentId",
                table: "Readers",
                column: "Professor_DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readers_Faculties_FacultyId",
                table: "Readers",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readers_Positions_PositionId",
                table: "Readers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readers_Positions_Professor_PositionId",
                table: "Readers",
                column: "Professor_PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readers_Ranks_RankId",
                table: "Readers",
                column: "RankId",
                principalTable: "Ranks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReadersAndPenaltys_Penalties_PenaltyId",
                table: "ReadersAndPenaltys",
                column: "PenaltyId",
                principalTable: "Penalties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compositions_TypesOfComposition_TypeId",
                table: "Compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Faculties_FacultyId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Readers_Degrees_DegreeId",
                table: "Readers");

            migrationBuilder.DropForeignKey(
                name: "FK_Readers_Departments_DepartmentId",
                table: "Readers");

            migrationBuilder.DropForeignKey(
                name: "FK_Readers_Departments_Professor_DepartmentId",
                table: "Readers");

            migrationBuilder.DropForeignKey(
                name: "FK_Readers_Faculties_FacultyId",
                table: "Readers");

            migrationBuilder.DropForeignKey(
                name: "FK_Readers_Positions_PositionId",
                table: "Readers");

            migrationBuilder.DropForeignKey(
                name: "FK_Readers_Positions_Professor_PositionId",
                table: "Readers");

            migrationBuilder.DropForeignKey(
                name: "FK_Readers_Ranks_RankId",
                table: "Readers");

            migrationBuilder.DropForeignKey(
                name: "FK_ReadersAndPenaltys_Penalties_PenaltyId",
                table: "ReadersAndPenaltys");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "MenuInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypesOfComposition",
                table: "TypesOfComposition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ranks",
                table: "Ranks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Penalties",
                table: "Penalties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faculties",
                table: "Faculties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Degrees",
                table: "Degrees");

            migrationBuilder.RenameTable(
                name: "TypesOfComposition",
                newName: "TypeOfComposition");

            migrationBuilder.RenameTable(
                name: "Ranks",
                newName: "Rank");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Position");

            migrationBuilder.RenameTable(
                name: "Penalties",
                newName: "Penalty");

            migrationBuilder.RenameTable(
                name: "Faculties",
                newName: "Faculty");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameTable(
                name: "Degrees",
                newName: "Degree");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_FacultyId",
                table: "Department",
                newName: "IX_Department_FacultyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfComposition",
                table: "TypeOfComposition",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rank",
                table: "Rank",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Penalty",
                table: "Penalty",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faculty",
                table: "Faculty",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Degree",
                table: "Degree",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compositions_TypeOfComposition_TypeId",
                table: "Compositions",
                column: "TypeId",
                principalTable: "TypeOfComposition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Faculty_FacultyId",
                table: "Department",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ReadersAndPenaltys_Penalty_PenaltyId",
                table: "ReadersAndPenaltys",
                column: "PenaltyId",
                principalTable: "Penalty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

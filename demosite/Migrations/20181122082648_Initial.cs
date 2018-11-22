using Microsoft.EntityFrameworkCore.Migrations;

namespace demosite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    BuildingID = table.Column<int>(nullable: false),
                    BName = table.Column<string>(nullable: false),
                    BAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.BuildingID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false),
                    Fname = table.Column<string>(nullable: false),
                    LName = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Floor",
                columns: table => new
                {
                    FloorID = table.Column<int>(nullable: false),
                    FloorName = table.Column<string>(nullable: true),
                    BuildingID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floor", x => x.FloorID);
                    table.ForeignKey(
                        name: "FK_Floor_Building_BuildingID",
                        column: x => x.BuildingID,
                        principalTable: "Building",
                        principalColumn: "BuildingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonsBuilding",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false),
                    BuildingID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonsBuilding", x => new { x.PersonID, x.BuildingID });
                    table.ForeignKey(
                        name: "FK_PersonsBuilding_Building_BuildingID",
                        column: x => x.BuildingID,
                        principalTable: "Building",
                        principalColumn: "BuildingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonsBuilding_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomID = table.Column<int>(nullable: false),
                    RoomName = table.Column<string>(nullable: false),
                    FloorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomID);
                    table.ForeignKey(
                        name: "FK_Room_Floor_FloorID",
                        column: x => x.FloorID,
                        principalTable: "Floor",
                        principalColumn: "FloorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Floor_BuildingID",
                table: "Floor",
                column: "BuildingID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonsBuilding_BuildingID",
                table: "PersonsBuilding",
                column: "BuildingID");

            migrationBuilder.CreateIndex(
                name: "IX_Room_FloorID",
                table: "Room",
                column: "FloorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonsBuilding");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Floor");

            migrationBuilder.DropTable(
                name: "Building");
        }
    }
}

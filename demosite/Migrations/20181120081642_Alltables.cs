using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace demosite.Migrations
{
    public partial class Alltables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonsBuilding_Facility_FacilityID",
                table: "PersonsBuilding");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonsBuilding",
                table: "PersonsBuilding");

            migrationBuilder.DropIndex(
                name: "IX_PersonsBuilding_FacilityID",
                table: "PersonsBuilding");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "PersonsBuilding");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "PersonsBuilding");

            migrationBuilder.RenameColumn(
                name: "pb_id",
                table: "PersonsBuilding",
                newName: "BuildingID");

            migrationBuilder.RenameColumn(
                name: "Person_id",
                table: "PersonsBuilding",
                newName: "PersonID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonsBuilding",
                table: "PersonsBuilding",
                columns: new[] { "PersonID", "BuildingID" });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    BuildingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    FloorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                name: "Room",
                columns: table => new
                {
                    RoomID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                name: "IX_PersonsBuilding_BuildingID",
                table: "PersonsBuilding",
                column: "BuildingID");

            migrationBuilder.CreateIndex(
                name: "IX_Floor_BuildingID",
                table: "Floor",
                column: "BuildingID");

            migrationBuilder.CreateIndex(
                name: "IX_Room_FloorID",
                table: "Room",
                column: "FloorID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonsBuilding_Building_BuildingID",
                table: "PersonsBuilding",
                column: "BuildingID",
                principalTable: "Building",
                principalColumn: "BuildingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonsBuilding_Person_PersonID",
                table: "PersonsBuilding",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonsBuilding_Building_BuildingID",
                table: "PersonsBuilding");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonsBuilding_Person_PersonID",
                table: "PersonsBuilding");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Floor");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonsBuilding",
                table: "PersonsBuilding");

            migrationBuilder.DropIndex(
                name: "IX_PersonsBuilding_BuildingID",
                table: "PersonsBuilding");

            migrationBuilder.RenameColumn(
                name: "BuildingID",
                table: "PersonsBuilding",
                newName: "pb_id");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "PersonsBuilding",
                newName: "Person_id");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "PersonsBuilding",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "FacilityID",
                table: "PersonsBuilding",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonsBuilding",
                table: "PersonsBuilding",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonsBuilding_FacilityID",
                table: "PersonsBuilding",
                column: "FacilityID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonsBuilding_Facility_FacilityID",
                table: "PersonsBuilding",
                column: "FacilityID",
                principalTable: "Facility",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

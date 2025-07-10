using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parking.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingLot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Floor = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Empty = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingLot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpotSizes",
                columns: table => new
                {
                    ParkingSpotId = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false, defaultValue: 3.0),
                    Length = table.Column<double>(type: "float", nullable: false, defaultValue: 5.0),
                    MaxVehicleHeight = table.Column<double>(type: "float", nullable: false, defaultValue: 2.2000000000000002)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpotSizes", x => x.ParkingSpotId);
                    table.ForeignKey(
                        name: "FK_ParkingSpotSizes_ParkingLot_ParkingSpotId",
                        column: x => x.ParkingSpotId,
                        principalTable: "ParkingLot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingSpotSizes");

            migrationBuilder.DropTable(
                name: "ParkingLot");
        }
    }
}

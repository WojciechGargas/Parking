using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parking.Migrations
{
    /// <inheritdoc />
    public partial class AdjustDatebase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingSpotSizes");

            migrationBuilder.AddColumn<double>(
                name: "Size_Length",
                table: "ParkingLot",
                type: "float",
                nullable: false,
                defaultValue: 5.0);

            migrationBuilder.AddColumn<double>(
                name: "Size_MaxVehicleHeight",
                table: "ParkingLot",
                type: "float",
                nullable: false,
                defaultValue: 2.2000000000000002);

            migrationBuilder.AddColumn<double>(
                name: "Size_Width",
                table: "ParkingLot",
                type: "float",
                nullable: false,
                defaultValue: 3.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size_Length",
                table: "ParkingLot");

            migrationBuilder.DropColumn(
                name: "Size_MaxVehicleHeight",
                table: "ParkingLot");

            migrationBuilder.DropColumn(
                name: "Size_Width",
                table: "ParkingLot");

            migrationBuilder.CreateTable(
                name: "ParkingSpotSizes",
                columns: table => new
                {
                    ParkingSpotId = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false, defaultValue: 5.0),
                    MaxVehicleHeight = table.Column<double>(type: "float", nullable: false, defaultValue: 2.2000000000000002),
                    Width = table.Column<double>(type: "float", nullable: false, defaultValue: 3.0)
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
    }
}

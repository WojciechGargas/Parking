using Microsoft.EntityFrameworkCore;

namespace Parking.Entities
{
    [Owned]
    public class ParkingSpotSize
    {
        public double Width { get; set; } = 3.0;
        public double Length { get; set; } = 5.0;
        public double MaxVehicleHeight { get; set; } = 2.2;
    }
}

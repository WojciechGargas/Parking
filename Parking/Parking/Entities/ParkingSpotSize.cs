using Microsoft.EntityFrameworkCore;

namespace Parking.Entities
{
    [Owned]
    public class ParkingSpotSize
    {
        public double Width { get; set; }
        public double Length { get; set; }
        public double MaxVehicleHeight { get; set; }
    }
}

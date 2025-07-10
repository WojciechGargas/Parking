namespace Parking.Dto
{
    public class ParkingSpotDto
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public ParkingSpotSizeDto Size { get; set; }
        public bool Empty { get; set; }
    }
}

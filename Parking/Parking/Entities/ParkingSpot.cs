namespace Parking.Entities
{
    public class ParkingSpot
    {
        public int Id { get; set; }
        public int Floor { get; set; } = 1;
        public ParkingSpotSize Size { get; set; }
        public bool Empty { get; set; } = true;

    }
}

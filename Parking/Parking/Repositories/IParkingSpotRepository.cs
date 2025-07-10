using Parking.Entities;

namespace Parking.Repositories
{
    public interface IParkingSpotRepository
    {
        public List<ParkingSpot> getAllSpots();
        public ParkingSpot getSpot(int id);
    }
}

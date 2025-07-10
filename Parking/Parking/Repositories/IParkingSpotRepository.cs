using Parking.Entities;

namespace Parking.Repositories
{
    public interface IParkingSpotRepository
    {
        public List<ParkingSpot> getAllSpots();
    }
}

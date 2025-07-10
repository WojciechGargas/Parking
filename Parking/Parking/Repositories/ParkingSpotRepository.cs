using Parking.Entities;

namespace Parking.Repositories
{
    public class ParkingSpotRepository(AppDbContext dbContext) : IParkingSpotRepository
    {
        public List<ParkingSpot> getAllSpots()
        {
            return dbContext.ParkingLot.ToList();
        }
    }
}

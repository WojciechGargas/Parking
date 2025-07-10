using Parking.Commands;
using Parking.Entities;

namespace Parking.Repositories
{
    public interface IParkingSpotRepository
    {
        public List<ParkingSpot> getAllSpots();
        public ParkingSpot getSpot(int id);
        public List<ParkingSpot> getEmptySpots();
        public List<ParkingSpot> getTakenSpots();
        public ParkingSpot ReserveSpot(int id);
        public ParkingSpot VacateSpot(int id);
        public void AddSpot(ParkingSpot spotToAdd);
        public void RemoveSpot(ParkingSpot spotToRemove);
    }
}

using Parking.Commands;
using Parking.Entities;

namespace Parking.Repositories
{
    public class ParkingSpotRepository(AppDbContext dbContext) : IParkingSpotRepository
    {
        public List<ParkingSpot> getAllSpots()
        {
            return dbContext.ParkingLot.ToList();
        }

        public ParkingSpot getSpot(int id)
        {
            return dbContext.ParkingLot.FirstOrDefault(p => p.Id == id);
        }

        public List<ParkingSpot> getEmptySpots()
        {
            return dbContext.ParkingLot.Where(p => p.Empty == true).ToList();
        }

        public List<ParkingSpot> getTakenSpots()
        {
            return dbContext.ParkingLot.Where(p => p.Empty == false).ToList();
        }

        public ParkingSpot ReserveSpot(int id)
        {
            var spotToReserve = dbContext.ParkingLot.FirstOrDefault(p => p.Id == id);
            spotToReserve.Empty = false;
            dbContext.SaveChanges();

            return spotToReserve;
        }

        public ParkingSpot VacateSpot(int id)
        {
            var spotToVacate = dbContext.ParkingLot.FirstOrDefault(p => p.Id == id);
            spotToVacate.Empty = true;
            dbContext.SaveChanges();

            return spotToVacate;
        }

        public void AddSpot(ParkingSpot spotToAdd)
        {
            dbContext.ParkingLot.Add(spotToAdd);
            dbContext.SaveChanges();
        }

        public void RemoveSpot(ParkingSpot spotToRemove)
        {
            dbContext.ParkingLot.Remove(spotToRemove);
            dbContext.SaveChanges();
        }
    }
}

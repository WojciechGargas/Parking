using Parking.Entities;

namespace Parking.Seeder
{
    public class ParkingSeeder
    {
        private readonly AppDbContext dboContext;

        public ParkingSeeder(AppDbContext dboContext)
        {
            this.dboContext = dboContext;
        }

        public void Seed()
        {
            if (dboContext.Database.CanConnect())
            {
                if (!dboContext.ParkingLot.Any())
                {
                    var spots = new List<ParkingSpot>();

                    for (int i = 0; i < 10; i++)
                    {
                        var spot = new ParkingSpot
                        {
                            Floor = 1,
                            Size = new ParkingSpotSize
                            {
                                Width = 3.0,
                                Length = 5.0,
                                MaxVehicleHeight = 2.2
                            },

                            Empty = true
                        };
                        spots.Add(spot);
                    }

                    dboContext.ParkingLot.AddRange(spots);
                    dboContext.SaveChanges();
                }
            }
        }
    }
}
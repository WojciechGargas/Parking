using Microsoft.AspNetCore.Mvc;
using Parking.Dto;
using Parking.Repositories;

namespace Parking.Services
{
    public interface IParkingSpotService
    {
        public List<ParkingSpotDto> GetAllSpots();
    }
    public class ParkingSpotService(IParkingSpotRepository parkingSpotRepository) : IParkingSpotService
    {
        public List<ParkingSpotDto> GetAllSpots()
        {
            var spots = parkingSpotRepository.getAllSpots();
            var spotsDto = spots.Select(p => new ParkingSpotDto()
            {
                Id = p.Id,
                Floor = p.Floor,
                Size = new ParkingSpotSizeDto()
                {
                    Width = p.Size.Width,
                    Length = p.Size.Length,
                    MaxVehicleHeight = p.Size.MaxVehicleHeight
                },
                Empty = p.Empty,
            }).ToList();
            return spotsDto;
        }
    }

}

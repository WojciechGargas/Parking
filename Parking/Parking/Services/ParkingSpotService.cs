using Microsoft.AspNetCore.Mvc;
using Parking.Dto;
using Parking.Repositories;

namespace Parking.Services
{
    public interface IParkingSpotService
    {
        public List<ParkingSpotDto> GetAllSpots();
        public ParkingSpotDto GetSpot(int id);
        public List<ParkingSpotDto> GetEmptySpots();
        public List<ParkingSpotDto> GetTakenSpots();
        public ParkingSpotDto ReserveSpot(int id);
        public ParkingSpotDto VacateSpot(int id);

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

        public ParkingSpotDto GetSpot(int id)
        {
            var spot = parkingSpotRepository.getSpot(id);
            var spotDto = new ParkingSpotDto()
            {
                Id = spot.Id,
                Floor = spot.Floor,
                Size = new ParkingSpotSizeDto()
                {
                    Width = spot.Size.Width,
                    Length = spot.Size.Length,
                    MaxVehicleHeight = spot.Size.MaxVehicleHeight
                },
                Empty = spot.Empty
            };
            return spotDto;
        }

        public List<ParkingSpotDto> GetEmptySpots()
        {
            var emptySpots = parkingSpotRepository.getEmptySpots();
            var emptySpotsDto = emptySpots.Select(p => new ParkingSpotDto()
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
            return emptySpotsDto;
        }

        public List<ParkingSpotDto> GetTakenSpots()
        {
            var takenSpots = parkingSpotRepository.getTakenSpots();
            var takenSpotsDto = takenSpots.Select(p => new ParkingSpotDto()
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
            return takenSpotsDto;
        }

        public ParkingSpotDto ReserveSpot(int id)
        {
            var spotToReserve = parkingSpotRepository.ReserveSpot(id);
            var spotToReserveDto = new ParkingSpotDto()
            {
                Id = spotToReserve.Id,
                Floor = spotToReserve.Floor,
                Size = new ParkingSpotSizeDto()
                {
                    Width = spotToReserve.Size.Width,
                    Length = spotToReserve.Size.Length,
                    MaxVehicleHeight = spotToReserve.Size.MaxVehicleHeight
                },
                Empty = spotToReserve.Empty
            };

            return spotToReserveDto;
        }

        public ParkingSpotDto VacateSpot(int id)
        {
            var spotToVacate = parkingSpotRepository.VacateSpot(id);
            var spotToVacateDto = new ParkingSpotDto()
            {
                Id = spotToVacate.Id,
                Floor = spotToVacate.Floor,
                Size = new ParkingSpotSizeDto()
                {
                    Width = spotToVacate.Size.Width,
                    Length = spotToVacate.Size.Length,
                    MaxVehicleHeight = spotToVacate.Size.MaxVehicleHeight
                },
                Empty = spotToVacate.Empty
            };

            return spotToVacateDto;
        }
    }
    

}

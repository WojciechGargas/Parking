using Microsoft.AspNetCore.Mvc;
using Parking.Dto;
using Parking.Entities;
using Parking.Repositories;
using Parking.Services;

namespace Parking.Controllers
{
    [ApiController]
    [Route("api/park")]
    public class ParkingSpotController(IParkingSpotService parkingSpotService) : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ParkingSpotDto>> GetAllSpots()
        {
            var spots = parkingSpotService.GetAllSpots();
            return Ok(spots);
        }

        [HttpGet("/{id}")]
        public ActionResult<ParkingSpotDto> GetSpot([FromRoute] int id)
        {
            var spot = parkingSpotService.GetSpot(id);
            if (spot is null)
            {
                return NotFound();
            }

            return Ok(spot);
        }

        [HttpGet("/empty")]
        public ActionResult<List<ParkingSpotDto>> GetEmptySpots()
        {
            var emptySpots = parkingSpotService.GetEmptySpots();
            return Ok(emptySpots);
        }

        [HttpGet("/taken")]
        public ActionResult<List<ParkingSpotDto>> GetTakenSpots()
        {
            var takenSpots = parkingSpotService.GetTakenSpots();
            return Ok(takenSpots);
        }

        [HttpPatch("reserve/{id}")]
        public ActionResult<ParkingSpotDto> ReserveSpot([FromRoute] int id)
        {
            var spotToReserve = parkingSpotService.ReserveSpot(id);
            if (spotToReserve is null)
            {
                return NotFound();
            }

            return Ok(spotToReserve);
        }

        [HttpPatch("vacate/{id}")]
        public ActionResult<ParkingSpotDto> VacateSpot([FromRoute] int id)
        {
            var spotToVacate = parkingSpotService.VacateSpot(id);
            if (spotToVacate is null)
            {
                return NotFound();
            }

            return Ok(spotToVacate);
        }
    }

    
}

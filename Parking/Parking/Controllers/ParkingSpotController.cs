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
    }

    
}

using System.Reflection.Metadata.Ecma335;
using Parking.Entities;

namespace Parking.Commands
{
    public class AddSpotCommand
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public ParkingSpotSize Size { get; set; }
        public bool Empty { get; set; }
    }
}

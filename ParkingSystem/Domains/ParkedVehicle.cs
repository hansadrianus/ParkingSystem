using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSystem.Domains.Interfaces;

namespace ParkingSystem.Domains
{
    public class ParkedVehicle : IParkedVehicle
    {
        public ParkedVehicle()
        {

        }

        public int Slot { get; set; }
        public string VehicleNo { get; set; }
        public string VehicleType { get; set; }
        public string VehicleColor { get; set; }
    }
}

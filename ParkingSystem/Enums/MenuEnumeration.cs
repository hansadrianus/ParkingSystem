using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Enums
{
    public enum MenuEnumeration
    {
        [Description("1. Input Slot")]
        InputSlot = 1,
        [Description("2. Park Vehicle")]
        ParkVehicle = 2,
        [Description("3. Leave Vehicle")]
        LeaveVehicle = 3,
        [Description("4. Get Parked Vehicle By Type")]
        GetParkedVehicleByType = 4,
        [Description("5. Get Parked Vehicle By Odd/Even Plate")]
        GetParkedVehicleByOddEvenPlate = 5,
        [Description("6. Get Parked Vehicle By Color")]
        GetParkedVehicleByColor = 6,
        [Description("7. Get Parked Vehicle By Plate Number")]
        GetParkedVehicleByPlateNumber = 7,
        [Description("8. Status")]
        Status = 8
    }
}

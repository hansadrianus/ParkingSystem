using ConsoleTables;
using ParkingSystem.Domains.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Commands
{
    public class ExportReportCommand : IExportReportCommand
    {
        private IList<IParkedVehicle> _parkedVehicles;

        public ExportReportCommand(IList<IParkedVehicle> parkedVehicles)
        {
            _parkedVehicles = parkedVehicles;
        }

        public ConsoleTable PopulateDataToConsoleTable()
        {
            ConsoleTable table = new ConsoleTable("Slot", "No.", "Type", "Registration No Colour");
            foreach (IParkedVehicle vehicle in _parkedVehicles)
            {
                table.AddRow(vehicle.Slot, vehicle.VehicleNo, vehicle.VehicleType, vehicle.VehicleColor);
            }

            return table;
        }
    }
}

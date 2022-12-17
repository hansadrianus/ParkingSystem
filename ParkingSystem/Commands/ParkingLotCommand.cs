using ParkingSystem.Domains.Interfaces;
using ParkingSystem.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ParkingSystem.Commands.Interfaces;

namespace ParkingSystem.Commands
{
    public class ParkingLotCommand : IParkingLotCommand
    {
        private IList<IParkedVehicle> _parkedVehicles;

        public ParkingLotCommand(IList<IParkedVehicle> parkedVehicles)
        {
            _parkedVehicles = parkedVehicles;
        }

        public int LeaveVehicle(IList<IParkedVehicle> parkingLots)
        {
            Console.Write("Input slot to leave: ");
            if (int.TryParse(Console.ReadLine(), out int slot))
            {
                IParkedVehicle vehicle = parkingLots.FirstOrDefault(q => q.Slot == slot);
                if (vehicle == null)
                    return slot;

                _parkedVehicles.Remove(vehicle);

                return vehicle.Slot;
            }
            else
                return LeaveVehicle(parkingLots);
        }

        public int ParkVehicle(IList<IParkedVehicle> parkingLots)
        {
            Console.Write("Input vehicle data: ");
            string input = Console.ReadLine();
            string[] vehicleData = input.Split(" ");
            IParkedVehicle vehicle = new ParkedVehicle()
            {
                Slot = GetAvailableSlot(parkingLots),
                VehicleNo = vehicleData[0],
                VehicleColor = vehicleData[1],
                VehicleType = vehicleData[2],
            };

            _parkedVehicles.Add(vehicle);

            return vehicle.Slot;
        }

        public IList<IParkedVehicle> RetrieveParkedVehicleByColor(string criteria)
        {
            return _parkedVehicles.Where(q => q.VehicleColor.ToLower() == criteria.ToLower()).ToList();
        }

        public IList<IParkedVehicle> RetrieveParkedVehicleByOddEvenPlate(string criteria)
        {
            IList<IParkedVehicle> parkedVehicles = new List<IParkedVehicle>();
            foreach (IParkedVehicle vehicle in _parkedVehicles)
            {
                int number = Int32.Parse(Regex.Match(vehicle.VehicleNo, @"\d+").Value);
                if (number % 2 == 0 && criteria.ToLower() == "even")
                    parkedVehicles.Add(vehicle);
                if (number % 2 != 0 && criteria.ToLower() == "odd")
                    parkedVehicles.Add(vehicle);
            }

            return parkedVehicles;
        }

        public IList<IParkedVehicle> RetrieveParkedVehicleByPlateNumber(string criteria)
        {
            return _parkedVehicles.Where(q => q.VehicleNo.ToLower() == criteria.ToLower()).ToList();
        }

        public IList<IParkedVehicle> RetrieveParkedVehicleByType(string criteria)
        {
            return _parkedVehicles.Where(q => q.VehicleType.ToLower() == criteria.ToLower()).ToList();
        }

        public int SetParkingSlot()
        {
            Console.Write("Insert number of slot(s): ");
            if (int.TryParse(Console.ReadLine(), out int slot))
                return slot;

            Console.WriteLine("Invalid input.");
            return SetParkingSlot();
        }

        private int GetAvailableSlot(IList<IParkedVehicle> parkingLots)
        {
            int num = 1;
            for (int i = num; i <= parkingLots.Count; i++)
            {
                bool isEqual = parkingLots[i - 1].Slot == i;
                if (!isEqual)
                    return i;

                num++;
            }

            return num;
        }
    }
}

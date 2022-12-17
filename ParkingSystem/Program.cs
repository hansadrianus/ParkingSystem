using ConsoleTables;
using ParkingSystem.Commands;
using ParkingSystem.Domains;
using ParkingSystem.Domains.Interfaces;
using System.Data;

namespace ParkingSystem
{
    internal class Program
    {
        private static int ParkSlot { get; set; } = 0;
        private static IList<IParkedVehicle> ParkingLots { get; set; }

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Parking System!");
                int menuNum = SelectMenu();
                if (ParkingLots != null)
                    ParkingLots = ParkingLots.OrderBy(q => q.Slot).ToList();
                if (menuNum > 1 && ParkingLots == null)
                {
                    Console.WriteLine("Parking lot is null");
                    continue;
                }
                ParkingLotCommand parkCommand = new ParkingLotCommand(ParkingLots);

                switch (menuNum)
                {
                    case 1:
                        Console.WriteLine();
                        if (ParkSlot > 0)
                            continue;

                        ParkSlot = parkCommand.SetParkingSlot();
                        ParkingLots = new List<IParkedVehicle>(ParkSlot);
                        Console.WriteLine($"Created a parking lot with {ParkSlot} slots");
                        continue;
                    case 2:
                        Console.WriteLine();
                        if (ParkingLots.Count != ParkSlot)
                        {
                            int allocatedSlot = parkCommand.ParkVehicle(ParkingLots);
                            Console.WriteLine($"Allocated slot number: {allocatedSlot}");
                        }
                        else
                            Console.WriteLine("Sorry, parking lot is full");
                        continue;
                    case 3:
                        Console.WriteLine();
                        if (ParkingLots.Count != 0)
                        {
                            int slotToRemove = parkCommand.LeaveVehicle(ParkingLots);
                            Console.WriteLine($"Slot number {slotToRemove} is free");
                        }
                        else
                            Console.WriteLine("There is no vehicle parking");
                        continue;
                    case 4:
                        Console.WriteLine();
                        Console.Write("Type: ");
                        IList<IParkedVehicle> vehiclesWithType = parkCommand.RetrieveParkedVehicleByType(Console.ReadLine());
                        Console.WriteLine(vehiclesWithType.Count);
                        continue;
                    case 5:
                        Console.WriteLine();
                        Console.Write("Odd or Even: ");
                        IList<IParkedVehicle> oddEvenVehicles = parkCommand.RetrieveParkedVehicleByOddEvenPlate(Console.ReadLine());
                        Console.WriteLine(string.Join(", ", oddEvenVehicles.Select(q => q.VehicleNo)));
                        continue;
                    case 6:
                        Console.WriteLine();
                        Console.Write("Color: ");
                        IList<IParkedVehicle> colorVehicles = parkCommand.RetrieveParkedVehicleByColor(Console.ReadLine());
                        Console.WriteLine(string.Join(", ", colorVehicles.Select(q => q.Slot)));
                        Console.WriteLine(colorVehicles.Count);
                        continue;
                    case 7:
                        Console.WriteLine();
                        Console.Write("Plate number: ");
                        IList<IParkedVehicle> oddEvenVehicle = parkCommand.RetrieveParkedVehicleByPlateNumber(Console.ReadLine());
                        if (oddEvenVehicle.Count > 0)
                            Console.WriteLine(string.Join(", ", oddEvenVehicle.Select(q => q.Slot)));
                        else
                            Console.WriteLine("Not found");
                        continue;
                    case 8:
                        Console.WriteLine();
                        ConsoleTable table = new ExportReportCommand(ParkingLots).PopulateDataToConsoleTable();
                        Console.WriteLine(table);
                        continue;
                    default:
                        Console.Clear();
                        Console.WriteLine("Application destroyed");
                        break;
                }
                break;
            } while (true);
        }

        #region Private Methods
        private static int SelectMenu()
        {
            Console.WriteLine("1. Input Slot");
            Console.WriteLine("2. Park Vehicle");
            Console.WriteLine("3. Leave Vehicle");
            Console.WriteLine("4. Get Parked Vehicle By Types");
            Console.WriteLine("5. Get Parked Vehicle By Odd/Even Plate");
            Console.WriteLine("6. Get Parked Vehicle By Color");
            Console.WriteLine("7. Get Parked Vehicle By Plate Number");
            Console.WriteLine("8. Status");
            Console.WriteLine("");
            Console.Write("Select menu: ");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                Console.Clear();
                return num;
            }

            Console.Clear();
            return SelectMenu();
        }
        #endregion
    }
}
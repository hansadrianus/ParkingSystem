using ConsoleTables;
using ParkingSystem.Commands;
using ParkingSystem.Domains;
using ParkingSystem.Domains.Interfaces;
using ParkingSystem.Enums;
using ParkingSystem.Extensions;
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
                Console.WriteLine();

                switch ((MenuEnumeration)menuNum)
                {
                    case MenuEnumeration.InputSlot:
                        if (ParkSlot > 0)
                            continue;

                        ParkSlot = parkCommand.SetParkingSlot();
                        ParkingLots = new List<IParkedVehicle>(ParkSlot);
                        Console.WriteLine($"Created a parking lot with {ParkSlot} slots");
                        continue;
                    case MenuEnumeration.ParkVehicle:
                        if (ParkingLots.Count != ParkSlot)
                            Console.WriteLine($"Allocated slot number: {parkCommand.ParkVehicle(ParkingLots)}");
                        else
                            Console.WriteLine("Sorry, parking lot is full");
                        continue;
                    case MenuEnumeration.LeaveVehicle:
                        if (ParkingLots.Count != 0)
                            Console.WriteLine($"Slot number {parkCommand.LeaveVehicle(ParkingLots)} is free");
                        else
                            Console.WriteLine("There is no vehicle parking");
                        continue;
                    case MenuEnumeration.GetParkedVehicleByType:
                        Console.Write("Type: ");
                        IList<IParkedVehicle> vehiclesWithType = parkCommand.RetrieveParkedVehicleByType(Console.ReadLine());
                        Console.WriteLine(vehiclesWithType.Count);
                        continue;
                    case MenuEnumeration.GetParkedVehicleByOddEvenPlate:
                        Console.Write("Odd or Even: ");
                        IList<IParkedVehicle> oddEvenVehicles = parkCommand.RetrieveParkedVehicleByOddEvenPlate(Console.ReadLine());
                        Console.WriteLine(string.Join(", ", oddEvenVehicles.Select(q => q.VehicleNo)));
                        continue;
                    case MenuEnumeration.GetParkedVehicleByColor:
                        Console.Write("Color: ");
                        IList<IParkedVehicle> colorVehicles = parkCommand.RetrieveParkedVehicleByColor(Console.ReadLine());
                        Console.WriteLine(string.Join(", ", colorVehicles.Select(q => q.Slot)));
                        Console.WriteLine(colorVehicles.Count);
                        continue;
                    case MenuEnumeration.GetParkedVehicleByPlateNumber:
                        Console.Write("Plate number: ");
                        IList<IParkedVehicle> oddEvenVehicle = parkCommand.RetrieveParkedVehicleByPlateNumber(Console.ReadLine());
                        if (oddEvenVehicle.Count > 0)
                            Console.WriteLine(string.Join(", ", oddEvenVehicle.Select(q => q.Slot)));
                        else
                            Console.WriteLine("Not found");
                        continue;
                    case MenuEnumeration.Status:
                        ConsoleTable table = new ExportReportCommand(ParkingLots).PopulateDataToConsoleTable();
                        Console.WriteLine(table);
                        continue;
                    default:
                        Console.WriteLine("Application destroyed");
                        break;
                }
                break;
            } while (true);
        }

        #region Private Methods
        private static int SelectMenu()
        {
            foreach (MenuEnumeration item in Enum.GetValues(typeof(MenuEnumeration)))
            {
                Console.WriteLine(item.GetDescription());
            }

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
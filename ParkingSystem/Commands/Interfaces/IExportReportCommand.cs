using ConsoleTables;

namespace ParkingSystem.Commands.Interfaces
{
    public interface IExportReportCommand
    {
        ConsoleTable PopulateDataToConsoleTable();
    }
}
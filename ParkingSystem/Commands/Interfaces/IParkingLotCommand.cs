using ParkingSystem.Domains.Interfaces;

namespace ParkingSystem.Commands.Interfaces
{
    public interface IParkingLotCommand
    {
        int LeaveVehicle(IList<IParkedVehicle> parkingLots);
        int ParkVehicle(IList<IParkedVehicle> parkingLots);
        IList<IParkedVehicle> RetrieveParkedVehicleByColor(string criteria);
        IList<IParkedVehicle> RetrieveParkedVehicleByOddEvenPlate(string criteria);
        IList<IParkedVehicle> RetrieveParkedVehicleByPlateNumber(string criteria);
        IList<IParkedVehicle> RetrieveParkedVehicleByType(string criteria);
        int SetParkingSlot();
    }
}
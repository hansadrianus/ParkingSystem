namespace ParkingSystem.Domains.Interfaces
{
    public interface IParkedVehicle
    {
        int Slot { get; set; }
        string VehicleColor { get; set; }
        string VehicleNo { get; set; }
        string VehicleType { get; set; }
    }
}
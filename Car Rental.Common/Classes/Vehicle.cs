using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Vehicle : IVehicle
{
    public int Id { get; set; }
    public string RegNo { get; set; }
    public string Make { get; set; }
    public int Odometer { get; set; }
    public double CostKm { get; set; }

    public double CostDay { get; set; }
    public VehicleTypes VehicleType { get; set; }
    public VehicleStatuses VehicleStatus { get; set; }

    public Vehicle(int id, string regNo, string make, int odometer, double costKm, VehicleTypes vehicleType, double costDay, VehicleStatuses vehicleStatus)
    {
        Id = id;
        RegNo = regNo;
        Make = make;
        Odometer = odometer;
        CostKm = costKm;
        VehicleType = vehicleType;
        CostDay = costDay;
        VehicleStatus = vehicleStatus;
    }
    public Vehicle()
    {
        
    }
}

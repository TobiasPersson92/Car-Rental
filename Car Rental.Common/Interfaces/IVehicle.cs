using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IVehicle
{
    public string RegNo { get; set; }
    public string Make { get; set; }
    public int Odometer { get; set; }
    public double CostKm { get; set; }

    public double CostDay { get; set; }
    public VehicleTypes VehicleType{ get; set; }
    public VehicleStatuses VehicleStatus{ get; set; }


}

using Car_Rental.Common.Classes;

namespace Car_Rental.Common.Extensions;

public static class VehicleExtensions
{
    public static double BookingCost(this int days, double costDay, int distance, double costKm)
    {
        return (days * costDay) + (distance * costKm);
    }
}

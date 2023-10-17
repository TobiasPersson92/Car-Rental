using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System.Runtime.Serialization;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public int BookingId { get; set; }
    public IPerson Persons { get; set; }
    public IVehicle Vehicles { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime ReturnDate { get; set; } = DateTime.Now;
    public double Cost { get; set; }
    public int Distance { get; set; }

    public Booking(int bookingId, IPerson person, IVehicle vehicle, DateTime rentDate)
    {
        BookingId = bookingId;
        Persons = person;
        Vehicles = vehicle;
        RentDate = rentDate;
    }
    public Booking(int bookingId, IPerson person, IVehicle vehicle, DateTime rentDate, double cost)
    {
        BookingId = bookingId;
        Persons = person;
        Vehicles = vehicle;
        RentDate = rentDate;
        Cost = cost;
    }

    public void ReturnVehicle(IVehicle vehicle, int distance)
    {
        ReturnDate = DateTime.Now;
        var days = (ReturnDate == RentDate) ? 1 : (ReturnDate - RentDate).Days;
        Cost = (days * vehicle.CostDay) + (distance * vehicle.CostKm);
        Vehicles.VehicleStatus = VehicleStatuses.Available;
    }
}

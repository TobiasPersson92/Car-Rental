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
    public int KmRented { get; init; }
    public BookingStatuses BookingStatus { get; set; }

    public Booking(int bookingId, IPerson person, IVehicle vehicle, DateTime rentDate, BookingStatuses bookingStatus)
    {
        BookingId = bookingId;
        Persons = person;
        Vehicles = vehicle;
        RentDate = rentDate;
        KmRented = Vehicles.Odometer;
        BookingStatus = bookingStatus;
    }
    public Booking(int bookingId, IPerson person, IVehicle vehicle, DateTime rentDate, double cost, BookingStatuses bookingStatus)
    {
        BookingId = bookingId;
        Persons = person;
        Vehicles = vehicle;
        RentDate = rentDate;
        Cost = cost;
        KmRented = Vehicles.Odometer;
        BookingStatus = bookingStatus;
    }
    public Booking()
    {
        
    }

}

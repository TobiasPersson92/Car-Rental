namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    public int BookingId { get; set; }
    public IPerson Persons { get; set; }
    public IVehicle Vehicles { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public double Cost { get; set; }
    public int Distance { get; set; }

}

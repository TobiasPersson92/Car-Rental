using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class InputStorage
{
    public IVehicle Vehicle { get; set; }
    public IPerson Person { get; set; }
    public IBooking Booking { get; set; }

    public InputStorage()
    {
        Vehicle = new Vehicle();
        Person = new Customer();
        Booking = new Booking();
    }
}

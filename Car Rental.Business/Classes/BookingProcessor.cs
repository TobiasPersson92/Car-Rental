using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System.Linq;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    private readonly IData _db;
    public BookingProcessor(IData db) => _db = db;
    public IEnumerable<Customer> GetCustomers()
    {
        return _db.GetPersons().Cast<Customer>();
    }
    public IEnumerable<IVehicle> GetVehicles() 
    {  
        return _db.GetVehicles();
    }
    public IEnumerable<IBooking> GetBookings() 
    {
        return _db.GetBookings();
    }
    
}

using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System.Linq.Expressions;

namespace Car_Rental.Data.Interfaces;

public interface IData
{
    List<T> Get<T>(Expression<Func<T, bool>>? expression);
    T? Single<T>(Expression<Func<T, bool>>? expression);
    public void Add<T>(T item);
    int NextVehicleId { get; }
    int NextPersonId { get; }
    int NextBookingId { get; }
    IBooking RentVehicle(int vehicleId, int customerId);
    IBooking ReturnVehicle(int vehicleId);
    // Default Interface Methods
    //public string[] VehicleStatusNames => Retunera enum konstanterna
    //public string[] VehicleTypeNames => Retunera enum konstanterna
    //public VehicleTypes GetVehicleType(string name) => Retunera en enum konstants värde med hjälp av konstantens namn
    IEnumerable<IPerson> GetPersons();
    IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default);
    IEnumerable<IBooking> GetBookings();
}

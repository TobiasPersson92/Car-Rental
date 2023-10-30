using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System.Linq.Expressions;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{
    readonly List<IPerson> _persons = new List<IPerson>();
    readonly List<IVehicle> _vehicles = new List<IVehicle>();
    readonly List<IBooking> _bookings = new List<IBooking>();

    public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(b => b.Id) + 1;

    public int NextPersonId => _persons.Count.Equals(0) ? 1 : _persons.Max(b => b.Id) + 1;

    public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.BookingId) + 1;
    public CollectionData() => SeedData();

    void SeedData()
    {
        //Seed customers
        _persons.Add(new Customer(NextPersonId, 12345, "John", "Doe"));
        _persons.Add(new Customer(NextPersonId, 98765, "Jane", "Doe"));

        //Seed vehicles
        _vehicles.Add(new Car(NextVehicleId, "ABC123", "Volvo", 10000, 1, VehicleTypes.Combi, 200, VehicleStatuses.Available));
        _vehicles.Add(new Car(NextVehicleId, "DEF456", "Saab", 20000, 1, VehicleTypes.Sedan, 100, VehicleStatuses.Available));
        _vehicles.Add(new Car(NextVehicleId, "GHI789", "Tesla", 1000, 3, VehicleTypes.Combi, 100, VehicleStatuses.Booked));
        _vehicles.Add(new Car(NextVehicleId, "JKL012", "Jeep", 5000, 1.5, VehicleTypes.Van, 300, VehicleStatuses.Available));
        _vehicles.Add(new Motorcycle(NextVehicleId, "MNO234", "Yamaha", 30000, 0.5, VehicleTypes.Motorcycle, 50, VehicleStatuses.Available));

        //Seed bookings
        _bookings.Add(new Booking(NextBookingId, _persons.First(p => p.Ssn == 12345), _vehicles.First(v => v.RegNo == "GHI789"), DateTime.Now, BookingStatuses.Open));
        _bookings.Add(new Booking(NextBookingId, _persons.First(p => p.Ssn == 98765), _vehicles.First(v => v.RegNo == "JKL012"),
            DateTime.Now, _vehicles.First(v => v.RegNo == "JKL012").CostDay, BookingStatuses.Closed));
    }

    public IEnumerable<IPerson> GetPersons() => _persons;
    public IEnumerable<IBooking> GetBookings() => _bookings;

    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = VehicleStatuses.Available) => _vehicles;

    public List<T> Get<T>(Expression<Func<T, bool>>? expression)
    {
        throw new NotImplementedException();
    }

    public T? Single<T>(Expression<Func<T, bool>>? expression)
    {
        throw new NotImplementedException();
    }

    public void Add<T>(T item)
    {
        if (item is IPerson)
        {
            _persons.Add((IPerson)item);
        }
        else if (item is Vehicle)
        {
            _vehicles.Add((IVehicle)item);
        }
        else if (item is Booking)
        {
            _bookings.Add((IBooking)item);
        }
    }

    public IBooking RentVehicle(int vehicleId, int customerId)
    {
        throw new NotImplementedException();
    }

    public IBooking ReturnVehicle(int vehicleId)
    {
        throw new NotImplementedException();
    }


    //Get- + Single-metoder
    /*
     var collections = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
     .FirstOrDefault(f => f.FieldType == typeof(List<T>) && f.IsInitOnly)
     ?? throw new InvalidOperationException("Unsupported type");

     var value = collections.GetValue(this) ?? throw new InvalidDataException

     var collection = ((List<T>)value).AsQueryable();

     if (expression is null) return collection.ToList();

     return collection.Where(expression).ToList();
     */
}

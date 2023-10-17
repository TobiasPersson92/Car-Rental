using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{
    readonly List<IPerson> _persons = new List<IPerson>();
    readonly List<IVehicle> _vehicles = new List<IVehicle>();
    readonly List<IBooking> _bookings = new List<IBooking>();

    public CollectionData() => SeedData();

    void SeedData()
    {
        //Seed customers
        _persons.Add(new Customer(12345, "John", "Doe"));
        _persons.Add(new Customer(98765, "Jane", "Doe"));

        //Seed vehicles
        _vehicles.Add(new Car("ABC123", "Volvo", 10000, 1, VehicleTypes.Combi, 200, VehicleStatuses.Available));
        _vehicles.Add(new Car("DEF456", "Saab", 20000, 1, VehicleTypes.Sedan, 100, VehicleStatuses.Available));
        _vehicles.Add(new Car("GHI789", "Tesla", 1000, 3, VehicleTypes.Combi, 100, VehicleStatuses.Booked));
        _vehicles.Add(new Car("JKL012", "Jeep", 5000, 1.5, VehicleTypes.Van, 300, VehicleStatuses.Available));
        _vehicles.Add(new Motorcycle("MNO234", "Yamaha", 30000, 0.5, VehicleTypes.Motorcycle, 50, VehicleStatuses.Available));

        //Seed bookings
        _bookings.Add(new Booking(_bookings.Count + 1, _persons.First(p => p.Ssn == 12345), _vehicles.First(v => v.RegNo == "GHI789"), DateTime.Now));
        _bookings.Add(new Booking(_bookings.Count + 1, _persons.First(p => p.Ssn == 98765), _vehicles.First(v => v.RegNo == "JKL012"),
            DateTime.Now, _vehicles.First(v => v.RegNo == "JKL012").CostDay));
    }

    public IEnumerable<IPerson> GetPersons() => _persons;
    public IEnumerable<IBooking> GetBookings() => _bookings;

    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = VehicleStatuses.Available) => _vehicles;

}

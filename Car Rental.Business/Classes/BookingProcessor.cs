using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Extensions;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    private readonly IData _db;
    public BookingProcessor(IData db) => _db = db;
    public string Message { get; set; } = string.Empty;
    public bool Disabled { get; set; } = false;
    public IEnumerable<Customer> GetCustomers()
    {
        return _db.GetPersons().Cast<Customer>();
    }
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) 
    {  
        return _db.GetVehicles();
    }
    public IEnumerable<IBooking> GetBookings() 
    {
        return _db.GetBookings();
    }
    public async Task RentVehicle(int vehicleId, int customerId)
    {
        try
        {
            if (GetVehicle(vehicleId) == null || GetPerson(customerId) == null)
            {
                Message = "You must chose a valid vehicle and customer";
                return;
            }
            Disabled = true;
            await Task.Delay(3000);

            _db.Add<IBooking>(new Booking(_db.NextBookingId,
            GetPerson(customerId),
            GetVehicle(vehicleId),
            DateTime.Now,
            BookingStatuses.Open));
            GetVehicle(vehicleId).VehicleStatus = VehicleStatuses.Booked;

            Disabled = false;
        }
        catch (Exception ex)
        {

            Message = ex.Message;
        }
        
    }

    public void ReturnVehicle(int vehicleId, int distance) 
    {
        try
        {
            
            var booking = GetBookings(vehicleId);
            if (booking == null)
            {
                Message = "No booking found";
                return;
            }
            if (distance < 0) 
            {
                Message = "Distance must be at least 0";
                return;
            }

            booking.ReturnDate = DateTime.Now;
            var days = (booking.ReturnDate.ToShortDateString() == booking.RentDate.ToShortDateString()) ? 1 : (booking.ReturnDate - booking.RentDate).Days;
            booking.Cost = days.BookingCost(booking.Vehicles.CostDay, distance, booking.Vehicles.CostKm);

            booking.Distance = distance;
            booking.Vehicles.Odometer += distance;
            booking.Vehicles.VehicleStatus = VehicleStatuses.Available;
            booking.BookingStatus = BookingStatuses.Closed;
        }
        catch (Exception ex)
        {

            Message = ex.Message;
        }
        
    }

    public IPerson? GetPerson(int id) 
    {
        return _db.Get<IPerson>(p => p.Id == id).FirstOrDefault();
    }
    public IVehicle? GetVehicle(int vehicleId) 
    {
        return _db.Get<IVehicle>(v => v.Id == vehicleId).FirstOrDefault();
    }
    public IBooking? GetBookings(int vehicleId)
    {
        return _db.Get<IBooking>(b => b.Vehicles.Id == vehicleId && b.BookingStatus == BookingStatuses.Open).FirstOrDefault();
    }
    public void AddCustomer(IPerson person)
    {
        try
        {
            Message = string.Empty;
            if (person.Ssn < 10000 || person.Ssn > 99999)
            {
                Message = "SSN must be 5 numbers long";
                return;
            }

            if (string.IsNullOrWhiteSpace(person.FirstName) || string.IsNullOrWhiteSpace(person.LastName))
            {
                Message = "Enter a first and a last name";
                return;
            }
            _db.Add<IPerson>(new Customer(_db.NextPersonId, person.Ssn, person.FirstName, person.LastName));
        }
        catch (Exception ex)
        {

            Message = ex.Message;
        }
        
        
        
    }
    public void AddVehicle(IVehicle vehicle)
    {
        try
        {
            Message = string.Empty;
            if (string.IsNullOrWhiteSpace(vehicle.RegNo) || vehicle.RegNo.Length != 6)
            {
                Message = "RegNo needs to have a length of 6";
                return;
            }
            if (string.IsNullOrWhiteSpace(vehicle.Make))
            {
                Message = "Add a make to the vehicle";
                return;
            }
            if (vehicle.Odometer < 1)
            {
                Message = "Odometer can't be 0";
                return;
            }
            if (vehicle.CostKm <= 0)
            {
                Message = "Enter a CostKm greater than 0";
                return;
            }
            if (vehicle.CostDay <= 0)
            {
                Message = "Enter a CostDay greater than 0";
                return;
            }

            _db.Add<IVehicle>(new Vehicle(_db.NextVehicleId, vehicle.RegNo, vehicle.Make, vehicle.Odometer, vehicle.CostKm, vehicle.VehicleType, vehicle.CostDay, vehicle.VehicleStatus));
        }
        catch (Exception ex)
        {

            Message = ex.Message;
        }
        
    }
    
}

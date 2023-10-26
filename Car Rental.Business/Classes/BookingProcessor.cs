using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System;
using System.Linq;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    private readonly IData _db;
    public BookingProcessor(IData db) => _db = db;
    public string Message { get; set; } = string.Empty;
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
    public void RentVehicle(int vehicleId, int customerId)
    {
        Message = $"vehicle id: {vehicleId} customerId: {customerId}";
        _db.Add<Booking>(new Booking(_db.NextBookingId,
            GetPerson(customerId),
            GetVehicle(vehicleId),
            DateTime.Now));
        GetVehicle(vehicleId).VehicleStatus = VehicleStatuses.Booked;
    }

    public IPerson? GetPerson(int id) 
    { 
        return _db.GetPersons().Where(p => p.Id == id).FirstOrDefault();
    }
    public IVehicle? GetVehicle(int vehicleId) 
    {
        return _db.GetVehicles().Where(v => v.Id == vehicleId).FirstOrDefault();
    }
    public void AddCustomer(IPerson person)
    {
        try
        {
            //Message = string.Empty;
            //if (person.Ssn < 10000 || person.Ssn > 99999)
            //{
            //    Message = "SSN must be 5 numbers long";
            //    return;
            //}

            //if (string.IsNullOrWhiteSpace(person.FirstName) || string.IsNullOrWhiteSpace(person.LastName))
            //{
            //    Message = "Enter a first and a last name";
            //    return;
            //}
            _db.Add<Customer>(new Customer(_db.NextPersonId, person.Ssn, person.FirstName, person.LastName));
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
            //Message = string.Empty;
            //if (string.IsNullOrWhiteSpace(vehicle.RegNo) || vehicle.RegNo.Length != 6)
            //{
            //    Message = "RegNo needs to have a length of 6";
            //    return;
            //}
            //if (string.IsNullOrWhiteSpace(vehicle.Make))
            //{
            //    Message = "Add a make to the vehicle";
            //    return;
            //}
            //if (vehicle.Odometer < 1)
            //{
            //    Message = "Odometer can't be 0";
            //    return;
            //}
            //if (vehicle.CostKm <= 0)
            //{
            //    Message = "Enter a CostKm greater than 0";
            //    return;
            //}
            //if (vehicle.CostDay <= 0)
            //{
            //    Message = "Enter a CostDay greater than 0";
            //    return;
            //}

            _db.Add<Vehicle>(new Vehicle(_db.NextVehicleId, vehicle.RegNo, vehicle.Make, vehicle.Odometer, vehicle.CostKm, vehicle.VehicleType, vehicle.CostDay, vehicle.VehicleStatus));
        }
        catch (Exception ex)
        {

            Message = ex.Message;
        }
        
    }
    
}

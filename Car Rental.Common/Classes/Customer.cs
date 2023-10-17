﻿using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Customer : IPerson
{
    public int Ssn { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Customer(int ssn, string firstName, string lastName)
    {
        Ssn = ssn;
        FirstName = firstName;
        LastName = lastName;
    }
}

using System;
using EventEase2.Models;

namespace EventEase2
{
    // Represents a booking made for an event at a specific venue
    public class Bookings
    {
        // Primary key: Unique identifier for each booking
        public int BookingsId { get; set; }

        // The date and time the booking was made or scheduled for
        public DateTime BookingsDate { get; set; }

        // Foreign key: Links the booking to a specific event
        public int EventId { get; set; }

        // Navigation property: Represents the associated event
        public required Models.Event Event { get; set; }

        // Foreign key: Links the booking to a specific venue
        public int VenueId { get; set; }

        // Navigation property: Represents the associated venue
        public required Venues Venues { get; set; }

        // The full name of the customer who made the booking
        public required string CustomerName { get; set; }

        // The email address of the customer
        public required string CustomerEmail { get; set; }

        // The phone number of the customer
        public required string CustomerPhone { get; set; }
    }
}





//Reference List for code:

//Date: 23 june 2025

//Author: Darsh Somayi

//Sourced: Harrison, W., 2022. Azure for Developers: Implement rich Azure PaaS ecosystems using containers, serverless services, and more. Packt Publishing.


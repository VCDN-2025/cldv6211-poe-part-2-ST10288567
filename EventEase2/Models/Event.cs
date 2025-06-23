using EventEase2.Models;
using System;

namespace EventEase2
{
    public class Event
    {
        
            public int EventId { get; set; }
            public required string EventName { get; set; }
            public DateTime EventDate { get; set; }
            public required string Description { get; set; }

            public int? VenueId { get; set; }
            public required Venues Venue { get; set; }

            public required ICollection<Bookings> Bookings { get; set; }
        public string? ImageUrl { get; set; }

        public int EventTypeId { get; set; }
        public EventType? EventType { get; set; }

    }
}




//Reference List for code:

//Date: 23 june 2025

//Author: Darsh Somayi

//Sourced: Harrison, W., 2022. Azure for Developers: Implement rich Azure PaaS ecosystems using containers, serverless services, and more. Packt Publishing.




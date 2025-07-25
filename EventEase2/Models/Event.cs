using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EventEase2.Models;

using System;
using System.Collections.Generic;

namespace EventEase2.Models
{
    public record Event(int EventId, string EventName, DateTime EventDate, string Description, int? VenueId, Venues Venue, ICollection<Bookings>? Bookings, string? ImageUrl, int EventTypeId, EventType? EventType);
}




//Reference List for code:

//Date: 23 june 2025

//Author: Darsh Somayi

//Sourced: Harrison, W., 2022. Azure for Developers: Implement rich Azure PaaS ecosystems using containers, serverless services, and more. Packt Publishing.



//Comments

// Unique identifier for the event (Primary Key)
// Name of the event (e.g., "Tech Conference 2025")
// Date and time when the event is scheduled
// Detailed description of the event
// Nullable foreign key linking to the venue
// Navigation property representing the venue details
// Collection of bookings related to the event (nullable)
// Optional URL to the event image stored in Azure Blob Storage
// Foreign key to identify the event type
// Navigation property representing the event type (nullable)

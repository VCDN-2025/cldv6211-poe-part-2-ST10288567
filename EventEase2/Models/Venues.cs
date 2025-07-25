using EventEase2.Models;

namespace EventEase2
{
    // Represents a venue where events can be hosted (e.g., a hall, conference center, or outdoor location)
    public class Venues
    {
        // Primary key: Unique identifier for each venue
        public int VenuesId { get; set; }

        // Name of the venue (e.g., "Midrand Conference Centre")
        public required string VenuesName { get; set; }

        // Physical location or address of the venue
        public required string Location { get; set; }

        // Maximum number of attendees the venue can accommodate
        public int Capacity { get; set; }

        // URL pointing to an image of the venue (stored in Azure Blob Storage or similar)
        public required string ImageUrl { get; set; }

        // Navigation property: List of bookings made for this venue
        public required ICollection<Bookings> Bookings { get; set; }

        // Navigation property: List of events scheduled to take place at this venue
        public required ICollection<Event> Events { get; set; }
    }
}




//Reference List for code:

//Date: 23 june 2025

//Author: Darsh Somayi

//Sourced: Harrison, W., 2022. Azure for Developers: Implement rich Azure PaaS ecosystems using containers, serverless services, and more. Packt Publishing.


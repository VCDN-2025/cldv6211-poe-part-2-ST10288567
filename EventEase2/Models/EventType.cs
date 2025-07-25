namespace EventEase2.Models
{
    // Represents the type or category of an event (e.g., Conference, Wedding, Concert)
    public class EventType
    {
        // Primary key: Unique identifier for each event type
        public int EventTypeId { get; set; }

        // Name of the event type (e.g., "Seminar", "Workshop")
        public required string Name { get; set; }

        // Indicates whether this event type is currently available for booking
        public required bool IsAvailable { get; set; }

        // Navigation property: Collection of events that are associated with this event type
        // This allows for querying all events that belong to a specific type
        public ICollection<Event>? Events { get; set; }
    }
}



//Reference List for code:

//Date: 23 june 2025

//Author: Darsh Somayi

//Sourced: Harrison, W., 2022. Azure for Developers: Implement rich Azure PaaS ecosystems using containers, serverless services, and more. Packt Publishing.

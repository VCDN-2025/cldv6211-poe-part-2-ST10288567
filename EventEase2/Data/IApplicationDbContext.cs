using EventEase2.Models;
using Microsoft.EntityFrameworkCore;

namespace EventEase2.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Bookings> Bookings { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<EventType> EventTypes { get; set; }
        DbSet<Venues> Venues { get; set; }
    }
}
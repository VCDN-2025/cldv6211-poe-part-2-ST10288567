using EventEase2.Models;
using Microsoft.EntityFrameworkCore;
namespace EventEase2.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected ApplicationDbContext()
    {
    }

    public DbSet<Venues> Venues { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Bookings> Bookings { get; set; }
    public DbSet<EventType> EventTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Booking → Event relationship
        modelBuilder.Entity<Bookings>()
            .HasOne(b => b.Event)
            .WithMany(e => e.Bookings)
            .HasForeignKey(b => b.EventId)
            .OnDelete(DeleteBehavior.Restrict);

        // Booking → Venue relationship
        modelBuilder.Entity<Bookings>()
            .HasOne(b => b.Venues)
            .WithMany(v => v.Bookings)
            .HasForeignKey(b => b.VenueId)
            .OnDelete(DeleteBehavior.Restrict);

        //  Event → EventType relationship
        modelBuilder.Entity<Event>()
            .HasOne(e => e.EventType)
            .WithMany(et => et.Events)
            .HasForeignKey(e => e.EventTypeId)
            .IsRequired() // Ensure it's required
            .OnDelete(DeleteBehavior.Restrict);

    }
}

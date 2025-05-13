using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EventEase2.Data;

namespace EventEase2.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public EventsController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var events = _context.Events.Include(v => v.Venue);
            return View(await events.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var @event = await _context.Events
                .Include(v => v.Venue)
                .FirstOrDefaultAsync(m => m.EventId == id);

            if (@event == null) return NotFound();

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewData["VenueId"] = new SelectList(_context.Venues, "VenuesId", "VenuesId");
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,EventName,EventDate,Description,VenueId")] Event @event, IFormFile? ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    string imageUrl = await UploadImageToBlobAsync(ImageFile);
                    @event.ImageUrl = imageUrl;
                }

                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["VenueId"] = new SelectList(_context.Venues, "VenuesId", "VenuesId", @event.VenueId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var @event = await _context.Events.FindAsync(id);
            if (@event == null) return NotFound();

            ViewData["VenueId"] = new SelectList(_context.Venues, "VenuesId", "VenuesId", @event.VenueId);
            return View(@event);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,EventName,EventDate,Description,VenueId,ImageUrl")] Event @event)
        {
            if (id != @event.EventId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventId)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["VenueId"] = new SelectList(_context.Venues, "VenuesId", "VenuesId", @event.VenueId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var @event = await _context.Events
                .Include(v => v.Venue)
                .FirstOrDefaultAsync(m => m.EventId == id);

            if (@event == null) return NotFound();

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.FindAsync(id);

            if (@event != null)
            {
                bool hasBookings = _context.Bookings.Any(b => b.EventId == @event.EventId);
                if (hasBookings)
                {
                    ModelState.AddModelError("", "Cannot delete this event because it has active bookings.");
                    return View(@event);
                }

                _context.Events.Remove(@event);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }

        // Secure Image Upload using Azure Blob
        private async Task<string> UploadImageToBlobAsync(IFormFile imageFile)
        {
            string connectionString = _configuration["AzureStorage:ConnectionString"];
            string containerName = _configuration["AzureStorage:ContainerName"];

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            await containerClient.CreateIfNotExistsAsync();

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            BlobClient blobClient = (BlobClient)containerClient.GetBlobClient(uniqueFileName);

            using (var stream = imageFile.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, overwrite: true);
            }

            return blobClient.Uri.ToString();
        }
    }
}





//Reference List for code:

//Date: 13 May 2025

//Author: Darsh Somayi

//Sourced: Harrison, W., 2022. Azure for Developers: Implement rich Azure PaaS ecosystems using containers, serverless services, and more. Packt Publishing.


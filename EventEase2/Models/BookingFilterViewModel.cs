namespace EventEase2.Models
{
    public class BookingFilterViewModel
    {
        public List<BookingDisplayViewModel> Bookings { get; set; }
        public string Search { get; set; }
        public int? EventTypeId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? IsAvailable { get; set; }

        public List<EventType> EventTypes { get; set; }
    }
}

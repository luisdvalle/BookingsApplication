using BookingService.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingService.Models
{
    [Serializable]
    public class Bookings : Request
    {
        public string OpeningHour { get; set; }
        public string ClosingHour { get; set; }
        public IEnumerable<BookingRequest> BookingRequests { get; set; }
    }
}

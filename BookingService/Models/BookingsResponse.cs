using BookingService.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingService.Models
{
    [Serializable]
    public class BookingsResponse : Response
    {
        public IList<BookingEmployee> Bookings { get; set; }

    }
}

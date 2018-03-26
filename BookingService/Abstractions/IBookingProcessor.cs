using System;
using System.Collections.Generic;
using System.Text;

namespace BookingService.Abstractions
{
    public interface IBookingProcessor
    {
        Request ProcessBookingString(string bookingsStr);
        Response ProcessBooking(Request bookings);
    }
}

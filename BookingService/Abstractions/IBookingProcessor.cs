using System;
using System.Collections.Generic;
using System.Text;

namespace BookingService.Abstractions
{
    public interface IBookingProcessor<T>
    {
        T ProcessBooking(T bookingRequest);
    }
}

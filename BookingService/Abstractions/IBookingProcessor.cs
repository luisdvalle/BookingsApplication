using System;
using System.Collections.Generic;
using System.Text;

namespace BookingService.Abstractions
{
    /// <summary>
    /// Provides a common definition for processing data
    /// </summary>
    public interface IBookingProcessor
    {
        /// <summary>
        /// Provides a definition for processing a string with incoming bookings
        /// </summary>
        /// <param name="bookingsStr">A set of bookings in raw format to be processed</param>
        /// <returns>A deserialised Request data object</returns>
        Request ProcessBookingString(string bookingsStr);
        /// <summary>
        /// Provides a definition for processing a Request object with bookings data
        /// </summary>
        /// <param name="bookings">A set of bookings as a Request object</param>
        /// <returns>A Response object with bookings processed</returns>
        Response ProcessBooking(Request bookings);
    }
}

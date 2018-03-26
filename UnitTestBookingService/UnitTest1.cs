using BookingService.Models;
using BookingService.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestBookingService
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ProcessRequestData_FiveRequestsThreeBookingsProcessed_Processed()
        {
            // Arrange
            string testData = "0900 1730\r\n2011-03-17 10:17:06\r\nEMP001\r\n2011-03-21 09:00 2\r\n2011-" +
                "03-16 12:34:56\r\nEMP002\r\n2011-03-21 09:00 2\r\n2011-03-16 09:28:23\r\nEMP003\r\n2011" +
                "-03-22 14:00 2\r\n2011-03-17 11:23:45\r\nEMP004\r\n2011-03-22 16:00 1\r\n2011-03-" +
                "15 17:29:12\r\nEMP005\r\n2011-03-21 16:00 3";
            BookingProcessor bp = new BookingProcessor();

            // Act
            Bookings bookingsResult = (Bookings) bp.ProcessBookingString(testData);
            BookingsResponse response = (BookingsResponse) bp.ProcessBooking(bookingsResult);

            // Assert
            List<BookingRequest> totalBookings = bookingsResult.BookingRequests as List<BookingRequest>;
            Assert.AreEqual(5, totalBookings.Count);
            Assert.AreEqual(3, response.Bookings.Count);
        }
    }
}

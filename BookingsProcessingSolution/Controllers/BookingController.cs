using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookingService.Abstractions;
using BookingService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingsProcessingSolution.Controllers
{
    [Produces("application/json")]
    [Route("api/Booking")]
    public class BookingController : Controller
    {
        private IBookingProcessor _bookingProcessor;

        public BookingController(IBookingProcessor bookingProcessor)
        {
            _bookingProcessor = bookingProcessor;
        }

        [HttpPost]
        public IActionResult Process(IFormFile file)
        {
            var bookings = String.Empty;

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                bookings = reader.ReadToEnd();
            }

            Bookings bookingsResult = (Bookings)_bookingProcessor.ProcessBookingString(bookings);
            BookingsResponse response = (BookingsResponse)_bookingProcessor.ProcessBooking(bookingsResult);

            return View(response);
        }
    }
}
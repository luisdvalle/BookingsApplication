using BookingService.Abstractions;
using BookingService.Extensions;
using BookingService.Formatters;
using BookingService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BookingService.Services
{
    public class BookingProcessor : IBookingProcessor
    {
        public Response ProcessBooking(Request request)
        {
            BookingsResponse processedBookings = null;
            Bookings bookings = request as Bookings;
            // Helper Dictionary used locally to check conflicts with other bookings
            List<Tuple<DateTime, DateTime>> bookingsReview = new List<Tuple<DateTime, DateTime>>();

            // Timespan to help determine the opening time for a specified date
            TimeSpan tsOpening = new TimeSpan
                (
                int.Parse(bookings.OpeningHour.Substring(0, 2)),
                int.Parse(bookings.OpeningHour.Substring(3, 2)),
                0);

            // Timespan to help determine the closing time for a specified date
            TimeSpan tsClosing = new TimeSpan
                (
                int.Parse(bookings.ClosingHour.Substring(0, 2)),
                int.Parse(bookings.ClosingHour.Substring(3, 2)),
                0);

            // Filtering out bookings that are outside of business hours and ordering by
            // RequestTime and BookingTime
            List<BookingRequest> requests = bookings.BookingRequests
                .Where
                (
                    r => 
                    // Check BookingTime is >= to office opening time.
                    r.BookingTime >= (r.BookingTime.Date.AddSeconds(1) + tsOpening).Subtract(new TimeSpan(0, 0, 1))
                    &&
                    // Check BookingTime is <= to office closing time.
                    r.BookingTime <= (r.BookingTime.Date.AddSeconds(1) + tsClosing).Subtract(new TimeSpan(0, 0, 1))
                    &&
                    // Check booking finisth time is <= to office closing time.
                    r.BookingTime.AddHours(r.NumberHours) <= 
                    (r.BookingTime.Date.AddSeconds(1) + tsClosing).Subtract(new TimeSpan(0, 0, 1))
                )
                .OrderBy(r => r.BookingTime)
                .ThenBy(r => r.RequestTime)
                .ToList();

            
            processedBookings = new BookingsResponse { Bookings = new List<BookingEmployee>() };

            // Eliminating bookings overlapping other bookings
            foreach (var req in requests)
            {
                bool acceptableBooking = true;
                BookingEmployee be = new BookingEmployee
                {
                    Date = req.BookingTime.Date,
                    EmployeeId = req.EmployeeId,
                    StartTime = req.BookingTime,
                    EndTime = req.BookingTime.AddHours(req.NumberHours)
                };

                foreach (var br in bookingsReview)
                {
                    if (
                        (be.Date == br.Item1.Date) &&
                        (be.StartTime >= br.Item1 && be.StartTime < br.Item2)
                        )
                    {
                        acceptableBooking = false;
                        break;
                    }
                }

                if (acceptableBooking)
                {
                    bookingsReview.Add(new Tuple<DateTime, DateTime>(be.StartTime, be.EndTime));
                    processedBookings.Bookings.Add(be);
                }
            }

            return processedBookings;
        }

        public Request ProcessBookingString(string bookingsStr)
        {
            var serializer = new BookingFormatter();
            Bookings bookingsList;

            using (var stream = bookingsStr.ToStream())
            {
                bookingsList = (Bookings)serializer.Deserialize(stream);
            }

            return bookingsList;
        }
    }
}

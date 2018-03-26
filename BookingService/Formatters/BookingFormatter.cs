using BookingService.Abstractions;
using BookingService.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace BookingService.Formatters
{
    public class BookingFormatter : IFormatter
    {
        public SerializationBinder Binder { get; set; }
        public StreamingContext Context { get; set; }
        public ISurrogateSelector SurrogateSelector { get; set; }

        public object Deserialize(Stream serializationStream)
        {
            Bookings bookings;
            List<BookingRequest> bookingRequests;

            using (var sr = new StreamReader(serializationStream))
            {
                bookings = new Bookings();
                bookingRequests = new List<BookingRequest>();

                // Get office hours
                var officeHours = sr.ReadLine().Split(' ');
                bookings.OpeningHour = officeHours[0].Insert(2, ":");
                bookings.ClosingHour = officeHours[1].Insert(2, ":");

                while (sr.Peek() >= 0)
                {
                    try
                    {
                        var requestDate = sr.ReadLine();
                        var employeeId = sr.ReadLine();
                        var bookingTimeHours = sr.ReadLine();
                        DateTime bookingTime = DateTime.Parse(bookingTimeHours.Substring(0, 17));
                        int numHours = int.Parse(bookingTimeHours.Substring(17));

                        BookingRequest bookingReq = new BookingRequest
                        {
                            RequestTime = DateTime.Parse(requestDate),
                            EmployeeId = employeeId,
                            BookingTime = bookingTime,
                            NumberHours = numHours
                        };

                        bookingRequests.Add(bookingReq);
                    }
                    catch (Exception)
                    {
                        // TODO: Log error
                        continue;
                    }
                }

                bookings.BookingRequests = bookingRequests;
            }

            return bookings;
        }

        public void Serialize(Stream serializationStream, object graph)
        {
            // TODO: Implement on a later stage
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookingService.Extensions
{
    /// <summary>
    /// Provides extensions methods used in the Booking Service library
    /// </summary>
    public static class BookingExtensions
    {
        /// <summary>
        /// Converts a string into a stream
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>A MemoryStream</returns>
        public static Stream ToStream(this string str)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(str);
            return new MemoryStream(byteArray);
        }
    }
}

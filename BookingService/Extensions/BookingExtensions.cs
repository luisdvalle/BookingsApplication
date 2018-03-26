using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookingService.Extensions
{
    public static class BookingExtensions
    {
        public static Stream ToStream(this string str)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(str);
            return new MemoryStream(byteArray);
        }
    }
}

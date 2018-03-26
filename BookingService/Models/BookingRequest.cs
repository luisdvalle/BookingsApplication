using System;
using System.Collections.Generic;
using System.Text;

namespace BookingService.Models
{
    [Serializable]
    public class BookingRequest
    {
        public DateTime RequestTime { get; set; }
        public string EmployeeId { get; set; }
        public DateTime BookingTime { get; set; }
        public int NumberHours { get; set; }
    }
}

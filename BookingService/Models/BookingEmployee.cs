using System;
using System.Collections.Generic;
using System.Text;

namespace BookingService.Models
{
    [Serializable]
    public class BookingEmployee
    {
        public DateTime Date { get; set; }
        public string EmployeeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

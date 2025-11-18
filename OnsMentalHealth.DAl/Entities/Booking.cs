using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealthSolution.DAL.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }

        public string BookingDescription { get; set; }

        public DateTime BookingDateTime { get; set; }

        public string PhoneNumber { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int TherapistId { get; set; }
        public Therapist Therapist { get; set; }
    }
}

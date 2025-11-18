using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealthSolution.DAL.Entities
{
    public class Therapist
    {
        public int TherapistId { get; set; }
        public string Name { get; set; }

        public string Speclization { get; set; }

        public string City { get; set; }

        public DateTime Birthday { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<Booking> Bookings { get; set; }

        public List<Comment> comments { get; set; }

        public List<Post> posts { get; set; }

        public List<Reaction> Reactions { get; set; }




    }
}

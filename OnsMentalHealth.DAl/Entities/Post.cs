using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealthSolution.DAL.Entities
{
    public class Post
    {
        public int PostId { get; set; }

        public string PostTitle { get; set; }

        public DateTime time { get; set; }
        public DateTime Date { get; set; }

        public byte[] Image { get; set; }

        public int TherapistId { get; set; }
        public Therapist Therapist { get; set; }

        public List<Comment> comments { get; set; } 


    }
}

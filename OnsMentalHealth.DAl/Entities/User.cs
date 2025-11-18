using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealthSolution.DAL.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime Birthday { get; set; }

        public List<Booking> bookings { get; set; }    

        public  List<Comment> Comments { get; set; } 
         
        public List<Reaction> Reactions { get; set; }  
    }     
}

using System.ComponentModel.DataAnnotations;

namespace OnsMentalHealth.BLL.DTOs.Therapists // لاحظ حرف s في الآخر
{
    public class TherapistAddDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Specialization { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
    }
}
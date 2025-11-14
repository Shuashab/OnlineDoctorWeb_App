using System.ComponentModel.DataAnnotations;

namespace OnlineDoctorApp.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public string PatientName { get; set; } = "";

        [Required, EmailAddress]
        public string Email { get; set; } = "";

        public string Phone { get; set; } = "";

        [Required]
        public string DoctorName { get; set; } = "";

        [Required, DataType(DataType.Date)]
        public DateOnly Date { get; set; }

        [Required]
        public string Time { get; set; } = "";

        public string? Message { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineDoctorApp.Models;
using OnlineDoctorApp.Services;
using System.ComponentModel.DataAnnotations;

public class BookModel : PageModel
{
    private readonly IAppointmentService _svc;
    public bool Success { get; set; } = false;

    public BookModel(IAppointmentService svc)
    {
        _svc = svc;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public class InputModel
    {
        [Required] public string PatientName { get; set; } = "";
        [Required, EmailAddress] public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        [Required] public string DoctorName { get; set; } = "";
        [Required, DataType(DataType.Date)] public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Today);
        [Required] public string Time { get; set; } = "";
        public string? Message { get; set; } = "";
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var appt = new Appointment
        {
            PatientName = Input.PatientName,
            Email = Input.Email,
            Phone = Input.Phone,
            DoctorName = Input.DoctorName,
            Date = Input.Date,
            Time = Input.Time,
            Message = Input.Message
        };

        _svc.Add(appt);
        Success = true;

        // clear form
        ModelState.Clear();
        Input = new InputModel();
        return Page();
    }
}

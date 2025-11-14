using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineDoctorApp.Models;
using OnlineDoctorApp.Services;

public class IndexModel : PageModel
{
    private readonly IAppointmentService _svc;
    public IEnumerable<Appointment> Appointments { get; private set; } = Enumerable.Empty<Appointment>();

    public IndexModel(IAppointmentService svc)
    {
        _svc = svc;
    }

    public void OnGet()
    {
        Appointments = _svc.GetAll();
    }
}

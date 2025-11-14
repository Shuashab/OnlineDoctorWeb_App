using OnlineDoctorApp.Models;

namespace OnlineDoctorApp.Services
{
    public interface IAppointmentService
    {
        void Add(Appointment a);
        IEnumerable<Appointment> GetAll();
    }

    public class AppointmentService : IAppointmentService
    {
        private readonly List<Appointment> _items = new();
        private int _nextId = 1;

        public void Add(Appointment a)
        {
            a.Id = _nextId++;
            _items.Add(a);
        }

        public IEnumerable<Appointment> GetAll() => _items.OrderBy(x => x.Date).ThenBy(x => x.Time);
    }
}

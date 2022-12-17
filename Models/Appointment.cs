using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace ProiectMedii.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? ServiceID { get; set; }
        public Service? Service { get; set; }

        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }
    }
}

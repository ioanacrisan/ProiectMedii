using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace ProiectMedii.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        [Display(Name = "Client")]
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        [Display(Name = "Serviciu")]
        public int? ServiceID { get; set; }
        public Service? Service { get; set; }

        [Display(Name = "Data Programarii")]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; }
    }
}

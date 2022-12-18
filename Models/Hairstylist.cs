using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProiectMedii.Models
{
    public class Hairstylist
    {
        [Display(Name = "Hairstylist")]
        public int ID { get; set; }
        [Display(Name = "Hairstylist")]
        public string HairstylistName { get; set; }
        public ICollection<Service>? Services { get; set; } //navigation property

    }
}

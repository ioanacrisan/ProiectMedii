using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProiectMedii.Models
{
    public class ServiceCategory
    {
        public int ID { get; set; }

        [Display(Name = "Serviciu")]
        public int ServiceID { get; set; }
        public Service Service { get; set; }

        [Display(Name = "Categorie")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}

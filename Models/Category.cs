using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProiectMedii.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Categorie")]
        public string CategoryName { get; set; }
        public ICollection<ServiceCategory>? ServiceCategories { get; set; }
    }
}

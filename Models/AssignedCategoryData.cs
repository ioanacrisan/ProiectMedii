using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProiectMedii.Models
{
    public class AssignedCategoryData
    {
        [Display(Name = "Categorie")]
        public int CategoryID { get; set; }

        [Display(Name = "Categorie Data")]
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}

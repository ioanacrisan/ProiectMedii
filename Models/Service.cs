using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace ProiectMedii.Models
{
    public class Service
    {
        public int ID { get; set; }

        [Display(Name = "Denumire Serviciu")]
        [StringLength(150, MinimumLength = 3)]
        public string Title { get; set; }

        public ICollection<ServiceCategory>? ServiceCategories { get; set; }

        public int? HairstylistID { get; set; }
        public Hairstylist? Hairstylist { get; set; }


        [Display(Name = "Durata serviciului")]
        public string Duration { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal Price { get; set; }
    }
}

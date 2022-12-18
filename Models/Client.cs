using System.ComponentModel.DataAnnotations;
using System.Drawing.Drawing2D;
using System.Xml.Linq;

namespace ProiectMedii.Models
{
    public class Client
    {
        public int ID { get; set; }

        [Display(Name = "Prenume")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage ="Prenumele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau Ana-Maria")]
        [StringLength(30, MinimumLength = 3)]
        public string? FirstName { get; set; }

        [Display(Name = "Nume de familie")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau Ana-Maria")]
        [StringLength(30, MinimumLength = 3)]
        public string? LastName { get; set; }

        [Display(Name = "Adresa")]
        [StringLength(70)]
        public string? Adress { get; set; }
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        [RegularExpression(@"^\(?([0-9])\)?([0-9]{9})$", ErrorMessage = "Telefonul trebuie sa inceapa cu 0 si sa aiba 10 cifre.")]
        public string? Phone { get; set; }
        [Display(Name = "Nume")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}

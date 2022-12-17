using System.Security.Policy;

namespace ProiectMedii.Models.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Hairstylist> Hairstylists { get; set; }
        public IEnumerable<Service> Services { get; set; }
    }
}

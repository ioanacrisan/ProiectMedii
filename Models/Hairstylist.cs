namespace ProiectMedii.Models
{
    public class Hairstylist
    {
        public int ID { get; set; }
        public string HairstylistName { get; set; }
        public ICollection<Service>? Services { get; set; } //navigation property

    }
}

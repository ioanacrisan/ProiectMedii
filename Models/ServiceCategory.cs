namespace ProiectMedii.Models
{
    public class ServiceCategory
    {
        public int ID { get; set; }
        public int ServiceID { get; set; }
        public Service Service { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}

﻿namespace ProiectMedii.Models
{
    public class ServiceData
    {
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ServiceCategory> ServiceCategories { get; set; }
    }
}

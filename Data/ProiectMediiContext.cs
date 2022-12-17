using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Models;

namespace ProiectMedii.Data
{
    public class ProiectMediiContext : DbContext
    {
        public ProiectMediiContext (DbContextOptions<ProiectMediiContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectMedii.Models.Service> Service { get; set; } = default!;

        public DbSet<ProiectMedii.Models.Hairstylist> Hairstylist { get; set; }
    }
}

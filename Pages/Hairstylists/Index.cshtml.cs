using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;
using ProiectMedii.Models.ViewModels;

namespace ProiectMedii.Pages.Hairstylists
{
    public class IndexModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public IndexModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        public IList<Hairstylist> Hairstylist { get;set; } = default!;

        public PublisherIndexData HairstylistData { get; set; }
        public int HairstylistID { get; set; }
        public int ServiceID { get; set; }
        public async Task OnGetAsync(int? id, int? serviceID)
        {
            HairstylistData = new PublisherIndexData();
            HairstylistData.Hairstylists = await _context.Hairstylist
            .Include(i => i.Services)
            .OrderBy(i => i.HairstylistName)
            .ToListAsync();
            if (id != null)
            {
                HairstylistID = id.Value;
                Hairstylist hairstylist = HairstylistData.Hairstylists
                .Where(i => i.ID == id.Value).Single();
                HairstylistData.Services = hairstylist.Services;
            }
        }       }
}

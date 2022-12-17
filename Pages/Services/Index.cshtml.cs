using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public IndexModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }


        public IList<Service> Service { get; set; }
        public ServiceData ServiceD { get; set; }
        public int ServiceID { get; set; }
        public int CategoryID { get; set; }

        public string TitleSort { get; set; }
        public string HairstylistSort { get; set; }


        public string CurrentFilter { get; set; }


        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            ServiceD = new ServiceData();

            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            HairstylistSort = String.IsNullOrEmpty(sortOrder) ? "author_desc" : "";

            CurrentFilter = searchString;

            ServiceD.Services = await _context.Service
            .Include(b => b.Hairstylist)
            .Include(b => b.ServiceCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                ServiceD.Services = ServiceD.Services.Where(s => s.Hairstylist.HairstylistName.Contains(searchString)
                || s.Title.Contains(searchString));
            }

                if (id != null)
            {
                ServiceID = id.Value;
                Service service = ServiceD.Services
                .Where(i => i.ID == id.Value).Single();
                ServiceD.Categories = service.ServiceCategories.Select(s => s.Category);
            }

            switch (sortOrder)
            {
                case "title_desc":
                    ServiceD.Services = ServiceD.Services.OrderByDescending(s =>
                    s.Title);
                    break;
                case "author_desc":
                    ServiceD.Services = ServiceD.Services.OrderByDescending(s =>
                    s.Hairstylist.HairstylistName);
                    break;
            }
        }
    }
}

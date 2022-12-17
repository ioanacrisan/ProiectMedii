using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Hairstylists
{
    public class DetailsModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public DetailsModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

      public Hairstylist Hairstylist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hairstylist == null)
            {
                return NotFound();
            }

            var hairstylist = await _context.Hairstylist.FirstOrDefaultAsync(m => m.ID == id);
            if (hairstylist == null)
            {
                return NotFound();
            }
            else 
            {
                Hairstylist = hairstylist;
            }
            return Page();
        }
    }
}

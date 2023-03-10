using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Hairstylists
{
    [Authorize(Roles = "Admin")]

    public class DeleteModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public DeleteModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Hairstylist == null)
            {
                return NotFound();
            }
            var hairstylist = await _context.Hairstylist.FindAsync(id);

            if (hairstylist != null)
            {
                Hairstylist = hairstylist;
                _context.Hairstylist.Remove(Hairstylist);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

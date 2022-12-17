using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Services
{
    [Authorize(Roles = "Admin")]
    public class EditModel : ServiceCategoriesPageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public EditModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Service Service { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }


            Service = await _context.Service
 .Include(b => b.Hairstylist)
 .Include(b => b.ServiceCategories).ThenInclude(b => b.Category)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);



            if (Service == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Service);
         

            ViewData["HairstylistID"] = new SelectList(_context.Set<Hairstylist>(), "ID", "HairstylistName");


            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            //se va include Author conform cu sarcina de la lab 2
            var serviceToUpdate = await _context.Service
            .Include(i => i.Hairstylist)
            .Include(i => i.ServiceCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (serviceToUpdate == null)
            {
                return NotFound();
            }
            //se va modifica AuthorID conform cu sarcina de la lab 2
            if (await TryUpdateModelAsync<Service>(
            serviceToUpdate,
            "Service",
            i => i.Price, i => i.Duration, i => i.HairstylistID))
            {
                UpdateServiceCategories(_context, selectedCategories, serviceToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateServiceCategories(_context, selectedCategories, serviceToUpdate);
            PopulateAssignedCategoryData(_context, serviceToUpdate);
            return Page();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Services
{
    public class CreateModel : ServiceCategoriesPageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public CreateModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["HairstylistID"] = new SelectList(_context.Set<Hairstylist>(), "ID", "HairstylistName");

            var service = new Service();
            service.ServiceCategories = new List<ServiceCategory>();
            PopulateAssignedCategoryData(_context, service);

            return Page();
        }

        [BindProperty]
        public Service Service { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newService = new Service();
            if (selectedCategories != null)
            {
                newService.ServiceCategories = new List<ServiceCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ServiceCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newService.ServiceCategories.Add(catToAdd);
                }
            }
            Service.ServiceCategories = newService.ServiceCategories;
            _context.Service.Add(Service);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
       // PopulateAssignedCategoryData(_context, newService);
         //   return Page();
    }

}


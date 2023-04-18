using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using bazy.Data;
using bazy.Models;

namespace bazy.Pages
{
    public class DodajZawodnikaModel : PageModel
    {
        private readonly bazy.Data.ZawodnikDbContext _context;

        public DodajZawodnikaModel(bazy.Data.ZawodnikDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Zawodnik Zawodnik { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Zawodnicy == null || Zawodnik == null)
            {
                return Page();
            }

            _context.Zawodnicy.Add(Zawodnik);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using bazy.Data;
using bazy.Models;
using Microsoft.EntityFrameworkCore;

namespace bazy.Pages
{
    public class DodajWynikModel : PageModel
    {
        private readonly bazy.Data.ZawodnikDbContext _context;

        public DodajWynikModel(bazy.Data.ZawodnikDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Zawodnik Zawodnik { get; set; } = default!;

        [BindProperty]
        public int wynik { get; set; }
        [BindProperty]
        public Miejscowosci Miejscowosc { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var dbContext = new ZawodnikDbContext();

            if (dbContext.Zawodnicy.Where(o => o.imie_zawodnika == Zawodnik.imie_zawodnika && o.nazwisko_zawodnika == Zawodnik.nazwisko_zawodnika).Count() == 0)
            {
                ViewData["Message"] = $"Nie znaleziono osoby o imieniu {Zawodnik.imie_zawodnika} {Zawodnik.nazwisko_zawodnika}.";
            }

            if (dbContext.Miejscowosci.Where(o => o.nazwa_miejscowosci == Miejscowosc.nazwa_miejscowosci && o.kraj_miejscowosci ==Miejscowosc.kraj_miejscowosci).Count() == 0 )
            {
                ViewData["Message"] = $"Nie znaleziono miejscowosci {Miejscowosc.nazwa_miejscowosci} w kraju {Miejscowosc.kraj_miejscowosci}.";
            }

        }
    }
}

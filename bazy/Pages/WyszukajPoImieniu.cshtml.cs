using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using bazy.Data;
using bazy.Models;

namespace bazy.Pages
{
    public class WyszukajPoImieniuModel : PageModel
    {
        private readonly bazy.Data.ZawodnikDbContext _context;

        public WyszukajPoImieniuModel(bazy.Data.ZawodnikDbContext context)
        {
            _context = context;
        }


        [BindProperty]
        public string Name { get; set; }

        public IList<Zawodnik> Zawodnicy;

        public async Task OnGetAsync()
        {

        }

        public async Task OnPostAsync()
        {
            var dbContext = new ZawodnikDbContext();
            
            Zawodnicy = await dbContext.Zawodnicy.Where(o => o.imie_zawodnika == Name).ToListAsync();

            if (Zawodnicy.Count == 0)
            {
                ViewData["Message"] = $"Nie znaleziono osoby o imieniu {Name}.";
            }

        }
    }
}

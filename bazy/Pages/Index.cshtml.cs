using bazy.Controllers;
using bazy.Data;
using bazy.Models;
using bazy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bazy.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //ZawodnikDbContext zawodnikDbContext = new ZawodnikDbContext();
            //zawodnikService = new IZawodnikService(zawodnikDbContext);
            //zawodnicy = zawodnikService.Search(SearchTerm);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using bazy.Data;
using Microsoft.EntityFrameworkCore;
using bazy.Models;
using MySql.Data.MySqlClient;
using System.Reflection.PortableExecutable;
using Microsoft.Identity.Client;


/*------------------------------------------------------------------------------------------------------------------*/
/*                           KLASA STOWRZONA DO OBSLUGI TABELI ZAWODNIK I DZIALAN NA NIEJ                           */
/*------------------------------------------------------------------------------------------------------------------*/

namespace bazy.Controllers
{
    [Route("api/zawodnik")]
    [ApiController]
    public class ZawodnikController : ControllerBase
    {
        private readonly ZawodnikDbContext _context;

        public ZawodnikController(ZawodnikDbContext context)
        {
            this._context = context;
        }


        // pobieramy wszystkich zawodników z bazy danych i zwracamy do klienta z kodem 200, czyli OK
        // Aby móc to zrobić musimy mieć dostęp do kontekstu bazy danych 
        // Dodanie atrybutu HttpGet jest dobrym nawykiem nazywania akcj przez takie atrybuty
        // W tym przypadku atrybut ten zostałby nadany automatycznie ale i tak warto
        [HttpGet]
        public ActionResult<IEnumerable<Zawodnik>> GetAll()
        {
            var zawodnicy = _context
                .Zawodnicy
                .ToList();
            return Ok(zawodnicy);
        }





    }
}

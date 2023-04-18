using Microsoft.AspNetCore.Mvc;
using bazy.Data;
using Microsoft.EntityFrameworkCore;
using bazy.Models;
using MySql.Data.MySqlClient;
using System.Reflection.PortableExecutable;
using Microsoft.Identity.Client;
using bazy.Services;
using bazy.Services.Interfaces;


/*------------------------------------------------------------------------------------------------------------------*/
/*                           KLASA STOWRZONA DO OBSLUGI TABELI ZAWODNIK I DZIALAN NA NIEJ                           */
/*------------------------------------------------------------------------------------------------------------------*/

namespace bazy.Controllers
{
    [Route("api/Zawodnik")]
    [ApiController]
    public class ZawodnikController : ControllerBase
    {
        private readonly IZawodnikService _zawodnikService;

        public ZawodnikController(IZawodnikService service)
        {
            _zawodnikService = service;
        }


        // pobieramy wszystkich zawodników z bazy danych i zwracamy do klienta z kodem 200, czyli OK
        // Aby móc to zrobić musimy mieć dostęp do kontekstu bazy danych 
        // Dodanie atrybutu HttpGet jest dobrym nawykiem nazywania akcj przez takie atrybuty
        // W tym przypadku atrybut ten zostałby nadany automatycznie ale i tak warto
        [HttpGet("GetAll")]
        public Task<IEnumerable<Zawodnik>> GetAll()
        {
            var zawodnicy = _zawodnikService.GetAll();
            return zawodnicy;
        }
    }
}

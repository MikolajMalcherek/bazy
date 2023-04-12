using bazy.Data;
using bazy.Models;
using System;
using System.Collections.Concurrent;


namespace bazy
{
    public class IZawodnikService
    {
        private readonly ZawodnikDbContext _context;


        public IZawodnikService(ZawodnikDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Zawodnik> Search(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                var zawodnicy = _context.Zawodnicy.ToList();
                return zawodnicy;
            }
            else return _context.Zawodnicy.Where(e => e.imie_zawodnika.Contains(name));

        }

    }
}

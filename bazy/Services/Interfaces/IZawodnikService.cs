using bazy.Models;

namespace bazy.Services.Interfaces
{
    public interface IZawodnikService
    {
        Task<IEnumerable<Zawodnik>> GetAll();
    }
}

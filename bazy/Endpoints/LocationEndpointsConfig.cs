using bazy.Models;
using bazy.Data;
using Microsoft.EntityFrameworkCore;
using bazy.Services;

namespace bazy.Endpoints
{
    public class LocationEndpointsConfig
    {
        public static void AddEndpoints(WebApplication app)
        {
            app.MapGet("api/GetAll", async (ZawodnikDbContext zawodnikDbContext) =>
            {
                var zawodnicy = await zawodnikDbContext.Zawodnicy.ToListAsync();
                return zawodnicy;
            });
        }
    }
}

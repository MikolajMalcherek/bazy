using bazy.Helpers;
using bazy.Models;
using bazy.Services.Interfaces;

namespace bazy.Services
{
    public class ZawodnikService : IZawodnikService
    {
        private readonly HttpClient _httpClient;
        public const string BasePath = "/api/Zawodnik";

        public ZawodnikService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<Zawodnik>> GetAll()
        {
            var response = await _httpClient.GetAsync(BasePath);

            return await response.ReadContentAsync<List<Zawodnik>>();
        }

    }
}

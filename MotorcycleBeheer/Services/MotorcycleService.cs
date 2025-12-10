using MRL.Shared.Contracts;
using System.Net.Http.Json;

namespace MRL.Desktop.Services
{
    public class MotorcycleService
    {
        private readonly HttpClient _http;

        public MotorcycleService(string baseAddress)
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }


        // GET: /api/motorcycle
        public async Task<List<MotorcycleDTO>> GetMotorcyclesAsync()
        {
            var result = await _http.GetFromJsonAsync<List<MotorcycleDTO>>("api/motorcycle");
            return result ?? [];
        }

        // POST: /api/motorcycle
        public async Task<MotorcycleDTO?> CreateMotorcycleAsync(MotorcycleDTO motorcycle)
        {
            var response = await _http.PostAsJsonAsync("api/motorcycle", motorcycle);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MotorcycleDTO>();
        }

        // PUT: api/Motorcycle/5
        public async Task UpdateMotorcycleAsync(MotorcycleDTO motorcycle)
        {
            var response = await _http.PutAsJsonAsync("api/motorcycle/" + motorcycle.Id, motorcycle);
            response.EnsureSuccessStatusCode();
        }

        // DELETE: api/Motorcycle/5
        public async Task DeleteMotorcycleAsync(int id)
        {
            var response = await _http.DeleteAsync("api/motorcycle/" + id);
            response.EnsureSuccessStatusCode();
        }

    }
}


using MRL.Shared.Contracts;
using System.Net.Http.Json;

namespace MRL.Desktop.Services
{
    public class BrandService
    {
        private readonly HttpClient _http;

        public BrandService(string baseAddress)
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }


        // GET: /api/Brand
        public async Task<List<BrandDTO>> GetBrandsAsync()
        {
            var result = await _http.GetFromJsonAsync<List<BrandDTO>>("api/Brand");
            return result ?? [];
        }

        // POST: /api/Brand
        public async Task<BrandDTO?> CreateBrandAsync(BrandDTO Brand)
        {
            var response = await _http.PostAsJsonAsync("api/Brand", Brand);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<BrandDTO>();
        }

        // PUT: api/Brand/5
        public async Task UpdateBrandAsync(BrandDTO Brand)
        {
            var response = await _http.PutAsJsonAsync("api/Brand/" + Brand.Id, Brand);
            response.EnsureSuccessStatusCode();
        }

        // DELETE: api/Brand/5
        public async Task DeleteBrandAsync(int id)
        {
            var response = await _http.DeleteAsync("api/Brand/" + id);
            response.EnsureSuccessStatusCode();
        }

    }
}


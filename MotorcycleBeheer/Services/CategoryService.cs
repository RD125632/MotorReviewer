using MRL.Shared.Contracts;
using System.Net.Http.Json;

namespace MRL.Desktop.Services
{
    public class CategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(string baseAddress)
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }


        // GET: /api/Category
        public async Task<List<CategoryDTO>> GetCategorysAsync()
        {
            var result = await _http.GetFromJsonAsync<List<CategoryDTO>>("api/Category");
            return result ?? [];
        }

        // POST: /api/Category
        public async Task<CategoryDTO?> CreateCategoryAsync(CategoryDTO Category)
        {
            var response = await _http.PostAsJsonAsync("api/Category", Category);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CategoryDTO>();
        }

        // PUT: api/Category/5
        public async Task<CategoryDTO?> UpdateCategoryAsync(CategoryDTO Category)
        {
            var response = await _http.PutAsJsonAsync("api/Category/" + Category.Id, Category);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CategoryDTO>();
        }

        // DELETE: api/Category/5
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var response = await _http.DeleteAsync("api/Category/" + id);
            response.EnsureSuccessStatusCode();
            return true;
        }

    }
}


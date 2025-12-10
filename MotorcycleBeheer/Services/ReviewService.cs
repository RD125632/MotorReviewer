using MRL.Shared.Contracts;
using System.Net.Http.Json;

namespace MRL.Desktop.Services
{
    public class ReviewService
    {
        private readonly HttpClient _http;

        public ReviewService(string baseAddress)
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }


        // GET: /api/Review
        public async Task<List<ReviewDTO>> GetReviewsAsync()
        {
            var result = await _http.GetFromJsonAsync<List<ReviewDTO>>("api/Review");
            return result ?? [];
        }

        // POST: /api/Review
        public async Task<ReviewDTO?> CreateReviewAsync(ReviewDTO Review)
        {
            var response = await _http.PostAsJsonAsync("api/Review", Review);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ReviewDTO>();
        }

        // PUT: api/Review/5
        public async Task UpdateReviewAsync(ReviewDTO Review)
        {
            var response = await _http.PutAsJsonAsync("api/Review/" + Review.Id, Review);
            response.EnsureSuccessStatusCode();
        }

        // DELETE: api/Review/5
        public async Task DeleteReviewAsync(int id)
        {
            var response = await _http.DeleteAsync("api/Review/" + id);
            response.EnsureSuccessStatusCode();
        }

    }
}


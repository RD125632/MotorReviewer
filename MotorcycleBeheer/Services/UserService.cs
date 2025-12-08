using MRL.Shared.Contracts;
using System.Net.Http.Json;

namespace MRL.Desktop.Services
{
    public class UserService
    {
        private readonly HttpClient _http;

        public UserService(string baseAddress)
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }


        // GET: /api/User
        public async Task<List<UserDTO>> GetUsersAsync()
        {
            var result = await _http.GetFromJsonAsync<List<UserDTO>>("api/User");
            return result ?? [];
        }

        // POST: /api/User
        public async Task<UserDTO?> CreateUserAsync(UserDTO user)
        {
            var response = await _http.PostAsJsonAsync("api/User", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserDTO>();
        }

        // PUT: api/User/5
        public async Task<UserDTO?> UpdateUserAsync(UserDTO user)
        {
            var response = await _http.PutAsJsonAsync("api/User/" + user.Id, user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserDTO>();
        }

        // DELETE: api/User/5
        public async Task<bool> DeleteUserAsync(int id)
        {
            var response = await _http.DeleteAsync("api/User/" + id);
            response.EnsureSuccessStatusCode();
            return true;
        }

    }
}


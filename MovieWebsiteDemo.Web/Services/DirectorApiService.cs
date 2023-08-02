using MovieWebsiteDemo.Core.DTOs;

namespace MovieWebsiteDemo.Web.Services
{
    public class DirectorApiService
    {
        private readonly HttpClient _httpClient;

        public DirectorApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DirectorDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<DirectorDto>>>("directors");
            return response.Data;
        }
    }
}

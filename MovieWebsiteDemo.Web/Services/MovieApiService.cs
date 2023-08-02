using MovieWebsiteDemo.Core.DTOs;

namespace MovieWebsiteDemo.Web.Services
{
    public class MovieApiService
    {
        private readonly HttpClient _httpClient;

        public MovieApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MovieWithDirectorDto>> GetMovieWithDirectorAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<MovieWithDirectorDto>>>("movies/GetMovieWithDirector");
            return response.Data;
        }

        public async Task<MovieDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<MovieDto>>($"movies/{id}");
            return response.Data;

        }

        public async Task<MovieDto> SaveAsync(MovieDto newMovie)
        {
            var response = await _httpClient.PostAsJsonAsync("movies", newMovie);
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<MovieDto>>();
            return responseBody.Data;
        }

        public async Task<bool> UpdateAsync(MovieDto newMovie)
        {
            var response = await _httpClient.PutAsJsonAsync("movies", newMovie);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"movies/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

namespace MovieWebsiteDemo.Core.DTOs
{
    //Ders 34
    public class DirectorWithMoviesDto : DirectorDto
    {
        public List<MovieDto> Movies { get; set; }
    }
}

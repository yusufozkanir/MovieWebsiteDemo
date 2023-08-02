namespace MovieWebsiteDemo.Core.DTOs
{
    public class DirectorDto : BaseDto
    {
        public string DirectorName { get; set; }
        public DateTime DirectorBirthDate { get; set; }
        public string DirectorPhoto { get; set; }
        public string DirectorBiography { get; set; }
    }
}

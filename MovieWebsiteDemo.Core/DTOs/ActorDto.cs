namespace MovieWebsiteDemo.Core.DTOs
{
    public class ActorDto : BaseDto
    {
        public string ActorName { get; set; }
        public DateTime ActorBirthDate { get; set; }
        public string ActorPhoto { get; set; }
        public string ActorBiography { get; set; }
        public string ActorFilmography { get; set; }
    }
}

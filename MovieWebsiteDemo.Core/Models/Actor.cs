namespace MovieWebsiteDemo.Core.Models
{
    public class Actor : BaseEntity
    {
        public string ActorName { get; set; }
        public DateTime ActorBirthDate { get; set; }
        public string ActorPhoto { get; set; }
        public string ActorBiography { get; set; }
        public string ActorFilmography { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; }
    }
}

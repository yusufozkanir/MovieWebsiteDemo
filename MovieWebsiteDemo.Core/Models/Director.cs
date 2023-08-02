namespace MovieWebsiteDemo.Core.Models
{
    public class Director : BaseEntity
    {
        public string DirectorName { get; set; }
        public DateTime DirectorBirthDate { get; set; }
        public string DirectorPhoto { get; set; }
        public string DirectorBiography { get; set; }

        //Yönetmen - Film
        public List<Movie> Movies { get; }
    }
}

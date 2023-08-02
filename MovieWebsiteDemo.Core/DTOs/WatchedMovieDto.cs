namespace MovieWebsiteDemo.Core.DTOs
{
    internal class WatchedMovieDto : BaseDto
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public DateTime WatchedDate { get; set; }
    }
}

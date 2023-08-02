namespace MovieWebsiteDemo.Core.DTOs
{
    public class UserDto : BaseDto
    {
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public int UserPassword { get; set; }
    }
}

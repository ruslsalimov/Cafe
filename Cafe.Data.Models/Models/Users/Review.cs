namespace Cafe.Data.Models.Models.Users
{
    public class Review : BaseEntity
    {
        public string Text { get; set; }
        public User UserId { get; set; }
    }
}
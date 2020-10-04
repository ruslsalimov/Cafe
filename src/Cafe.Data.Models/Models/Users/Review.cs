using System;

namespace Cafe.Data.Models.Models.Users
{
    public class Review : BaseEntity
    {
        public string Text { get; set; }
        public User User { get; set; }
        public DateTime DateTime  { get; set; }
    }
}
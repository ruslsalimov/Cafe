using System;

namespace Cafe.Data.Models.Models.Users
{
    public class ReviewWithUser
    {
        public string Text { get; set; }
        public string UserName { get; set; }
        public DateTime DateTime { get; set; }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Cafe.Data.Models.Models.Users
{
    public class User : IdentityUser
    {
        public List<Review> Reviews { get; set; }
        public string FotoSrc { get; set; }
    }
}
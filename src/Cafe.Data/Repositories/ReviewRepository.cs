using System.Collections.Generic;
using System.Linq;
using Cafe.Data.Context;
using Cafe.Data.Models.Models.Users;
using Cafe.Data.Repositories.Abstract;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Data.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private IdentityContext db;

        public ReviewRepository(IdentityContext context)
        {
            db = context;
        }

        public IQueryable<Review> Reviews => db.Reviews;
        
        public void Add(Review review)
        {
            db.Add(review);
        }

        public IEnumerable<ReviewWithUser> GetReviewsWithUser()
        {
            return db.Reviews.Include(r => r.User)
                .Select(r => new ReviewWithUser()
                {
                    Text = r.Text,
                    UserName = r.User.UserName,
                    DateTime = r.DateTime
                }).AsEnumerable();
        }
        
        public void Commit()
        {
            db.SaveChanges();
        }
    }
}
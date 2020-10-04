using System.Collections.Generic;
using System.Linq;
using Cafe.Data.Models.Models.Users;

namespace Cafe.Data.Repositories.Abstract
{
    public interface IReviewRepository
    {
        public IQueryable<Review> Reviews { get; }
        void Add(Review review);
        IEnumerable<ReviewWithUser> GetReviewsWithUser();
        void Commit();
    }
}
using Cafe.Data.Context;
using Cafe.Data.Models.Models.Products;
using Cafe.Data.Repositories.Abstract;

namespace Cafe.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(MainContext context) : base(context)
        {
        }
    }
}
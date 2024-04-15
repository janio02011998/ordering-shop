using OrderingShop.Infrastructure.Context.Entities;
using OrderingShop.Infrastructure.Interfaces;


namespace OrderingShop.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

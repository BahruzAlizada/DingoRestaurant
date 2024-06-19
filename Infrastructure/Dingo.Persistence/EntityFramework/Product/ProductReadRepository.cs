using Dingo.Application.Abstracts;
using Dingo.Domain.Entities;
using Dingo.Persistence.Concrete;
using Dingo.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dingo.Persistence.EntityFramework
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public async Task<List<Product>> GetProductsPagedListAsync(int? catId, int take, int page)
        {
            using var context = new Context();

            List<Product> products = await context.Products.Where(x=>(catId==null || x.CategoryId==catId)).Include(x=>x.Category).
                Skip((page-1)*take).Take(take).ToListAsync();
            return products;
        }
    }
}

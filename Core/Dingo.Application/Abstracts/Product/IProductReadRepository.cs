using Dingo.Application.Repositories;
using Dingo.Domain.Entities;

namespace Dingo.Application.Abstracts
{
    public interface IProductReadRepository : IReadRepository<Product>
    {
        Task<List<Product>> GetProductsPagedListAsync(int? catId,int take, int page);
    }
}

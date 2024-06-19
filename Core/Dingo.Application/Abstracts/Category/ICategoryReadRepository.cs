using Dingo.Application.Repositories;
using Dingo.Application.ViewModels;
using Dingo.Domain.Entities;

namespace Dingo.Application.Abstracts
{
    public interface ICategoryReadRepository : IReadRepository<Category>
    {
        Task<List<Category>> GetActiveCategoriesWithProducts();
        Task<List<CategoryVM>> GetCategoryViewModels();
    }
}

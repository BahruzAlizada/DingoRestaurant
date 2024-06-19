using Dingo.Application.Abstracts;
using Dingo.Application.ViewModels;
using Dingo.Domain.Entities;
using Dingo.Persistence.Concrete;
using Dingo.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dingo.Persistence.EntityFramework
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public async Task<List<Category>> GetActiveCategoriesWithProducts()
        {
            using var context = new Context();

            List<Category> categories = await context.Categories.Where(x=>x.Status).Include(x=>x.Products).ToListAsync();
            return categories;
        }

        public async Task<List<CategoryVM>> GetCategoryViewModels()
        {
            using var context = new Context();

            List<Category> categories = await context.Categories.OrderByDescending(x=>x.Products.Count).Include(x => x.Products).ToListAsync();
            List<CategoryVM> categoryVMs = new List<CategoryVM>();

            foreach (var item in categories)
            {
                CategoryVM vm = new CategoryVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Status = item.Status,
                    ProductCount = await context.Products.Where(x => x.CategoryId == item.Id).CountAsync()
                };
                categoryVMs.Add(vm);
            }
            return categoryVMs;
        }
    }
}

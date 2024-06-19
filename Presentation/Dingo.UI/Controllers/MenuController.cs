using Dingo.Application.Abstracts;
using Dingo.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.UI.Controllers
{
    public class MenuController : Controller
    {
        private readonly ICategoryReadRepository categoryReadRepository;
        private readonly IProductReadRepository productReadRepository;
        public MenuController(ICategoryReadRepository categoryReadRepository, IProductReadRepository productReadRepository)
        {
            this.categoryReadRepository = categoryReadRepository;
            this.productReadRepository = productReadRepository;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            MenuVM menuVM = new MenuVM
            {
                Categories = await categoryReadRepository.GetActiveCategoriesWithProducts(),
                Products = await productReadRepository.GetAllAsync()
            };
            return View(menuVM);
        }
        #endregion
    }
}

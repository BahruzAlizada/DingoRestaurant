using Dingo.Persistence.Concrete;
using Dingo.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dingo.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class DashboardController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using var context = new Context();

            var statitcs = Task.Run(async () => new StatitcsModel
            {
                CategoryCount = await context.Categories.CountAsync(),
                ProductCount = await context.Products.CountAsync(),
                ContactCount = await context.Contacts.CountAsync()
            });
            await Task.WhenAll(statitcs);
            var model = statitcs.Result;

            return View(model);
        }
    }
}

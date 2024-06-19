using Microsoft.AspNetCore.Mvc;

namespace Dingo.UI.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

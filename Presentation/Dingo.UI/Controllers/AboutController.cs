using Dingo.Application.Abstracts;
using Dingo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.UI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutReadRepository aboutReadRepository;
        public AboutController(IAboutReadRepository aboutReadRepository)
        {
            this.aboutReadRepository = aboutReadRepository;
        }

        #region Index
        public IActionResult Index()
        {
            About about = aboutReadRepository.Get();
            return View(about);
        }
        #endregion
    }
}

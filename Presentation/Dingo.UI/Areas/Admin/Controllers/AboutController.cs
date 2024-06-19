using Dingo.Application.Abstracts;
using Dingo.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="SuperAdmin,Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutReadRepository aboutReadRepository;
        private readonly IAboutWriteRepository aboutWriteRepository;
        public AboutController(IAboutReadRepository aboutReadRepository, IAboutWriteRepository aboutWriteRepository)
        {
            this.aboutReadRepository = aboutReadRepository;
            this.aboutWriteRepository = aboutWriteRepository;
        }

        #region Index
        public IActionResult Index()
        {
            About about = aboutReadRepository.Get();
            return View(about);
        }
        #endregion

        #region Update
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            About dbAbout = aboutReadRepository.Get(x => x.Id == id);
            if (dbAbout == null) return BadRequest();

            return View(dbAbout);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int? id, About about)
        {
            if (id == null) return NotFound();
            About dbAbout = aboutReadRepository.Get(x => x.Id == id);
            if (dbAbout == null) return BadRequest();

            dbAbout.Id = about.Id;
            dbAbout.Status = about.Status;
            dbAbout.Title = about.Title;
            dbAbout.SubTitle = about.SubTitle;
            dbAbout.Description = about.Description;

            aboutWriteRepository.Update(about);
            return RedirectToAction("Index");
        }
        #endregion
    }
}

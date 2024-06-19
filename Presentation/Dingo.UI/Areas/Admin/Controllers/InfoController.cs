using Dingo.Application.Abstracts;
using Dingo.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class InfoController : Controller
    {
        private readonly IInfoReadRepository infoReadRepository;
        private readonly IInfoWriteRepository infoWriteRepository;
        public InfoController(IInfoReadRepository infoReadRepository, IInfoWriteRepository infoWriteRepository)
        {
            this.infoReadRepository = infoReadRepository;
            this.infoWriteRepository = infoWriteRepository;
        }

        #region Index
        public IActionResult Index()
        {
            Info info = infoReadRepository.Get();
            return View(info);
        }
        #endregion

        #region Update
        public IActionResult Update(int? id)
        {
            if (id is null) return NotFound();
            Info info = infoReadRepository.Get(x=>x.Id==id);
            if(info is null) return BadRequest();

            return View(info);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int? id, Info newInfo)
        {
            if (id is null) return NotFound();
            Info info = infoReadRepository.Get(x => x.Id == id);
            if (info is null) return BadRequest();

            info.PhoneNumber = newInfo.PhoneNumber;
            info.Address = newInfo.Address;
            info.EmailAddress = newInfo.EmailAddress;

            infoWriteRepository.Update(info);
            return RedirectToAction("Index");
        }
        #endregion
    }
}

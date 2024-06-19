using Dingo.Application.Abstracts;
using Dingo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactWriteRepository contactWriteRepository;
        public ContactController(IContactWriteRepository contactWriteRepository)
        {
            this.contactWriteRepository = contactWriteRepository;
        }

        #region Index
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Index(Contact contact)
        {
            await contactWriteRepository.AddAsync(contact);
            return RedirectToAction("Index");
        }
        #endregion
    }
}

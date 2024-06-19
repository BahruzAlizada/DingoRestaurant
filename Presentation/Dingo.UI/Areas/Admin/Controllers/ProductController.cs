using Dingo.Application.Abstracts;
using Dingo.Domain.Entities;
using Dingo.Infrastructure.Abstract;
using Dingo.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Dingo.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class ProductController : Controller
    {
        private readonly IProductReadRepository productReadRepository;
        private readonly IProductWriteRepository productWriteRepository;
        private readonly ICategoryReadRepository categoryReadRepository;
        private IWebHostEnvironment env;
        private readonly IPhotoService photoService;
        public ProductController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository,
            ICategoryReadRepository categoryReadRepository,IWebHostEnvironment env,IPhotoService photoService)
        {
            this.productReadRepository = productReadRepository;
            this.productWriteRepository = productWriteRepository;
            this.categoryReadRepository = categoryReadRepository;
            this.env = env;
            this.photoService = photoService;
        }

        #region Index
        public async Task<IActionResult> Index(int? catId,int page = 1)
        {
            ViewBag.PageCount = await productReadRepository.GetPagedCountAsync(take: 18);
            ViewBag.CurrentPage = page;

            List<Product> products = await productReadRepository.GetProductsPagedListAsync(catId,take: 18, page);
            return View(products);
        }
        #endregion

        #region Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await categoryReadRepository.GetAllAsync(x => x.Status);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Product product, int catId)
        {
            ViewBag.Categories = await categoryReadRepository.GetAllAsync(x => x.Status);

            #region Image
            (bool isValid, string errorMessage) = await photoService.PhotoChechkValidatorAsync(product.Photo,false,true);
            if (!isValid)
            {
                ModelState.AddModelError("Photo", errorMessage);
                return View();
            }
            string folder = Path.Combine(env.WebRootPath, "img", "products");
            product.Image = await photoService.SavePhotoAsync(product.Photo, folder); 
            #endregion

            product.CategoryId = catId;

            await productWriteRepository.AddAsync(product);
            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Categories = await categoryReadRepository.GetAllAsync(x => x.Status);

            if (id == null) return NotFound();
            Product dbProduct = await productReadRepository.GetAsync(x => x.Id == id);
            if (dbProduct == null) return BadRequest();

            return View(dbProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id,Product product, int catId)
        {
            ViewBag.Categories = await categoryReadRepository.GetAllAsync(x => x.Status);

            if (id == null) return NotFound();
            Product dbProduct = await productReadRepository.GetAsync(x => x.Id == id);
            if (dbProduct == null) return BadRequest();

            #region Image
            if(product.Photo is not null)
            {
                (bool isresult, string errormessage) = await photoService.PhotoChechkValidatorAsync(product.Photo, true, true);
                if (!isresult)
                {
                    ModelState.AddModelError("Photo", errormessage);
                    return View();
                }
                string folder = Path.Combine(env.WebRootPath, "img", "products");
                product.Image = await photoService.SavePhotoAsync(product.Photo, folder);

                string path = Path.Combine(env.WebRootPath, folder, dbProduct.Image);
                photoService.DeletePhoto(path);
            }
            else
            {
                product.Image = dbProduct.Image;
            }
            #endregion

            product.CategoryId = catId;
            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;

            await productWriteRepository.UpdateAsync(product);
            return RedirectToAction("Index");
        }
        #endregion

        #region Activity
        public IActionResult Activity(int? id)
        {
            if (id is null) return NotFound();
            Product product = productReadRepository.Get(x => x.Id == id);
            if (product is null) return BadRequest();

            productWriteRepository.Activity(product);
            return RedirectToAction("Index");
        }
        #endregion
    }

}

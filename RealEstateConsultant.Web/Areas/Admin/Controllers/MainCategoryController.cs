using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateConsultant.Application.UnitOfWorkPattern;
using RealEstateConsultant.Entities;
using RealEstateConsultant.Utilities;
using RealEstateConsultant.Utilities.ViewModels;
using System.Data;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace RealEstateConsultant.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.ManagerRole)]
    public class MainCategoryController : Controller
    {
        #region Ctor


        private readonly IHandleRepository _handleRepository;
        private IHostingEnvironment _environment;
        public MainCategoryController(IHandleRepository handleRepository, IHostingEnvironment environment)
        {
            _handleRepository = handleRepository;
            _environment = environment;
        }
        #endregion

        #region Parent Category


        #region Get Action

        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.ParentCategoryId = id;
            CategoryVM categories = new CategoryVM();
            if (id != null)
            {
                categories.ChialdCatLst =
                    await _handleRepository.ChialdCategory.GetAll(filter: c => c.MainCategoryId.Equals(id), includeProperties: "MainCategory");
                return View(categories);
            }
            else
            {
                categories.MainCatLst = await _handleRepository.MainCategory.GetAll(includeProperties: "ChildCategories");
                return View(categories);
            }

        }

        [HttpGet]
        public async Task<IActionResult> CreateParentCategory()
        {
            return View();
        }

        #endregion

        #region Post Action


        [HttpPost]
        public async Task<IActionResult> CreateParentCategory(MainCategory mainCategory)
        {
            var files = HttpContext.Request.Form.Files;
            UploadHelper UploadObj = new UploadHelper(_environment);
            if (files.Count > 0)
            {
                mainCategory.LogoPath = UploadObj.UploadFile(files[0], $@"images\main_cat_logo\").FileNameAddress;

            }

            var res = await _handleRepository.MainCategory.Add(mainCategory);
            await _handleRepository.SaveAsync();
            if (res.Status)
            {
                TempData["Message"] = res.Message;
                TempData["MessageType"] = "Success";
                return Redirect("/Admin/MainCategory/Index");
            }
            else
            {
                TempData["Message"] = res.Message;
                TempData["MessageType"] = "Error";
                return Redirect("/Admin/MainCategory/Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMainCategory(int id)
        {
            var cat = await _handleRepository.MainCategory.GetFirstOrDefault(filter: u => u.Id.Equals(id));
            if (cat == null)
            {
                return Json(new { message = "دسته بندی یافت نشد" });
            }

            if (!string.IsNullOrWhiteSpace(cat.LogoPath))
            {
                var oldImagePath = Path.Combine(_environment.WebRootPath, cat.LogoPath.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }
            var res = await _handleRepository.MainCategory.Remove(cat);
            _handleRepository.SaveAsync();
            return Json(res);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateParentCategory(MainCategory mainCategory)
        {
            var CatFromDb = await _handleRepository.MainCategory.GetFirstOrDefault(u => u.Id == mainCategory.Id);
            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(CatFromDb.LogoPath))
                {
                    var oldImagePath = Path.Combine(_environment.WebRootPath, CatFromDb.LogoPath.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                UploadHelper UploadObj = new UploadHelper(_environment);
                mainCategory.LogoPath = UploadObj.UploadFile(files[0], $@"images\main_cat_logo\").FileNameAddress;
            }

            var res = await _handleRepository.MainCategory.UpdateMainCategoryAsync(mainCategory);
            await _handleRepository.SaveAsync();
            if (res.Status)
            {
                TempData["Message"] = res.Message;
                TempData["MessageType"] = "Success";
                return Redirect("/Admin/MainCategory/Index");
            }
            else
            {
                TempData["Message"] = res.Message;
                TempData["MessageType"] = "Error";
                return Redirect("/Admin/MainCategory/Index");
            }
        }
        #endregion


        #endregion

        #region Chiald Category

        #region Get Action



        #endregion


        #region Post Action
        [HttpPost]
        public async Task<IActionResult> CreateChialdCategory(ChildCategory childCategory)
        {
            var files = HttpContext.Request.Form.Files;
            UploadHelper UploadObj = new UploadHelper(_environment);
            if (files.Count > 0)
            {
                childCategory.LogoPath = UploadObj.UploadFile(files[0], $@"images\child_cat_logo\").FileNameAddress;

            }

            var res = await _handleRepository.ChialdCategory.Add(childCategory);
            await _handleRepository.SaveAsync();
            if (res.Status)
            {
                TempData["Message"] = res.Message;
                TempData["MessageType"] = "Success";
                return Redirect("/Admin/MainCategory/Index");
            }
            else
            {
                TempData["Message"] = res.Message;
                TempData["MessageType"] = "Error";
                return Redirect("/Admin/MainCategory/Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteChildCategory(int id)
        {
            var cat = await _handleRepository.ChialdCategory.GetFirstOrDefault(filter: u => u.Id.Equals(id));
            if (cat == null)
            {
                return Json(new { message = "دسته بندی یافت نشد" });
            }

            if (!string.IsNullOrWhiteSpace(cat.LogoPath))
            {
                var oldImagePath = Path.Combine(_environment.WebRootPath, cat.LogoPath.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }
            var res = await _handleRepository.ChialdCategory.Remove(cat);
            _handleRepository.SaveAsync();
            return Json(res);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateChildCategory(ChildCategory childCategory)
        {
            var CatFromDb = await _handleRepository.ChialdCategory.GetFirstOrDefault(u => u.Id == childCategory.Id);
            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(CatFromDb.LogoPath))
                {
                    var oldImagePath = Path.Combine(_environment.WebRootPath, CatFromDb.LogoPath.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                UploadHelper UploadObj = new UploadHelper(_environment);
                childCategory.LogoPath = UploadObj.UploadFile(files[0], $@"images\child_cat_logo\").FileNameAddress;
            }

            var res = await _handleRepository.ChialdCategory.UpdateChialdCategoryAsync(childCategory);
            await _handleRepository.SaveAsync();
            if (res.Status)
            {
                TempData["Message"] = res.Message;
                TempData["MessageType"] = "Success";
                return Redirect("/Admin/MainCategory/Index/"+ childCategory.MainCategoryId);
            }
            else
            {
                TempData["Message"] = res.Message;
                TempData["MessageType"] = "Error";
                return Redirect($"/Admin/MainCategory/Index/"+ childCategory.MainCategoryId);
            }
        }
        #endregion

        #endregion


    }
}

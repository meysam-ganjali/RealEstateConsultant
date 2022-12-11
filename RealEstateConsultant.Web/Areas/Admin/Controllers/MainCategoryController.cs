using Microsoft.AspNetCore.Mvc;
using RealEstateConsultant.Application.UnitOfWorkPattern;
using RealEstateConsultant.Entities;
using RealEstateConsultant.Utilities;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace RealEstateConsultant.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainCategoryController : Controller
    {
        private readonly IHandleRepository _handleRepository;

        public MainCategoryController(IHandleRepository handleRepository, IHostingEnvironment environment)
        {
            _handleRepository = handleRepository;
            _environment = environment;
        }
        private IHostingEnvironment _environment;
        
        /*****************    Get Action    ************************/
        public async Task<IActionResult> Index()
        {
            var res = await _handleRepository.MainCategory.GetAll(includeProperties: "ChildCategories");
            return View(res);
        }

        [HttpGet]
        public async Task<IActionResult> CreateParentCategory()
        {
            return View();
        }

        /*****************    Post Action    ************************/
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
            var res = await _handleRepository.MainCategory.Remove(cat);
            _handleRepository.SaveAsync();
            return Json(res);
        }
    }
}

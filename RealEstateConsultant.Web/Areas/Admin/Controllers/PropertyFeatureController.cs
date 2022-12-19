using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateConsultant.Application.UnitOfWorkPattern;
using RealEstateConsultant.Entities;
using RealEstateConsultant.Utilities;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace RealEstateConsultant.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles=SD.ManagerRole)]
    public class PropertyFeatureController : Controller
    {
        private readonly IHandleRepository _handleRepository;
        private IHostingEnvironment _environment;

        public PropertyFeatureController(IHandleRepository handleRepository, IHostingEnvironment environment)
        {
            _handleRepository = handleRepository;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            var prop = await _handleRepository.PropertyFeature.GetAll();
            return View(prop);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProperty(Property property)
        {

            var files = HttpContext.Request.Form.Files;
            UploadHelper UploadObj = new UploadHelper(_environment);
            if (files.Count > 0)
            {
                property.LogoPath = UploadObj.UploadFile(files[0], $@"images\proprty_logo\").FileNameAddress;

            }

            var res = await _handleRepository.PropertyFeature.Add(property);
            await _handleRepository.SaveAsync();
            if (res.Status)
            {
                TempData["Message"] = res.Message;
                TempData["MessageType"] = "Success";
                return Redirect("/Admin/PropertyFeature/Index");
            }
            else
            {
                TempData["Message"] = res.Message;
                TempData["MessageType"] = "Error";
                return Redirect("/Admin/PropertyFeature/Index");
            }
        }
    }
}

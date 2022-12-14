using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateConsultant.Application.UnitOfWorkPattern;
using RealEstateConsultant.Entities;
using RealEstateConsultant.Utilities;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace RealEstateConsultant.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.ManagerRole)]
    public class HousingController : Controller
    {
        #region ctor
        private readonly IHandleRepository _handleRepository;
        private IHostingEnvironment _environment;

        public HousingController(IHandleRepository handleRepository, IHostingEnvironment environment)
        {
            _handleRepository = handleRepository;
            _environment = environment;
        }


        #endregion

        #region Get

          public async Task<IActionResult> Index()
        {
            var model = await _handleRepository.Housing.GetAll(
                includeProperties: "ApplicationUser,HousingCategories,HousingProperties,HousingAmounts,HousingImages,HousingCategories.ChildCategory.MainCategory");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateHouse()
        {
          
            return View();
        }

        #endregion

        #region Post

        [HttpPost]
        public async Task<IActionResult> CreateHouse(Housing housing)
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            housing.ApplicationUserId = claim.Value;
            var res = await _handleRepository.Housing.Add(housing);
            await _handleRepository.SaveAsync();
            if (res.Status)
            {
                TempData["Message"] = res.Message;
                TempData["MessageType"] = "Success";
                return Redirect("/Admin/Housing/Index");
            }
            else
            {
                TempData["Message"] = res.Message;
                TempData["MessageType"] = "Error";
                return Redirect("/Admin/Housing/Index");
            }
        }

        #endregion
    }
}

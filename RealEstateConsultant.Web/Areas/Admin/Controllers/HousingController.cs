using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateConsultant.Application.UnitOfWorkPattern;
using RealEstateConsultant.Utilities;
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

        public async Task<IActionResult> Index()
        {
            var model = await _handleRepository.Housing.GetAll(
                includeProperties: "ApplicationUser,HousingCategories,HousingProperties,HousingAmounts,HousingImages,HousingCategories.ChildCategory.MainCategory");
            return View(model);
        }
    }
}

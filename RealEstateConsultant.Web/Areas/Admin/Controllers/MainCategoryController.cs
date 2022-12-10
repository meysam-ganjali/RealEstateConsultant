using Microsoft.AspNetCore.Mvc;
using RealEstateConsultant.Application.UnitOfWorkPattern;
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
        public async Task<IActionResult> Index()
        {
            var res = await _handleRepository.MainCategory.GetAll(includeProperties: "ChildCategories");
            return View(res);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RealEstateConsultant.Application.Repository.IRepository;
using RealEstateConsultant.Entities;
using RealEstateConsultant.Utilities;
using RealEstateConsultant.Web.Data;

namespace RealEstateConsultant.Application.Repository;

public class MainCategoryRepository:Repository<MainCategory>,IMainCategoryRepository
{
    private readonly DataBaseContext _db;

    public MainCategoryRepository(DataBaseContext db) : base(db)
    {
        _db = db;
    }
    public async Task<ResultDto> UpdateMainCategoryAsync(MainCategory mainCategory)
    {
        var mainCatFromDb = await _db.MainCategories.FirstOrDefaultAsync(c => c.Id == mainCategory.Id);
        if (mainCatFromDb == null)
        {
            return new ResultDto
            {
                Message = "دسته بندی یافت نشد",
                Status = false
            };
        }

        try
        {

            if (!string.IsNullOrWhiteSpace(mainCategory.LogoPath))  
            {
                mainCatFromDb.LogoPath = mainCategory.LogoPath;
            }

            mainCatFromDb.Name = mainCategory.Name;
            mainCatFromDb.Decription=mainCategory.Decription;
            mainCatFromDb.DisplayOrder=mainCategory.DisplayOrder;
            return new ResultDto
            {
                Message = $"دسته بندی {mainCatFromDb.Name} با کد {mainCatFromDb.Id} با موفقیت بروز شد",
                Status = true
            };
        }
        catch (Exception e)
        {
            return new ResultDto
            {
                Message = e.Message,
                Status = false
            };
        }
    }
}
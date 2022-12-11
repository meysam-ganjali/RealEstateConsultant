using Microsoft.EntityFrameworkCore;
using RealEstateConsultant.Application.Repository.IRepository;
using RealEstateConsultant.Entities;
using RealEstateConsultant.Utilities;
using RealEstateConsultant.Web.Data;

namespace RealEstateConsultant.Application.Repository;

public class ChialdCategoryRepository:Repository<ChildCategory>,IChialdCategoryRepository
{
    private readonly DataBaseContext _db;

    public ChialdCategoryRepository(DataBaseContext db) : base(db)
    {
        _db = db;
    }
    public async Task<ResultDto> UpdateChialdCategoryAsync(ChildCategory childCategory)
    {
        var chialdCatFromDb = await _db.ChildCategories.FirstOrDefaultAsync(c => c.Id == childCategory.Id);
        if (chialdCatFromDb == null)
        {
            return new ResultDto
            {
                Message = "دسته بندی یافت نشد",
                Status = false
            };
        }

        try
        {

            if (!string.IsNullOrWhiteSpace(childCategory.LogoPath))
            {
                chialdCatFromDb.LogoPath = childCategory.LogoPath;
            }

            chialdCatFromDb.Name = childCategory.Name;
            chialdCatFromDb.Decription = childCategory.Decription;
            chialdCatFromDb.DisplayOrder = childCategory.DisplayOrder;
            return new ResultDto
            {
                Message = $"دسته بندی {chialdCatFromDb.Name} با کد {chialdCatFromDb.Id} با موفقیت بروز شد",
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
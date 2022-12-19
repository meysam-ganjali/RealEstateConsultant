using Microsoft.EntityFrameworkCore;
using RealEstateConsultant.Application.Repository.IRepository;
using RealEstateConsultant.Entities;
using RealEstateConsultant.Utilities;
using RealEstateConsultant.Web.Data;

namespace RealEstateConsultant.Application.Repository;

public class PropertyRepository:Repository<Property>,IPropertyRepository
{
    private readonly DataBaseContext _db;

    public PropertyRepository(DataBaseContext db) : base(db)
    {
        _db = db;
    }
    public async Task<ResultDto> UpdatePropertyAsync(Property property)
    {
        var propertyFromDb = await _db.Properties.FirstOrDefaultAsync(c => c.Id.Equals(property.Id));
        if (propertyFromDb == null)
        {
            return new ResultDto
            {
                Status = false,
                Message = "مشخصات یافت نشد"
            };
        }

        if (!string.IsNullOrWhiteSpace(property.LogoPath))
        {
            propertyFromDb.LogoPath = property.LogoPath;
        }
        propertyFromDb.Title=property.Title;
        return new ResultDto
        {
            Message = "بروزرسانی با موفقیت به اتمام رسید",
            Status = true,
        };
    }
}
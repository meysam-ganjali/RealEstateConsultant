using RealEstateConsultant.Application.Repository.IRepository;
using RealEstateConsultant.Entities;
using RealEstateConsultant.Utilities;
using RealEstateConsultant.Web.Data;

namespace RealEstateConsultant.Application.Repository;

public class HousingRepository:Repository<Housing>,IHousingRepository
{
    private readonly DataBaseContext _db;

    public HousingRepository(DataBaseContext db) : base(db)
    {
        _db = db;
    }
    public async Task<ResultDto> UpdateHousingAsync(Housing housing)
    {
        var HousingFromDb = await _db.Housings.FindAsync(housing.Id);
        if (HousingFromDb == null)
        {
            return new ResultDto
            {
                Message = "ملکی با این مشخصات یافت نشد",
                Status = false
            };
        }
        HousingFromDb.Title=housing.Title;
        HousingFromDb.Address=housing.Address;
        HousingFromDb.FloorNumber=housing.FloorNumber;
        HousingFromDb.UnitNumber=housing.UnitNumber;
        HousingFromDb.Metrag=housing.Metrag;
        return new ResultDto()
        {
            Status = true,
            Message = ""
        };
    }
}
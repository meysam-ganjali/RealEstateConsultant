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
    public Task<ResultDto> UpdateHousingAsync(Housing housing)
    {
        throw new NotImplementedException();
    }
}
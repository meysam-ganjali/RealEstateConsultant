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
    public Task<ResultDto> UpdateChialdCategoryAsync(ChildCategory childCategory)
    {
        throw new NotImplementedException();
    }
}
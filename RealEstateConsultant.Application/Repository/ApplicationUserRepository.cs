using RealEstateConsultant.Application.Repository.IRepository;
using RealEstateConsultant.Entities;
using RealEstateConsultant.Utilities;
using RealEstateConsultant.Web.Data;

namespace RealEstateConsultant.Application.Repository;

public class ApplicationUserRepository:Repository<ApplicationUser>,IApplicationRepository
{
    private readonly DataBaseContext _db;

    public ApplicationUserRepository(DataBaseContext db) : base(db)
    {
        _db = db;
    }
    public Task<ResultDto> ChangeUserStatusAsync(string UserId)
    {
        throw new NotImplementedException();
    }
}
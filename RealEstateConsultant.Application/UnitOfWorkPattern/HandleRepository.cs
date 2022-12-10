using RealEstateConsultant.Application.Repository;
using RealEstateConsultant.Application.Repository.IRepository;
using RealEstateConsultant.Web.Data;

namespace RealEstateConsultant.Application.UnitOfWorkPattern;

public class HandleRepository: IHandleRepository
{
    private readonly DataBaseContext _db;

    public HandleRepository(DataBaseContext db)
    {
        _db = db;
        ApplicationUser = new ApplicationUserRepository(_db);
    }

    public IApplicationRepository ApplicationUser { get; private set; }
    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}
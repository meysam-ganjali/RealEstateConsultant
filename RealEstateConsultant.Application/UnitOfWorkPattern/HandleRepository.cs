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
        MainCategory = new MainCategoryRepository(_db);
        ChialdCategory = new ChialdCategoryRepository(_db);
    }

    public IApplicationRepository ApplicationUser { get; private set; }
    public IMainCategoryRepository MainCategory { get; private set; }
    public IChialdCategoryRepository ChialdCategory { get; private set; }
    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}
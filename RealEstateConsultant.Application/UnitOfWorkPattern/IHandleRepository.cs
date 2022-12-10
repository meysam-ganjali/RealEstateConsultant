using RealEstateConsultant.Application.Repository.IRepository;

namespace RealEstateConsultant.Application.UnitOfWorkPattern;

public interface IHandleRepository:IDisposable
{ 
    IApplicationRepository ApplicationUser { get; }
    IMainCategoryRepository MainCategory { get; }
    Task SaveAsync();
}
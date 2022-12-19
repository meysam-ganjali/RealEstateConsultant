using RealEstateConsultant.Application.Repository.IRepository;

namespace RealEstateConsultant.Application.UnitOfWorkPattern;

public interface IHandleRepository:IDisposable
{ 
    IApplicationRepository ApplicationUser { get; }
    IMainCategoryRepository MainCategory { get; }
    IChialdCategoryRepository ChialdCategory { get; }
    IHousingRepository Housing { get; }
    IPropertyRepository PropertyFeature { get; }
    Task SaveAsync();
}
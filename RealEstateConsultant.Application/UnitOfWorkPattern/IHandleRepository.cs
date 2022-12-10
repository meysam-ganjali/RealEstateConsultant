using RealEstateConsultant.Application.Repository.IRepository;

namespace RealEstateConsultant.Application.UnitOfWorkPattern;

public interface IHandleRepository:IDisposable
{ 
    IApplicationRepository ApplicationUser { get; }
    Task SaveAsync();
}
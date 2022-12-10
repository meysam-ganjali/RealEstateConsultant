using RealEstateConsultant.Entities;
using RealEstateConsultant.Utilities;

namespace RealEstateConsultant.Application.Repository.IRepository;

public interface IApplicationRepository:IRepository<ApplicationUser>
{
    Task<ResultDto> ChangeUserStatusAsync(string UserId);
}
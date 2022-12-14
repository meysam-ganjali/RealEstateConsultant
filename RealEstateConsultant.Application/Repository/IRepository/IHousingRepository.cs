using RealEstateConsultant.Entities;
using RealEstateConsultant.Utilities;

namespace RealEstateConsultant.Application.Repository.IRepository;

public interface IHousingRepository:IRepository<Housing>
{
    Task<ResultDto> UpdateHousingAsync(Housing housing);
}
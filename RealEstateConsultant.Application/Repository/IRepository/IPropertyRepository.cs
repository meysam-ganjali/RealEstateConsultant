
using RealEstateConsultant.Entities;
using RealEstateConsultant.Utilities;

namespace RealEstateConsultant.Application.Repository.IRepository;

public interface IPropertyRepository:IRepository<Property>
{
    Task<ResultDto> UpdatePropertyAsync(Property property);
}
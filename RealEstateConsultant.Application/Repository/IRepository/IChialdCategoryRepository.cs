using RealEstateConsultant.Entities;
using RealEstateConsultant.Utilities;

namespace RealEstateConsultant.Application.Repository.IRepository;

public interface IChialdCategoryRepository:IRepository<ChildCategory>
{
    Task<ResultDto> UpdateChialdCategoryAsync(ChildCategory childCategory);
}
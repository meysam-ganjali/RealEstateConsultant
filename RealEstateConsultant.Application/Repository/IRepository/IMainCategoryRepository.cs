using RealEstateConsultant.Entities;
using RealEstateConsultant.Utilities;

namespace RealEstateConsultant.Application.Repository.IRepository;

public interface IMainCategoryRepository:IRepository<MainCategory>
{
    Task<ResultDto> UpdateMainCategoryAsync(MainCategory mainCategory);
}
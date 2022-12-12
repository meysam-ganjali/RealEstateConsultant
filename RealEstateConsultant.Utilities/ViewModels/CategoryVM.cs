using RealEstateConsultant.Entities;

namespace RealEstateConsultant.Utilities.ViewModels;

public class CategoryVM
{
    public IEnumerable<MainCategory> MainCatLst { get; set; }
    public IEnumerable<ChildCategory> ChialdCatLst { get; set; }
}
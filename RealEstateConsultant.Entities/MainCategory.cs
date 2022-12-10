using System.ComponentModel.DataAnnotations;

namespace RealEstateConsultant.Entities;

public class MainCategory:BaseEntity
{
    [Required(ErrorMessage = "نام دسته بندی را مشخص نکرده اید")]
    [MaxLength(255,ErrorMessage = "تعداد حروف از 255 حرف بیشتر است")]
    public string Name { get; set; }
    public string? LogoPath { get; set; }
    public string? Decription { get; set; }
    public int? DisplayOrder { get; set; }
    public ICollection<ChildCategory> ChildCategories { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateConsultant.Entities;

public class ChildCategory:BaseEntity
{
    [Required(ErrorMessage = "نام دسته بندی را مشخص نکرده اید")]
    [MaxLength(255, ErrorMessage = "تعداد حروف از 255 حرف بیشتر است")]
    public string Name { get; set; }
    public string? LogoPath { get; set; }
    public string? Decription { get; set; }
    public int? DisplayOrder { get; set; }
    public int MainCategoryId { get; set; }
    [ForeignKey("MainCategoryId")]
    public MainCategory MainCategory { get; set; }
    public ICollection<HousingCategory> HousingCategories { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateConsultant.Entities;

public class HousingCategory : BaseEntity
{
    public int HousingId { get; set; }
    [ForeignKey("HousingId")]
    public Housing Housing { get; set; }

    public int ChildCategoryId { get; set; }
    [ForeignKey("ChildCategoryId")]
    public ChildCategory ChildCategory { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateConsultant.Entities;

public class Housing:BaseEntity
{
    public string Title { get; set; }
    public string Address { get; set; }
    public int UnitNumber { get; set; }
    public int FloorNumber { get; set; }
    public int Metrag { get; set; }
    public string ApplicationUserId { get; set; }
    [ForeignKey("ApplicationUserId")]
    public ApplicationUser ApplicationUser { get; set; }
    public ICollection<HousingCategory> HousingCategories { get; set; }
    public ICollection<HousingProperty> HousingProperties { get; set; }
    public ICollection<HousingAmount> HousingAmounts { get; set; }
    public ICollection<HousingImage> HousingImages { get; set; }
}
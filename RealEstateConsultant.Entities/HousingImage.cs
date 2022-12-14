using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateConsultant.Entities;

public class HousingImage:BaseEntity
{
    public string ImagePath { get; set; }
    public string AltAttr { get; set; }
    public int? Width{ get; set; }
    public int? height { get; set; }
    public int HousingId { get; set; }
    [ForeignKey("HousingId")]
    public Housing Housing { get; set; }
}
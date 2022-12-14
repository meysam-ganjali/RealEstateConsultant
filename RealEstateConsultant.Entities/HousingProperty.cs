using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateConsultant.Entities;

public class HousingProperty : BaseEntity
{
    public string PropertyName { get; set; }
    public string PropertyValue { get; set; }
    public string? LogoPath { get; set; }
    public int HousingId { get; set; }
    [ForeignKey("HousingId")]
    public Housing Housing { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateConsultant.Entities;

public class HousingProperty : BaseEntity
{
    public int PropertyId { get; set; }
    [ForeignKey("PropertyId")]
    public Property Property { get; set; }
    public string Value { get; set; }
    public int HousingId { get; set; }
    [ForeignKey("HousingId")]
    public Housing Housing { get; set; }
}
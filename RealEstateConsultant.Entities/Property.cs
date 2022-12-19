namespace RealEstateConsultant.Entities;

public class Property:BaseEntity
{
    public string Title { get; set; }
    public string Value { get; set; }
    public string? LogoPath { get; set; }
    public ICollection<HousingProperty> HousingProperties { get; set; }
}
namespace RealEstateConsultant.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }

}
public class BaseEntity<T>
{
    public T Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

}
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateConsultant.Entities;

public class HousingAmount : BaseEntity
{
    public long? AmountForSell { get; set; }
    public int? ImountForRent { get; set; }
    public int? ImountForDeposit { get; set; }
    public int HousingId { get; set; }
    [ForeignKey("HousingId")]
    public Housing Housing { get; set; }
}
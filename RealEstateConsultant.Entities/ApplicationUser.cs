using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RealEstateConsultant.Entities;

public class ApplicationUser : IdentityUser
{
    [Required(ErrorMessage = "نام را وارد نکرده اید")]
    [MaxLength(300)]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "نام خانوادگی را وارد نکرده اید")]
    [MaxLength(300)]
    public string LastName { get; set; }
    public string UserPhone { get; set; }
    public bool IsActive { get; set; }
}
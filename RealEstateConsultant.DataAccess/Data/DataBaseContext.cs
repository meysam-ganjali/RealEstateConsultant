using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstateConsultant.Entities;

namespace RealEstateConsultant.Web.Data;

public class DataBaseContext : IdentityDbContext<IdentityUser>
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<MainCategory> MainCategories { get; set; }
    public DbSet<ChildCategory> ChildCategories { get; set; }
    public DbSet<HousingCategory> HousingCategories { get; set; }
    public DbSet<HousingProperty> HousingProperties { get; set; }
    public DbSet<HousingAmount> HousingAmounts { get; set; }
    public DbSet<HousingImage> HousingImages { get; set; }
    public DbSet<Housing> Housings { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}

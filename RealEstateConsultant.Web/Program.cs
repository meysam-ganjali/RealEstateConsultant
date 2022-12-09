using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstateConsultant.Web.Data;

#region Variables

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DataBaseContextConnection") ?? throw new InvalidOperationException("Connection string 'DataBaseContextConnection' not found.");


#endregion

#region Register Servises

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<DataBaseContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

#endregion


#region Configure the HTTP request pipeline
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();

#endregion



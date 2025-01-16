using SensiveBlogProject.DataAccessLayer.Context;
using SensiveBlogProject.EntityLayer.Concrete;
using SensiveBlogProject.PresentationLayer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//AddDbContext: veritabanı bağlantılarımızı yapacağımız yeri belirtmek için kullandık
builder.Services.AddDbContext<SensiveContext>();
//AddEntityFrameworkStores: identity kütüphanesine ait yapacağımız işlemlere izin verecek olan komut
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SensiveContext>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddControllersWithViews();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

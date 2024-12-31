using FluentValidation.AspNetCore;
using SensiveBlog.BusinessLayer.Abstract;
using SensiveBlog.BusinessLayer.Concrete;
using SensiveBlog.BusinessLayer.Container;
using SensiveBlog.DataAccessLayer.Abstract;
using SensiveBlog.DataAccessLayer.Context;
using SensiveBlog.DataAccessLayer.EntityFramework;
using SensiveBlog.EntityLayer.Concrete;
using SensiveBlog.PresentationLayer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SensiveContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SensiveContext>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.ContainerDependencies(); //extension sınıfını çağırdık


builder.Services.AddControllersWithViews().AddFluentValidation();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();

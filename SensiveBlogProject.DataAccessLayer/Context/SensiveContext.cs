using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SensiveBlogProject.EntityLayer.Concrete;

namespace SensiveBlogProject.DataAccessLayer.Context
{
    //SensiveContext, DbSet'leri kullanabilmek için DbContext'ten miras alır.
    public class SensiveContext : IdentityDbContext<AppUser,AppRole,int> //AspNetUser tablosu AspNetRole tablosuyla ilişkili olduğu için eğer ki AspNetUser tablosunun id değeri int türüne dönüştüyse o zaman Role Tablosunu da int türüne dönüştürmeliyiz ki IdentityDbContext'in 2.overloadını karşılayabilelim
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-F5CBDSU\\SQLEXPRESS;initial Catalog=SensiveBlogDb;integrated security=true");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<TagCloud> TagClouds { get; set; }
    }
}

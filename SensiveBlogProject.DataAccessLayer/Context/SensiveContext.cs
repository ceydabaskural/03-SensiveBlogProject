using Microsoft.EntityFrameworkCore;
using SensiveBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlogProject.DataAccessLayer.Context
{
    public class SensiveContext : DbContext //DbSet leri kullanabilmek için DbContext ten miras alır.
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

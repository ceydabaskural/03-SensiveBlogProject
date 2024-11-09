using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlog.EntityLayer.Concrete
{
    //AppUser sınıfını eklememizin sebebi özelleştirebilmek, entitylerle ilişkili hale getirebilmek
    public class AppUser : IdentityUser<int> //identity user dan miras aldığında biz bu tabloyu özelleştirebiliyoruz, kullanıcının id sinin int olmasını istediğimiz için key değerini int olarak atadık
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public List<Article> Articles { get; set; }
        public List<Comment> Comments { get; set; }
    }
}

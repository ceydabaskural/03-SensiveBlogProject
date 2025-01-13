using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlogProject.EntityLayer.Concrete
{
    //IdentityUser dan miras aldığı zaman asp.net user tablosunu özelleştirebilme imkanı tanıyor.
    public class AppUser : IdentityUser<int> //AspNetUser tablosunun id değeri string olarak geliyor biz int türünde olmasını istediğimiz için bu şekilde belirttik
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
    }
}

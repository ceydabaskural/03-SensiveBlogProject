using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlogProject.EntityLayer.Concrete
{
    //AspNetUser ile AspNetRole tablolarımız ilişkili olduğundan AspNetUser ın id si int ise Role tablosunun da int olması gerektiği için böyle bir işlem gerçekleştirdik:
    //AspNetUser tablosu IdentityUser dan; AspNetRole tablosu IdentityRole den miras alır
    public class AppRole : IdentityRole<int> 
    {
    }
}

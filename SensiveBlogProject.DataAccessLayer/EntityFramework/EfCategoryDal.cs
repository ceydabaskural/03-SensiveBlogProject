using Microsoft.EntityFrameworkCore;
using SensiveBlogProject.DataAccessLayer.Abstract;
using SensiveBlogProject.DataAccessLayer.Context;
using SensiveBlogProject.DataAccessLayer.Repositories;
using SensiveBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlogProject.DataAccessLayer.EntityFramework
{
    //ICategoryDal dan da miras aldı, çünkü sadece category e ait metot da olabilir
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        //constructor metot oluşturmamız gerekti çünkü generic repository de dependency injection uygulayabilmek için constructor metot oluşturduk
        public EfCategoryDal(SensiveContext context) : base(context)
        {
        }

        public List<Category> CountCategoriesWithArticles()
        {
            var context = new SensiveContext();
            var value = context.Categories.Include(x => x.Articles).ToList();
            return value;
        }
    }
}

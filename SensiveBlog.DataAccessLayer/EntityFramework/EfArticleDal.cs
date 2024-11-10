using Microsoft.EntityFrameworkCore;
using SensiveBlog.DataAccessLayer.Abstract;
using SensiveBlog.DataAccessLayer.Context;
using SensiveBlog.DataAccessLayer.Repositories;
using SensiveBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlog.DataAccessLayer.EntityFramework
{
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        public EfArticleDal(SensiveContext context) : base(context)
        {

        }
        public List<Article> ArticleListwithCategory()
        {
            var context = new SensiveContext();
            var values = context.Articles.Include(x => x.Category).ToList(); //burada category sınıfını Article sınıfına dahil ettik
            return values;
        }

        public List<Article> ArticleListwithCategoryAndAppUser()
        {
            var context = new SensiveContext();
            var values = context.Articles.Include(x => x.Category).Include(y => y.AppUser).ToList(); //burada category ve appuser sınıfını Article sınıfına dahil ettik
            return values;
        }
    }
}

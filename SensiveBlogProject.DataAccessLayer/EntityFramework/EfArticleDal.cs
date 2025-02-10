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
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        public EfArticleDal(SensiveContext context) : base(context)
        {
        }

        public List<Article> ArticleListWithCategory()
        {
            var context = new SensiveContext();
            var values = context.Articles.Include(x => x.Category).ToList();
            return values;
        }

        public List<Article> ArticleListWithCategoryAndAppUser()
        {
            var context = new SensiveContext();
            var values = context.Articles.Include(x=>x.Category).Include(x=>x.AppUser).Include(y=>y.Comments).Take(6).ToList();
            return values;
        }

        public Article GetArticleById(int id)
        {
            var context = new SensiveContext();
            var values = context.Articles
                      .Include(a => a.AppUser)
                      .Include(c => c.Category)
                      .Include(d => d.Comments)
                      .FirstOrDefault(x => x.ArticleId == id);
            return values;
        }

        public List<Article> GetArticlesByAppUserId(int id)
        {
            var context = new SensiveContext();
            var value = context.Articles.Where(x => x.AppUserId == id).Include(z=>z.AppUser).Include(c=>c.Category).ToList();
            return value;
        }

        public Article GetLastArticle()
        {
            var context = new SensiveContext();
            var values = context.Articles.OrderByDescending(x => x.ArticleId).Take(1).FirstOrDefault();
            return values;
        }

        public List<Article> GetLastFiveArticle()
        {
            var context = new SensiveContext();
            var values = context.Articles.OrderByDescending(x=>x.ArticleId).Include(x => x.Category).ToList();
            return values;
        }

        public List<Article> GetPopularBlogs()
        {
            var context = new SensiveContext();
            var random = new Random(); // Rastgele sayı üretici
            // Verileri önce listeye çek, ardından rastgele sırala
            var values = context.Articles.Include(z=>z.AppUser).Include(x=>x.Comments).ToList().OrderBy(b => random.Next()).Take(3).ToList();
            return values;
        

        }
    }
}

using Microsoft.EntityFrameworkCore;
using SensiveBlog.DataAccessLayer.Abstract;
using SensiveBlog.DataAccessLayer.Context;
using SensiveBlog.DataAccessLayer.Repositories;
using SensiveBlog.EntityLayer;
using SensiveBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlog.DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public EfCommentDal(SensiveContext context) : base(context)
        {
        }

        public List<Comment> GetCommentsByArticleId(int id)
        {
            var context = new SensiveContext();
            var value = context.Comments.Where(x => x.ArticleId == id).Include(y=>y.Article).Include(z=>z.AppUser).ToList();
            return value;
        }

        public int CountCommentsByArticleId(Article article)
        {
            var context = new SensiveContext();
            var value = context.Comments.Select(x => x.ArticleId == article.ArticleId).Count();
            return value;
        }

    }
}

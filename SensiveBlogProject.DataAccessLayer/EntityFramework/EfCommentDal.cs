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
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public EfCommentDal(SensiveContext context) : base(context)
        {
        }

        public List<Comment> GetCommentsByArticleId(int id)
        {
            //entitye özgü metot olduğu için article ve appuser ı include etmemiz gerek (çünkü comment tablosu article ve appuser ile ilişkili ve bu tablolardan veri çekiyoruz)
            var context = new SensiveContext();
            var value = context.Comments.Where(x=>x.ArticleId == id).Include(y=>y.Article).Include(z=>z.AppUser).ToList();
            return value;
        }
    }
}

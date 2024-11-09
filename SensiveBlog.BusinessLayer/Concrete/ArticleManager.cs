using SensiveBlog.BusinessLayer.Abstract;
using SensiveBlog.DataAccessLayer.Abstract;
using SensiveBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlog.BusinessLayer.Concrete
{
    public class ArticleManager : IArticleService
    {
        public void TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> TGetAll()
        {
            throw new NotImplementedException();
        }

        public Article TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Article entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Article entity)
        {
            throw new NotImplementedException();
        }
    }
}

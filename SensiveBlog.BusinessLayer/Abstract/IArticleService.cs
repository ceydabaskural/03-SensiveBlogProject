using SensiveBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlog.BusinessLayer.Abstract
{
    public interface IArticleService : IGenericService<Article>
    {
        List<Article> TArticleListwithCategory();
        List<Article> TArticleListwithCategoryAndAppUser();
        public Article TGetLastArticle();
        public List<Article> TGetArticlesByAppUserId(int id);
        
    }
}

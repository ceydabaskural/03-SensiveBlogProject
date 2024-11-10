using SensiveBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlog.DataAccessLayer.Abstract
{
    public interface IArticleDal : IGenericDal<Article>
    {
        //Article listesini Categoryleriyle getiren bir metot tanımladık:
        List<Article> ArticleListwithCategory();
        List<Article> ArticleListwithCategoryAndAppUser();
    }
}

using SensiveBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlogProject.DataAccessLayer.Abstract
{
    public interface IArticleDal : IGenericDal<Article>
    {
        //categorylerin isimlerinin gelmesi için
        List<Article> ArticleListWithCategory();

        //hem categorylerin hem yazarların isminin gelmesini istedik
        List<Article> ArticleListWithCategoryAndAppUser();

        Article GetLastArticle();

    }
}

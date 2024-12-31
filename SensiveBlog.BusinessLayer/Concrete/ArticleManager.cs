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
        private readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public List<Article> TArticleListwithCategory()
        {
            return _articleDal.ArticleListwithCategory();
        }

        public List<Article> TArticleListwithCategoryAndAppUser()
        {
            return _articleDal.ArticleListwithCategoryAndAppUser();
        }

        public void TDelete(int id)
        {
            _articleDal.Delete(id);
        }

        public List<Article> TGetAll()
        {
            return _articleDal.GetAll();
        }

        public List<Article> TGetArticlesByAppUserId(int id)
        {
            return _articleDal.GetArticlesByAppUserId(id);
        }

        public Article TGetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public Article TGetLastArticle()
        {
            return _articleDal.GetLastArticle();
        }

        public void TInsert(Article entity)
        {
            _articleDal.Insert(entity);
        }

        public void TUpdate(Article entity)
        {
            if (entity.Description != "" && entity.Title.Length >= 5 && entity.Title.Length <= 100)
            {
                _articleDal.Update(entity);
            }
            else
            {
                //hata mesajı
            }
        }

    }
}

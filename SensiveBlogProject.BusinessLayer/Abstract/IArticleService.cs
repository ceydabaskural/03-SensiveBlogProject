﻿using SensiveBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlogProject.BusinessLayer.Abstract
{
    public interface IArticleService : IGenericService<Article>
    {
        List<Article> TArticleListWithCategory();
        public List<Article> TArticleListWithCategoryAndAppUser();
        public Article TGetLastArticle();
        public List<Article> TGetArticlesByAppUserId(int id);
        public List<Article> TGetLastFiveArticle();
        public List<Article> TGetPopularBlogs();
        public Article TGetArticleById(int id);
    }
}
    
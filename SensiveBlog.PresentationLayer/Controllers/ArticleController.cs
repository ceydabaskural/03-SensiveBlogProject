﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SensiveBlog.BusinessLayer.Abstract;
using SensiveBlog.EntityLayer;
using SensiveBlog.EntityLayer.Concrete;

namespace SensiveBlog.PresentationLayer.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService; //category listesine ihtiyacımız olduğu için ekledik
        private readonly IAppUserService _appUserService;
        private readonly ICommentService _commentService;
        public ArticleController(IArticleService articleService, ICategoryService categoryService, IAppUserService appUserService, ICommentService commentService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _appUserService = appUserService;
            _commentService = commentService;
        }

        public IActionResult ArticleList(int id)
        {
            ViewBag.count = _commentService.TGetCommentsByArticleId(id).Count();
            var values = _articleService.TGetAll();
            return View(values);
        }

        public IActionResult ArticleListwithCategory()
        {
            var values = _articleService.TArticleListwithCategory();
            return View(values);
        }
        public IActionResult ArticleListwithCategoryAndAppUser()
        {
            var values = _articleService.TArticleListwithCategoryAndAppUser();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            var categoryList = _categoryService.TGetAll();
            List<SelectListItem> values1 = (from x in categoryList
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList(); //kategori listesini getirdik
            ViewBag.v1=values1;

            var appUserList = _appUserService.TGetAll();
            List<SelectListItem> values2 = (from x in appUserList
                                            select new SelectListItem
                                            {
                                                Text = x.Name + "" + x.Surname,
                                                Value = x.Id.ToString()
                                            }).ToList();
            ViewBag.v2=values2;

            return View();
        }


        [HttpPost]
        public IActionResult CreateArticle(Article article)
        {
            article.CreatedDate = DateTime.Now; //createdDate parametresini dışarıdan gönderdik
            _articleService.TInsert(article);
            return RedirectToAction("ArticleListWithCategoryAndAppUser");
        }
        public IActionResult DeleteArticle(int id)
        {
            _articleService.TDelete(id);
            return RedirectToAction("ArticleListWithCategoryAndAppUser");
        }

        [HttpGet]
        public IActionResult UpdateArticle(int id)
        {
            var categoryList = _categoryService.TGetAll();
            List<SelectListItem> values1 = (from x in categoryList
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList(); //kategori listesini getirdik
            ViewBag.v1 = values1;

            var appUserList = _appUserService.TGetAll();
            List<SelectListItem> values2 = (from x in appUserList
                                            select new SelectListItem
                                            {
                                                Text = x.Name + "" + x.Surname,
                                                Value = x.Id.ToString()
                                            }).ToList();
            ViewBag.v2 = values2;

            var updatedValue = _articleService.TGetById(id);
            return View(updatedValue);
        }

        [HttpPost]
        public IActionResult UpdateArticle(Article article)
        {

            _articleService.TUpdate(article);
            return RedirectToAction("ArticleListWithCategoryAndAppUser");
        }

        public IActionResult ArticleDetail(int id)
        {
            ViewBag.i = id;
            var value = _articleService.TGetById(id);
            return View(value);
        }

        //[HttpPost]
        //public IActionResult ArticleDetail(Comment comment)
        //{
        //    comment.CreatedDate=DateTime.Now;
        //    comment.ArticleId = 0;
        //    comment.AppUserId = 0;

        //    return RedirectToAction("ArticleList","Default");
        //}

    }
}

using Microsoft.AspNetCore.Mvc;
using SensiveBlog.BusinessLayer.Abstract;
using SensiveBlog.PresentationLayer.Models;
using System.Diagnostics;
using PagedList;
using PagedList.Mvc;
using SensiveBlog.EntityLayer;
using SensiveBlog.EntityLayer.Concrete;

namespace SensiveBlog.PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService, ICategoryService categoryService, ICommentService commentService)
        {
            _logger = logger;
            _articleService = articleService;
            _categoryService = categoryService;
            _commentService = commentService;
        }

        public IActionResult Index(Article article)
        {
            //ViewBag.categoryBlogCount = _articleService.GetBlogCountByCategory(categoryId);
            ViewBag.countComment=_commentService.CountCommentsByArticleId(article);
            var value = _articleService.TArticleListwithCategoryAndAppUser();
            return View(value);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

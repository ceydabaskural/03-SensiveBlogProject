using Microsoft.AspNetCore.Mvc;
using SensiveBlog.BusinessLayer.Abstract;

namespace SensiveBlog.PresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IArticleService _articleService;

        public DefaultController(IArticleService articleService)
        {
            _articleService = articleService;
        }


        public IActionResult ArticleList()
        {
            var value = _articleService.TArticleListwithCategoryAndAppUser();
            return View(value);
        }

        public IActionResult CategoryList()
        {
            var value = _articleService.TArticleListwithCategoryAndAppUser();
            return View(value);
        }
    }
}

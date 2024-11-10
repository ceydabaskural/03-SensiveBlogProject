using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SensiveBlog.BusinessLayer.Abstract;

namespace SensiveBlog.PresentationLayer.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService; //category listesine ihtiyacımız olduğu için ekledik
        private readonly IAppUserService _appUserService;
        public ArticleController(IArticleService articleService, ICategoryService categoryService, IAppUserService appUserService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _appUserService = appUserService;
        }

        public IActionResult ArticleList()
        {
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

    }
}

using MessagePack;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using SensiveBlogProject.BusinessLayer.Abstract;
using SensiveBlogProject.EntityLayer.Concrete;
using System.Security.Claims;

namespace SensiveBlogProject.PresentationLayer.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IAppUserService _appUserService;
        private readonly ICommentService _commentService;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IAppUserService appUserService, ICommentService commentService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _appUserService = appUserService;
            _commentService = commentService;
        }

        //TGetAll içinde Category ismini getiremedik sadece categoryleri Id olarak listeledi. Category.CategoryName dediğimizde hata veriyordu
        public IActionResult ArticleList()
        {
            var value = _articleService.TGetAll();
            return View(value);
        }

        //entitye özgü metot yazarak kategorilerin isimleriyle bir gelmesini sağladık. Burada ise Category sınıfını dahil ettiğimiz için Category.CategoryName yapabildik
        public IActionResult ArticleListWithCategory()
        {
            var values = _articleService.TArticleListWithCategory();
            return View(values);
        }

        //hem yazar hem category nin isimleri gelmesi için bir metot daha yazdık
        public IActionResult ArticleListWithCategoryAndAppUser()
        {
            var values = _articleService.TArticleListWithCategoryAndAppUser();
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
                                            }).ToList();

            ViewBag.v1= values1;

            var appUserList = _appUserService.TGetAll();
            List<SelectListItem> values2 = (from x in appUserList
                                            select new SelectListItem
                                            {
                                                Text = x.Name + " " + x.Surname,
                                                Value = x.Id.ToString()
                                            }).ToList();
            ViewBag.v2= values2;
            return View();
        }

        public IActionResult UpdateArticle(int id)
        {
            var categoryList = _categoryService.TGetAll();
            List<SelectListItem> values1 = (from x in categoryList
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();

            ViewBag.v1 = values1;

            var appUserList = _appUserService.TGetAll();
            List<SelectListItem> values2 = (from x in appUserList
                                            select new SelectListItem
                                            {
                                                Text = x.Name + " " + x.Surname,
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
            return RedirectToAction(nameof(ArticleListWithCategoryAndAppUser));
        }

        public IActionResult DeleteArticle(int id)
        {
            _articleService.TDelete(id);
            return RedirectToAction(nameof(ArticleListWithCategoryAndAppUser));
        }

        public IActionResult Index(int id)
        {
            //ViewData ile blog detaylarının arka planı için image taşıdım:
            ViewData["BannerImage"] = "/sensive-master/img/banner/blogchat.png";

            ViewBag.i = id;

            // Boş veri kontrolü
            var value = _articleService.TGetArticleById(id);

            if (value == null)
            {
                // Eğer makale bulunamazsa kullanıcıya hata sayfası gösterilebilir
                return NotFound("İlgili makale bulunamadı.");
            }

            ViewBag.ArticleId = value.ArticleId;
            return View(value);
        }

    }
}

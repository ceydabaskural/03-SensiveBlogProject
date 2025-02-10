using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SensiveBlogProject.BusinessLayer.Abstract;
using SensiveBlogProject.BusinessLayer.ValidationRules.ArticleValidationRules;
using SensiveBlogProject.EntityLayer.Concrete;

namespace SensiveBlogProject.PresentationLayer.Areas.Author.Controllers
{
    [Area("Author")]
    [Route("Author/[controller]/[action]/{id?}")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public ArticleController(UserManager<AppUser> userManager, IArticleService articleService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index() //FindByNameAsync olduğundan dolayı burada asyn kullandık
        {
            var userInfo = await _userManager.FindByNameAsync(User.Identity.Name); //giriş yapan kullanıcının bilgilerini tutar
            var articleList = _articleService.TGetArticlesByAppUserId(userInfo.Id); //kullanıcının id sine göre makaleleri getirecek
            return View(articleList);
        }

        [HttpGet]
        public async Task<IActionResult> CreateArticle()
        {
            var categoryList = _categoryService.TGetAll();
            List<SelectListItem> values1 = (from x in categoryList
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();
            ViewBag.CategoryList = values1;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(Article model)
        {
            if (model == null)
            {
                ModelState.AddModelError("", "Article is null");
                return View(model);
            }
            // Giriş yapan kullanıcıyı alıyoruz
            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);

            model.AppUserId = userValue.Id;
            model.CreatedDate = DateTime.Now;

            CreateArticleValidator validationRules = new CreateArticleValidator();
            ValidationResult result = validationRules.Validate(model);

            if (result.IsValid)
            {
                _articleService.TInsert(model);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            //Kategori listesini yeniden doldur
            var categoryList = _categoryService.TGetAll();

            List<SelectListItem> values1 = (from x in categoryList
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();
            ViewBag.CategoryList = values1;


            return View();
        }

        public IActionResult DeleteArticle(int id)
        {
            _articleService.TDelete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult UpdateArticle(int id)
        {
            var article = _articleService.TGetById(id);

            var categories = _categoryService.TGetAll();

            List<SelectListItem> categoryList = categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString(),
                Selected = article.CategoryId == x.CategoryId
            }).ToList();

            ViewBag.CategoryList = categoryList;

            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateArticle(Article article)
        {
            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);
            article.AppUserId = userValue.Id;
            _articleService.TUpdate(article);
            return RedirectToAction("Index");
        }

    }
}

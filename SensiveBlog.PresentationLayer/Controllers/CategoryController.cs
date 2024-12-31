using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SensiveBlog.BusinessLayer.Abstract;
using SensiveBlog.BusinessLayer.ValidationRules.CategoryValidationRules;
using SensiveBlog.DataAccessLayer.Abstract;
using SensiveBlog.EntityLayer;

namespace SensiveBlog.PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;


        public CategoryController(ICategoryService categoryService, IArticleService articleService)
        {
            _categoryService = categoryService;
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            var value = _articleService.TArticleListwithCategoryAndAppUser();
            return View(value);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            //bellekteki hata mesajlarını yok sayıp bizim yazdığımız hata mesajını yazdırmayı sağlar.
            ModelState.Clear();
            CreateCategoryValidator validationRules = new CreateCategoryValidator();
            ValidationResult result = validationRules.Validate(category);
            if (result.IsValid)
            {
                _categoryService.TInsert(category);
                return RedirectToAction("CategoryList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }

            
        }

        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value =_categoryService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.TUpdate(category);
            return RedirectToAction("CategoryList");
        }
    }
}

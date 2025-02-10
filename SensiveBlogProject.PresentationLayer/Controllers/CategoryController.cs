using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.BusinessLayer.Abstract;
using SensiveBlogProject.BusinessLayer.ValidationRules.CategoryValidationRules;
using SensiveBlogProject.DataAccessLayer.Abstract;
using SensiveBlogProject.EntityLayer.Concrete;

namespace SensiveBlogProject.PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        //category adı 5 karakterden kısa olursa eklemiyor, çünkü categorymanager da buna izin vermedik
        public IActionResult CreateCategory(Category category)
        {
            ModelState.Clear(); //hata mesajlarını türkçe yazdırmasını sağladık    
            CreateCategoryValidator validationRules = new CreateCategoryValidator();
            ValidationResult result = validationRules.Validate(category);//categoryden gelen değerlerin geçerliliği kontrol edilecek
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
            return RedirectToAction(nameof(CategoryList));
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.TUpdate(category);
            return RedirectToAction(nameof(CategoryList));
        }
    }
}

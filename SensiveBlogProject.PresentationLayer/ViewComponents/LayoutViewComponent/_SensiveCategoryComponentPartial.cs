using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.BusinessLayer.Abstract;

namespace SensiveBlogProject.PresentationLayer.ViewComponents.LayoutViewComponent
{
    public class _SensiveCategoryComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _SensiveCategoryComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _categoryService.TCountCategoriesWithArticles();
            return View(value);
        }
    }
}

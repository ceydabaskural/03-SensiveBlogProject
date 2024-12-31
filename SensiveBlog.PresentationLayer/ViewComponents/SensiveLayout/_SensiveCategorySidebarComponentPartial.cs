using Microsoft.AspNetCore.Mvc;
using SensiveBlog.BusinessLayer.Abstract;
using SensiveBlog.EntityLayer.Concrete;

namespace SensiveBlog.PresentationLayer.ViewComponents.SensiveLayout
{
    public class _SensiveCategorySidebarComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _SensiveCategorySidebarComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var value = _categoryService.TGetAll();
            return View(value);
        }
    }
}

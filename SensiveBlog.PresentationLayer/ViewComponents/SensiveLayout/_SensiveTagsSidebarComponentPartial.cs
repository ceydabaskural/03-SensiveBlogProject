using Microsoft.AspNetCore.Mvc;
using SensiveBlog.BusinessLayer.Abstract;

namespace SensiveBlog.PresentationLayer.ViewComponents.SensiveLayout
{
    public class _SensiveTagsSidebarComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _SensiveTagsSidebarComponentPartial(ICategoryService categoryService)
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

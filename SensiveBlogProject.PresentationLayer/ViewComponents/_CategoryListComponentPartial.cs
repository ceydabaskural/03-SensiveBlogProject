using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.BusinessLayer.Abstract;
using SensiveBlogProject.DataAccessLayer.Abstract;

namespace SensiveBlogProject.PresentationLayer.ViewComponents
{
    public class _CategoryListComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoryListComponentPartial(ICategoryService categoryService)
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

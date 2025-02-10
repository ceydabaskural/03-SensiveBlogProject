using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.BusinessLayer.Abstract;

namespace SensiveBlogProject.PresentationLayer.ViewComponents.LayoutViewComponent
{
    public class _SensiveBlogSliderComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;

        public _SensiveBlogSliderComponentPartial(IArticleService articleService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _articleService.TGetLastFiveArticle();
            return View(value);
        }
    }
}

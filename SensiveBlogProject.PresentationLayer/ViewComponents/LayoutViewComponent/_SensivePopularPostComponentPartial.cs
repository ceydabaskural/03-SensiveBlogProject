using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.BusinessLayer.Abstract;

namespace SensiveBlogProject.PresentationLayer.ViewComponents.LayoutViewComponent
{
    public class _SensivePopularPostComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _SensivePopularPostComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _articleService.TGetPopularBlogs();
            return View(value);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SensiveBlog.BusinessLayer.Abstract;

namespace SensiveBlog.PresentationLayer.ViewComponents.SensiveLayout
{
    public class _SensivePostsSidebarComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _SensivePostsSidebarComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _articleService.TArticleListwithCategoryAndAppUser();
            return View(value);
        }
    }
}

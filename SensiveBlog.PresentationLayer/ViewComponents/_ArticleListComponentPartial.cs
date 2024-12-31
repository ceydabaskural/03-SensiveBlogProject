using Microsoft.AspNetCore.Mvc;
using SensiveBlog.BusinessLayer.Abstract;

namespace SensiveBlog.PresentationLayer.ViewComponents
{
    public class _ArticleListComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _ArticleListComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _articleService.TArticleListwithCategoryAndAppUser();
            return View(values);
        }
    }
}

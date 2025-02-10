using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.BusinessLayer.Abstract;

namespace SensiveBlogProject.PresentationLayer.ViewComponents.ArticleViewComponent
{
    public class _ArticleDetailComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _ArticleDetailComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var value = _articleService.TGetArticleById(id);
            return View(value);
        }
    }
}

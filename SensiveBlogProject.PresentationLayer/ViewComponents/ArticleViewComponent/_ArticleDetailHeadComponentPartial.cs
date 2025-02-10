using Microsoft.AspNetCore.Mvc;

namespace SensiveBlogProject.PresentationLayer.ViewComponents.ArticleViewComponent
{
    public class _ArticleDetailHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

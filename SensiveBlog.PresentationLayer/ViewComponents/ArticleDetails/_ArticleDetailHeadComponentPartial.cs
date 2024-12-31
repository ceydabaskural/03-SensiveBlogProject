using Microsoft.AspNetCore.Mvc;

namespace SensiveBlog.PresentationLayer.ViewComponents.ArticleDetails
{
    public class _ArticleDetailHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

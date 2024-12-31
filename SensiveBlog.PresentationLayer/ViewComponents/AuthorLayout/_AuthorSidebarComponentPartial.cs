using Microsoft.AspNetCore.Mvc;

namespace SensiveBlog.PresentationLayer.ViewComponents.AuthorLayout
{
    public class _AuthorSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace SensiveBlog.PresentationLayer.ViewComponents.AuthorLayout
{
    public class _AuthorHeaderComponentPartial : ViewComponent
    { 
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

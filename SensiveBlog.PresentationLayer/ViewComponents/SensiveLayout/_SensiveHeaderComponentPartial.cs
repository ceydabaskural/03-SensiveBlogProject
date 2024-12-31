using Microsoft.AspNetCore.Mvc;

namespace SensiveBlog.PresentationLayer.ViewComponents.SensiveLayout
{
    public class _SensiveHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

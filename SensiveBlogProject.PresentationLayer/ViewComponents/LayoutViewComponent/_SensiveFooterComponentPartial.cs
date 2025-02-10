using Microsoft.AspNetCore.Mvc;

namespace SensiveBlogProject.PresentationLayer.ViewComponents.DefaultDetails
{
    public class _SensiveFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

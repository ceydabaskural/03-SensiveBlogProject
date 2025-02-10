using Microsoft.AspNetCore.Mvc;

namespace SensiveBlogProject.PresentationLayer.ViewComponents.DefaultDetails
{
    public class _SensiveHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}

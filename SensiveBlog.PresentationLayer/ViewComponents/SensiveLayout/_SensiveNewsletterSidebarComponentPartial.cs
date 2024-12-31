using Microsoft.AspNetCore.Mvc;
using SensiveBlog.BusinessLayer.Abstract;
using SensiveBlog.DataAccessLayer.Abstract;
using SensiveBlog.EntityLayer.Concrete;

namespace SensiveBlog.PresentationLayer.ViewComponents.SensiveLayout
{
    public class _SensiveNewsletterSidebarComponentPartial : ViewComponent
    {
        private readonly INewsletterService _newsletterService;

        public _SensiveNewsletterSidebarComponentPartial(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SensiveBlog.BusinessLayer.Abstract;
using SensiveBlog.EntityLayer.Concrete;

namespace SensiveBlog.PresentationLayer.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly INewsletterService _newsletterService;

        public NewsletterController(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }

        [HttpGet]
        public IActionResult AddNewsletter()
        {
            var value = _newsletterService.TGetAll();
            return View(value);
        }

        [HttpPost]
        public IActionResult AddNewsletter(Newsletter newsletter)
        {
            string currentController = RouteData.Values["controller"].ToString();
            _newsletterService.TInsert(newsletter);
            return RedirectToAction("Index","Home");
        }
    }
}

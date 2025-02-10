using Microsoft.AspNetCore.Mvc;

namespace SensiveBlogProject.PresentationLayer.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ContactImage"] = "/sensive-master/img/banner/contact.png";
            return View();
        }
    }
}

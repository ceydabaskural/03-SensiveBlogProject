using Microsoft.AspNetCore.Mvc;

namespace SensiveBlog.PresentationLayer.Areas.Author.Controllers
{
    [Area("Default")]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

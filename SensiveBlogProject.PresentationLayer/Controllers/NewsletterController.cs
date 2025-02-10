using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.BusinessLayer.Abstract;
using SensiveBlogProject.EntityLayer.Concrete;

namespace SensiveBlogProject.PresentationLayer.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly INewsletterService _newsletterService;

        public NewsletterController(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }
        [HttpPost]
        public IActionResult Subscribe(Newsletter newsLetter)
        {
            try
            {
                _newsletterService.TInsert(newsLetter);
                return Json(new { success = true, message = "Abonelik işlemi başarılı!" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Abonelik işlemi sırasında bir hata oluştu." });
            }
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using SensiveBlog.BusinessLayer.Abstract;
using SensiveBlog.EntityLayer.Concrete;

namespace SensiveBlog.PresentationLayer.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        
    }
}

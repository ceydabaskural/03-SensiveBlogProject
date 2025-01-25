using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.EntityLayer.Concrete;
using SensiveBlogProject.PresentationLayer.Areas.Author.Models;

namespace SensiveBlogProject.PresentationLayer.Areas.Author.Controllers
{
    [Area("Author")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name); //kullanıcının adına göre bulur
            UserEditViewModel model = new UserEditViewModel(); //bir köprü görevinde, üst satırda gelen kullanıcı bilgilerini aktarmak için kullanacağımız bir sınıf görevi üstlenmiş oldu
            model.Surname = user.Surname;
            model.Email = user.Email;
            model.Name = user.Name;
            model.Username = user.UserName;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model) 
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.Name = model.Name;
            user.UserName = model.Username;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Default");
            }
            else
            {
                return View();
            }
        }
    }
}

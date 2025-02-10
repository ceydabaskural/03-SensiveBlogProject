using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.BusinessLayer.Abstract;
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
            model.Description = user.Description;
            model.ImageUrl = user.ImageUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                return View(model);
            }

            user.Surname = model.Surname;
            user.Email = model.Email;
            user.Name = model.Name;
            user.UserName = model.Username;
            user.Description = model.Description;
            user.ImageUrl = model.ImageUrl;

            // Şifre güncellemesi yalnızca kullanıcı şifre alanına bir şey girdiyse yapılır.
            if (!string.IsNullOrWhiteSpace(model.Password))
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Profil güncellemesi başarılı!";
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }




    }
}

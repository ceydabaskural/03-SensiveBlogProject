using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.EntityLayer.Concrete;
using SensiveBlogProject.PresentationLayer.Areas.Author.Models;

namespace SensiveBlogProject.PresentationLayer.Controllers
{
    [Area("Author")]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Article");
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync(); // Kullanıcı oturumunu kapat
            return RedirectToAction("Index", "Login"); // Login sayfasına yönlendir
        }
    }
}

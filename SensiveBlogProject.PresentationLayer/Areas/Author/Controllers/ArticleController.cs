using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.BusinessLayer.Abstract;
using SensiveBlogProject.EntityLayer.Concrete;

namespace SensiveBlogProject.PresentationLayer.Areas.Author.Controllers
{
    [Area("Author")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;

        public ArticleController(UserManager<AppUser> userManager, IArticleService articleService)
        {
            _userManager = userManager;
            _articleService = articleService;
        }
        public async Task<IActionResult> MyArticleList() //FindByNameAsync olduğundan dolayı burada asyn kullandık
        {
            var userInfo = await _userManager.FindByNameAsync(User.Identity.Name); //giriş yapan kullanıcının bilgilerini tutar
            var articleList = _articleService.TGetArticlesByAppUserId(userInfo.Id); //kullanıcının id sine göre makaleleri getirecek
            return View(articleList);
        }
    }
}

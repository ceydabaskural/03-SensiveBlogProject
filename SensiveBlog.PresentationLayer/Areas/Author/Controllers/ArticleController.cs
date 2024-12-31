using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SensiveBlog.BusinessLayer.Abstract;
using SensiveBlog.EntityLayer.Concrete;

namespace SensiveBlog.PresentationLayer.Areas.Author.Controllers
{
    [Area("Author")] //diğer article controller ile karışmaması için buradakinin areas içinde olduğunu belirttik
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager; 

        public ArticleController(IArticleService articleService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _userManager = userManager;
        }

        public async Task<IActionResult> MyArticleList()//asyn metot kullandığımız için asyn ekledik
        {
            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);
            var articleList = _articleService.TGetArticlesByAppUserId(userValue.Id);
            return View(articleList);
        }
    }
}

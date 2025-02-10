using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using SensiveBlogProject.BusinessLayer.Abstract;
using SensiveBlogProject.DataAccessLayer.Abstract;

namespace SensiveBlogProject.PresentationLayer.Areas.Author.Controllers
{
    [Area("Author")]
    public class DashboardController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;

        public DashboardController(IAppUserService appUserService, IArticleService articleService, ICommentService commentService)
        {
            _appUserService = appUserService;
            _articleService = articleService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            ViewBag.blog = _articleService.TGetAll().Count();
            ViewBag.comment = _commentService.TGetAll().Count();
            var value = _appUserService.TGetAppUserInfo();
            return View(value);
        }
    }
}

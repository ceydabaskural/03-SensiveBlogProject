using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.BusinessLayer.Abstract;
using SensiveBlogProject.EntityLayer.Concrete;

namespace SensiveBlogProject.PresentationLayer.Areas.Author.Controllers
{
    [Area("Author")]
    [Route("Author/[controller]/[action]/{id?}")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager, IArticleService articleService)
        {
            _commentService = commentService;
            _userManager = userManager;
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userInfo = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _commentService.TGetCommentsByArticleIdAndAppUser(userInfo.Id);
            return View(value);
        }

        public IActionResult DeleteComment(int id)
        {
            _commentService.TDelete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateComment(int id)
        {
            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);
            var comment = _commentService.TGetCommentById(id, userValue.Id);
            return View(comment);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateComment(Comment comment)
        {
            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);

            // Mevcut yorumu getir ve güncelle
            var existingComment = _commentService.TGetCommentById(comment.CommentId, userValue.Id);
            if (existingComment == null)
            {
                return NotFound();
            }

            existingComment.Detail = comment.Detail;
            existingComment.CreatedDate = DateTime.Now;

            _commentService.TUpdate(existingComment);

            return RedirectToAction("CommentList");
        }
    }
}

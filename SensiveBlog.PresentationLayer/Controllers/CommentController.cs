using Microsoft.AspNetCore.Mvc;
using SensiveBlog.BusinessLayer.Abstract;
using SensiveBlog.EntityLayer.Concrete;

namespace SensiveBlog.PresentationLayer.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.CreatedDate = DateTime.Now;
            comment.Status = true;
            _commentService.TInsert(comment);

            return RedirectToAction("AddComment", "Comment");
        }
    }
}

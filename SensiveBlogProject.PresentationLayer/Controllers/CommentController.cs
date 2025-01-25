using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.BusinessLayer.Abstract;
using SensiveBlogProject.EntityLayer.Concrete;

namespace SensiveBlogProject.PresentationLayer.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.i = id;
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment) //yorum yapma işlemi yapacağız 
        {
            comment.CreatedDate = DateTime.Now;
            //comment.AppUserId = 0;
            comment.ArticleId = 1;
            _commentService.TInsert(comment);
            return RedirectToAction("ArticleList","Default");
        }
    }
}

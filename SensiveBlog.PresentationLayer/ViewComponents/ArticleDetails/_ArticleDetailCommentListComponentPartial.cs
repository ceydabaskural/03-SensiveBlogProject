using Microsoft.AspNetCore.Mvc;
using SensiveBlog.BusinessLayer.Abstract;

namespace SensiveBlog.PresentationLayer.ViewComponents.ArticleDetails
{
    public class _ArticleDetailCommentListComponentPartial : ViewComponent
    {
        public readonly ICommentService _commentService;
        public _ArticleDetailCommentListComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IViewComponentResult Invoke(int id)
        {
            var value = _commentService.TGetCommentsByArticleId(id);
            return View(value);
        }
    }
}

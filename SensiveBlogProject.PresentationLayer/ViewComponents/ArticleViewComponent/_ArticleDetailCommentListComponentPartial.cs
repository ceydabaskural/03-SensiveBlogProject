using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.BusinessLayer.Abstract;
using SensiveBlogProject.DataAccessLayer.Abstract;

namespace SensiveBlogProject.PresentationLayer.ViewComponents.ArticleViewComponent
{
    public class _ArticleDetailCommentListComponentPartial : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _ArticleDetailCommentListComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var value = _commentService.TGetCommentsByArticleIdAndAppUser(id);
            return View(value);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.BusinessLayer.Abstract;
using X.PagedList;

namespace SensiveBlogProject.PresentationLayer.ViewComponents.LayoutViewComponent
{
    public class _SensiveBlogPostComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _SensiveBlogPostComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke(int page = 1, int pageSize = 6)
        {
            var values = _articleService.TArticleListWithCategoryAndAppUser()
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)_articleService.TArticleListWithCategoryAndAppUser().Count() / pageSize);

            return View(values);
        }
    }
}
